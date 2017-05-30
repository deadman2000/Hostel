using DocumentFormat.OpenXml.Spreadsheet;
using Hostel.DB;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Reports
{
    class SettlingReport : Report
    {
        protected override string Template => "settling";

        protected override void FillContent()
        {
            sl.SetCellValue(1, 1, "№ комн.");
            sl.SetCellValue(1, 2, "ФИО студента");
            sl.SetCellValue(1, 3, "Дата рождения");
            sl.SetCellValue(1, 4, "Уровень\nВО/СПО");
            sl.SetCellValue(1, 5, "Группа,\nкурс");
            sl.SetCellValue(1, 6, "Осн\nова");
            sl.SetCellValue(1, 7, "Место проживания");
            sl.SetCellValue(1, 8, "Оплата");
            sl.SetCellValue(1, 9, "Прим.,\nльгота");
            sl.SetCellValue(1, 10, "Договор");

            int row = 1;
            var byRoom = Store.Inst.Students.OrderBy(s => s.Room);
            foreach (var st in byRoom)
            {
                row++;
                sl.SetCellValue(row, 1, st.Room);
                sl.SetCellValue(row, 2, st.FullName);
                sl.SetCellValue(row, 3, st.BirthDate.ToShortDateString());
                sl.SetCellValue(row, 4, st.FacultyName);
                sl.SetCellValue(row, 5, st.Group + " " + st.Year);
                sl.SetCellValue(row, 6, st.IsBudget ? "Б" : "Д");
                sl.SetCellValue(row, 7, st.Address);
                sl.SetCellValue(row, 8, ""); // Оплата
                sl.SetCellValue(row, 9, ""); // Прим. льгота
                sl.SetCellValue(row, 10, st.ContractNum);
            }

            // Вся таблица
            SLStyle stAll = new SLStyle();
            stAll.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            stAll.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            stAll.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            stAll.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            stAll.Font.FontName = "Times New Roman";
            stAll.Font.FontSize = 11;
            stAll.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            sl.SetCellStyle(1, 1, row, 10, stAll);

            // Шапка
            sl.SetCellStyle(1, 1, 1, 10, new SLStyle
            {
                Font = new SLFont
                {
                    FontName = "Times New Roman",
                    FontSize = 9,
                    Bold = true
                },
                Alignment = new SLAlignment
                {
                    Horizontal = HorizontalAlignmentValues.Center,
                    WrapText = true
                }
            });

            // По колонкам
            sl.SetCellStyle(2, 1, row, 1, new SLStyle
            {
                Font = new SLFont
                {
                    FontName = "Times New Roman",
                    FontSize = 11,
                    Bold = true
                }
            });
            sl.SetCellStyle(2, 2, row, 2, new SLStyle
            {
                Alignment = new SLAlignment
                {
                    Horizontal = HorizontalAlignmentValues.Left,
                }
            });

            sl.SetRowHeight(1, 25.0);
            sl.AutoFitColumn(1, 11);
        }
    }
}
