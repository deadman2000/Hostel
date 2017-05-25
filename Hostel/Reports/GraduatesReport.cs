using Hostel.DB;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Hostel.Reports
{
    static class GraduatesReport
    {
        public static void Build()
        {
            var students = Store.Inst.Students.Where(s => s.Speciality != null && s.Speciality.Duration == s.Year);

            string fileName = ReportUtils.GetFilePath("graduates_" + DateTime.Now.ToString("ddMMyy-HHmmss") + ".xlsx");

            using (SLDocument sl = new SLDocument())
            {
                SLStyle stHeader = new SLStyle();
                stHeader.Alignment.Horizontal = HorizontalAlignmentValues.Center;
                stHeader.Font.FontName = "Arial";
                stHeader.Font.Bold = true;
                stHeader.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
                stHeader.Border.BottomBorder.BorderStyle = BorderStyleValues.Double;
                stHeader.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
                stHeader.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;

                sl.SetCellValue("A1", "№");
                sl.SetCellValue("B1", "ФИО студента");
                sl.SetCellValue("C1", "Комната");
                sl.SetCellStyle(1, 1, 1, 3, stHeader);

                int num = 0;
                foreach (var st in students)
                {
                    num++;
                    int row = num + 1;
                    sl.SetCellValue(row, 1, num);
                    sl.SetCellValue(row, 2, st.SecondName + " " + st.FirstName + " " + st.Patronymic);
                    sl.SetCellValue(row, 3, st.Room);
                }

                sl.AutoFitColumn(1, 3);

                sl.SaveAs(fileName);
            }

            Process.Start(fileName);
        }
    }
}
