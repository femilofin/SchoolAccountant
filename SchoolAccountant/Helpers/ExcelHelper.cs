using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Constants;
using BusinessLogic.Entities;
using Excel = Microsoft.Office.Interop.Excel;

namespace SchoolAccountant.Helpers
{
    public class ExcelHelper
    {
        public static string ExcelPath = Utilities.GetExcelPath();
        public static IList<Student> Students = new List<Student>();
        private static Excel.Workbook _myBook;
        private static Excel.Application _myApp;
        private static Excel.Worksheet _mySheet;
        private static int _lastRow;
        public static void InitializeExcel()
        {

            _myApp = new Excel.Application {Visible = false};
            _myBook = _myApp.Workbooks.Open(ExcelPath);
            _mySheet = (Excel.Worksheet)_myBook.Sheets[1]; // Explict cast is not required here
            _lastRow = _mySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
        }
        public static IList<Student> ReadExcel()
        {
            for (int index = 10; index <= _lastRow; index++)
            {
                var myValues =(Array) _mySheet.Range["A" + index, "K" + index].Cells.Value;
                Students.Add(new Student
                {
                    FirstName = myValues.GetValue(1, 1).ToString(),
                    LastName = myValues.GetValue(1, 2).ToString(),
                    MiddleName = myValues.GetValue(1, 3).ToString(),
                    BirthDate = Convert.ToDateTime(myValues.GetValue(1, 4).ToString()),
                    StartDate = Convert.ToDateTime(myValues.GetValue(1, 5).ToString()),
                    OutstandingFee = Convert.ToDecimal(myValues.GetValue(1, 6).ToString()),
                    StartClass = (ClassEnum) myValues.GetValue(1, 7),
                    StartTerm = (TermEnum) myValues.GetValue(1, 8),
                    PresentClass = (ClassEnum) myValues.GetValue(1, 9),
                    PresentTerm = (TermEnum) myValues.GetValue(1, 10),
                    PresentArm = (ArmEnum) myValues.GetValue(1, 11),
                });
            }
            return Students;
        }
    }
}
