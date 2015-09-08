using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SchoolAccountant.Helpers
{
    public class WaterMark : PdfPageEventHelper
    {
        private readonly string _schoolName;

        public WaterMark(string schoolName)
        {
            _schoolName = schoolName;
        }
        private readonly Font _font15Bg = new Font(Font.FontFamily.HELVETICA, 20, Font.BOLD, new GrayColor(0.9f));

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            ColumnText.ShowTextAligned(writer.DirectContentUnder, Element.ALIGN_CENTER,
                new Phrase(_schoolName, _font15Bg), 200, 190, 35);
        }
    }
}