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
    static class FacYearReport
    {
        public static void Build(Faculty fac)
        {
            if (fac == null) return;

            var facSt = Store.Inst.Students.Where(s => s.Speciality != null && s.Speciality.Faculty == fac);
            var byYear = facSt.GroupBy(s => s.Year).OrderBy(s => s.Key);

            string fileName = ReportUtils.GetFilePath("facyear_" + DateTime.Now.ToString("ddMMyy-HHmmss") + ".xlsx");

            bool firstSheet = true;
            var now = DateTime.Now;
            string date = String.Format("на \"{0}\" {1}", now.Day, now.ToString("MMMM yyyy"));

            SLStyle stDate = new SLStyle { FormatCode = "DD.MM.YYYY" };

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

            using (SLDocument sl = new SLDocument())
            {
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
                    sl.SetCellValue("H4", "Паспортные данные (серия,№, кем и когда выдан)");
                    sl.SetCellStyle(4, 1, 4, 9, stHeader);
                    sl.AutoFitRow(4);

                    int num = 0;
                    var students = kv.OrderBy(s => s.SecondName);
                    foreach (var st in students)
                    {
                        num++;
                        int row = num + 4;
                        sl.SetCellValue(row, 1, num);
                        sl.SetCellValue(row, 2, st.SecondName + " " + st.FirstName + " " + st.Patronymic);
                        sl.SetCellValue(row, 3, st.BirthDate); sl.SetCellStyle(row, 3, stDate); sl.SetCellStyle(row, 3, stCenter);
                        sl.SetCellValue(row, 4, st.IsBudget ? "Б" : "Д"); sl.SetCellStyle(row, 4, stCenter);
                        sl.SetCellValue(row, 5, st.Speciality.Name);
                        sl.SetCellValue(row, 6, st.ContractNum); sl.SetCellStyle(row, 6, stCenter);
                        sl.SetCellValue(row, 7, st.Room); sl.SetCellStyle(row, 7, stCenter);
                        sl.SetCellValue(row, 8, st.Address);
                    }
                    sl.SetCellStyle(4, 1, 4 + num, 9, stTable);

                    sl.AutoFitColumn(1, 9);
                    sl.FreezePanes(4, 2);

                    firstSheet = false;
                }

                SLPageSettings ps = new SLPageSettings();
                ps.Orientation = OrientationValues.Landscape;
                sl.SetPageSettings(ps);

                sl.SaveAs(fileName);
            }

            Process.Start(fileName);
        }
    }
}
