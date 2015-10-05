using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Constants;
using BusinessLogic.Entities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SchoolAccountant.Models;
using static System.Environment;

namespace SchoolAccountant.Helpers
{
    public class ReceiptGenerator
    {
        private readonly Student _student;
        private readonly ClassTermFee _classTermFee;
        private readonly School _school;
        private readonly FeePayment _feePayment;

        private static readonly Font Font7 = new Font(Font.FontFamily.TIMES_ROMAN, 7f, Font.NORMAL);
        private static readonly Font Font7B = new Font(Font.FontFamily.TIMES_ROMAN, 7f, Font.BOLD);
        private static readonly Font Font8B = new Font(Font.FontFamily.TIMES_ROMAN, 8f, Font.BOLD);
        private static readonly Font Font14B = new Font(Font.FontFamily.TIMES_ROMAN, 14f, Font.BOLD);
        private static readonly Font Font11B = new Font(Font.FontFamily.TIMES_ROMAN, 11, Font.BOLD);
        private static readonly Font Font11I = new Font(Font.FontFamily.TIMES_ROMAN, 11, Font.ITALIC);
        private static readonly Font Font8 = new Font(Font.FontFamily.TIMES_ROMAN, 8f, Font.NORMAL);
        private static readonly Font Font9 = new Font(Font.FontFamily.TIMES_ROMAN, 9f, Font.NORMAL);
        private static readonly Font Font9B = new Font(Font.FontFamily.TIMES_ROMAN, 9f, Font.BOLD);
        private static readonly Font Font10 = new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.NORMAL);
        private static readonly Font Font10B = new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.BOLD);

        public ReceiptGenerator(ReceiptModel receiptModel)
        {
            _student = receiptModel.Student;
            _classTermFee = receiptModel.ClassTermFee;
            _school = receiptModel.School;
            _feePayment = _student.FeePayments.FirstOrDefault(x => x.ClassArmTermFeeId == _classTermFee.Id);

        }

        internal string Generate()
        {
            var filePath = Utilities.GetFilePath(_student, _classTermFee);
            var document = NewDocument(filePath);

            document.Open();
            document.Add(ReceiptHeader(_school.LogoPath));
            document.Add(Content());
            document.Add(Footer());
            document.Close();
            return filePath;
        }

        private IElement Footer()
        {
            var table = new PdfPTable(1);
            //            table.SetWidths(new[] { 2, 1 });
            table.WidthPercentage = 100f;

            table.AddCell(AddTitle(_school.Slogan, Font11I, borderWidth: 0.0f, hAlignment: 'C'));
            return table;
        }

        private IElement Content()
        {
            var table = new PdfPTable(2);
            table.SetWidths(new[] { 1, 3 });
            table.WidthPercentage = 100f;
            table.SpacingAfter = 5f;

            var titles = new List<string>
            {
                "Date", "Paid By",
                "Amount", "In respect of"
            };

            var bankPayment = _feePayment.Bank != null && _feePayment.ReceiptNumber != null;
            var chequePayment = _feePayment.ChequeNumber != null;

            if (bankPayment)
            {
                titles.Add("Bank");
                titles.Add("Receipt No");
            }
            else if (chequePayment)
            {
                titles.Add("Cheque No");
            }

            var commentExist = _feePayment.Comment != null;

            if (commentExist)
            {
                titles.Add("Comment");
            }

            var texts = new List<string>
            {
                DateTime.Now.ToString(),
                _feePayment.PaidBy,
               $"{NumberText.NumberToWords((int)_feePayment.Amount)} Naira Only ({_feePayment.Amount} Naira)",
               $"{_student.FirstName} {_student.LastName}"
            };

            if (bankPayment)
            {
                texts.Add(_feePayment.Bank);
                texts.Add(_feePayment.ReceiptNumber);
            }
            else if (chequePayment)
            {
                texts.Add(_feePayment.ChequeNumber);
            }

            if (commentExist)
            {
                texts.Add(_feePayment.Comment);
            }
            
            for (int i = 0; i < titles.Count(); i++)
            {
                table.AddCell(AddTitle(titles[i].ToUpper(), Font8B));
                table.AddCell(AddText(texts[i], Font8));
            }

            return table;
        }

        private IElement ReceiptHeader(string logoPath)
        {
            var table = new PdfPTable(2);
            table.SetWidths(new[] { 2, 12 });
            table.WidthPercentage = 100f;
            table.SpacingAfter = 5f;

            // Logo
            var cell = new PdfPCell
            {
                BorderWidth = 0.0f,
                BorderColor = BaseColor.LIGHT_GRAY,
            };

            cell.AddElement(Image.GetInstance(logoPath));
            cell.Colspan = 1;
            cell.Rowspan = 4;
            table.AddCell(cell);

            // Receipt header
            table.AddCell(AddTitle(_school.Name, Font14B, borderWidth: 0.0f, hAlignment: 'C'));
            table.AddCell("");

            table.AddCell(AddTitle($"{_school.Address} Tel: {string.Join(",", _school.PhoneNumbers)}", Font9, borderWidth: 0.0f, hAlignment: 'C'));

            table.AddCell(AddTitle("RECEIPT", Font14B, 'M', 0.0f, hAlignment: 'C'));

            return table;
        }

       

        private static PdfPCell AddTitle(string text, Font font, char vAlignment = 'C', float borderWidth = 0.05f, char hAlignment = 'L')
        {
            var cell = new PdfPCell(new Phrase(text, font))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                BorderWidth = borderWidth,
                BorderColor = BaseColor.LIGHT_GRAY,
                MinimumHeight = 15f
            };

            switch (vAlignment)
            {
                case 'T':
                    cell.VerticalAlignment = Element.ALIGN_TOP;
                    break;
                case 'C':
                    cell.VerticalAlignment = Element.ALIGN_CENTER;
                    break;
                case 'B':
                    cell.VerticalAlignment = Element.ALIGN_BOTTOM;
                    break;
            }

            switch (hAlignment)
            {
                case 'L':
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
                case 'C':
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case 'R':
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
            }

            return cell;
        }

        private static PdfPCell AddText(string text, Font font, char hAlignment = 'L')
        {
            var cell = new PdfPCell(new Phrase(text, font))
            {
                PaddingLeft = 5,
                BorderWidth = 0.05f,
                BorderColor = BaseColor.LIGHT_GRAY,
                MinimumHeight = 12f
            };

            switch (hAlignment)
            {
                case 'L':
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
                case 'C':
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case 'R':
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
            }

            return cell;
        }

        public Document NewDocument(string path)
        {
            var document = new Document(PageSize.A6.Rotate());
            var pdf = new FileStream(path, FileMode.OpenOrCreate);
            PdfWriter writer = PdfWriter.GetInstance(document, pdf);
            writer.PageEvent = new WaterMark(_school.Name);
            document.AddCreationDate();
            document.AddAuthor("lilvonz");
            document.AddTitle("School Receipt");
            document.SetMargins(20f, 20f, 20f, 20f);
            return document;
        }
    }
}
