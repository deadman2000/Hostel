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
    class GraduatesReport : Report
    {
        protected override string Template => "graduates";

        protected override void FillContent()
        {
            var students = Store.Inst.Students.Where(s => s.Speciality != null && s.Speciality.Duration == s.Year);

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
            sl.SetCellValue("D1", "Группа");
            sl.SetCellStyle(1, 1, 1, 4, stHeader);

            int num = 0;
            foreach (var st in students)
            {
                num++;
                int row = num + 1;
                sl.SetCellValue(row, 1, num);
                sl.SetCellValue(row, 2, st.FullName);
                sl.SetCellValue(row, 3, st.Room);
                sl.SetCellValue(row, 4, st.Group);
            }

            sl.AutoFitColumn(1, 4);
        }
    }
}
