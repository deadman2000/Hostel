using Hostel.DB;
using Hostel.Model;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Hostel.Reports
{
    class FacYearReport : Report
    {
        protected override string Template => "facyear";

        private Faculty fac;

        public FacYearReport(Faculty faculty)
        {
            fac = faculty;
        }

        protected override void FillContent()
        {
            if (fac == null) return;

            var facSt = Store.Inst.Students.Where(s => s.Speciality != null && s.Speciality.Faculty == fac);
            var byYear = facSt.GroupBy(s => s.Year).OrderBy(s => s.Key);

            bool firstSheet = true;
            var now = DateTime.Now;
            string date = String.Format("на \"{0}\" {1}", now.Day, now.ToString("MMMM yyyy"));

            SLStyle stDate = new SLStyle { FormatCode = "DD.MM.YYYY" };
            stDate.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            SLStyle stHeader = new SLStyle();
            stHeader.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            stHeader.Font.FontName = "Arial";
            stHeader.Font.Bold = true;
            stHeader.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            stHeader.Border.BottomBorder.BorderStyle = BorderStyleValues.Double;
            stHeader.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            stHeader.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;

            SLStyle stTable = new SLStyle();
            stTable.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            stTable.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            stTable.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;

            SLStyle stCenter = new SLStyle();
            stCenter.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            foreach (var kv in byYear)
            {
                string sheetName = kv.Key + " курс";
                if (firstSheet)
                    sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, sheetName);
                else
                    sl.AddWorksheet(sheetName);

                sl.SetCellValue("H1", "Список студентов. Факультет " + fac.Name); sl.SetCellStyle("H1", stCenter);
                sl.SetCellValue("H2", date); sl.SetCellStyle("H2", stCenter);

                sl.SetCellValue("A4", "№");
                sl.SetCellValue("B4", "ФИО студента");
                sl.SetCellValue("C4", "Дата\nрождения");
                sl.SetCellValue("D4", "Форма\nобучения");
                sl.SetCellValue("E4", "Группа");
                sl.SetCellValue("F4", "Договор");
                sl.SetCellValue("G4", "Комната");
                sl.SetCellValue("H4", "Адрес");
                sl.SetCellValue("I4", "Паспортные данные (серия,№, кем и когда выдан)");
                sl.SetCellStyle(4, 1, 4, 9, stHeader);
                sl.AutoFitRow(4);

                int num = 0;
                var students = kv.OrderBy(s => s.SecondName);
                foreach (var st in students)
                {
                    num++;
                    int row = num + 4;
                    sl.SetCellValue(row, 1, num);
                    sl.SetCellValue(row, 2, st.FullName);
                    sl.SetCellValue(row, 3, st.BirthDate); sl.SetCellStyle(row, 3, stDate);
                    sl.SetCellValue(row, 4, st.IsBudget ? "Б" : "Д");
                    sl.SetCellValue(row, 5, st.Group);
                    sl.SetCellValue(row, 6, st.ContractNum);
                    sl.SetCellValue(row, 7, st.Room);
                    sl.SetCellValue(row, 8, st.Address);
                    sl.SetCellValue(row, 9, st.Passport);

                    sl.SetCellStyle(row, 4, row, 7, stCenter);
                }
                sl.SetCellStyle(4, 1, 4 + num, 9, stTable);

                sl.AutoFitColumn(1, 9);
                sl.FreezePanes(4, 2);

                firstSheet = false;
            }

            SLPageSettings ps = new SLPageSettings();
            ps.Orientation = OrientationValues.Landscape;
            sl.SetPageSettings(ps);
        }
    }
}
