using Hostel.DB;
using Hostel.Model;
using System.Collections.Generic;
using System.Globalization;
using Word = Microsoft.Office.Interop.Word;

namespace Hostel.Reports
{
    static class FacReport
    {
        public static void Build()
        {
            var allStudents = Store.Inst.GetCurrentStudents();

            var ti = CultureInfo.CurrentCulture.TextInfo;

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc";

            // Запуск приложения
            var appl = new Word.Application();
            appl.Visible = true;

            // Создание документа
            var oDoc = appl.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;

            var isFirst = true;

            foreach (var faculty in Store.Inst.Faculties)
            {
                for (var i = 1; i <= 5; i++)
                {
                    var students = new List<Student>();
                    foreach (var st in allStudents)
                    {
                        if (st.Speciality != null && st.Speciality.Faculty == faculty && st.Year == i)
                        {
                            students.Add(st);
                        }
                    }

                    if (students.Count == 0) continue;

                    students.Sort(Student.CompareBySecondName);

                    Word.Range rngEnd;
                    if (!isFirst)
                    {
                        rngEnd = oDoc.Bookmarks[ref oEndOfDoc].Range;
                        rngEnd.InsertBreak(Word.WdBreakType.wdSectionBreakNextPage);
                    }

                    rngEnd = oDoc.Bookmarks[ref oEndOfDoc].Range;
                    var pFac = oDoc.Content.Paragraphs.Add(rngEnd);
                    pFac.Range.Font.Bold = 1;
                    pFac.Range.Font.Size = 20.0f;
                    pFac.Range.Text = faculty.Name;
                    pFac.Range.InsertParagraphAfter();

                    rngEnd = oDoc.Bookmarks[ref oEndOfDoc].Range;
                    var pYear = oDoc.Content.Paragraphs.Add(rngEnd);
                    pYear.Range.Font.Size = 16.0f;
                    pYear.Range.Text = i + " курс";
                    pYear.Range.InsertParagraphAfter();

                    rngEnd = oDoc.Bookmarks[ref oEndOfDoc].Range;
                    var tbl = oDoc.Content.Tables.Add(rngEnd, students.Count, 3);
                    tbl.Range.Font.Size = 14.0f;

                    // Включение границ
                    tbl.Borders.Enable = 1;
                    tbl.Borders.InsideColor = Word.WdColor.wdColorBlack;

                    // Высота строк
                    tbl.Rows.HeightRule = Word.WdRowHeightRule.wdRowHeightExactly;
                    tbl.Rows.Height = 22.0f;

                    // Ширина столбцов
                    tbl.Columns[1].Width = 300.0f;
                    tbl.Columns[2].Width = 50.0f;
                    tbl.Columns[3].Width = 50.0f;

                    for (var j = 0; j < students.Count; j++)
                    {
                        tbl.Cell(j + 1, 1).Range.Text = (j + 1).ToString() + ". " + students[j];

                        char db;
                        if (students[j].IsBudget)
                            db = 'б';
                        else
                            db = 'д';

                        tbl.Cell(j + 1, 2).Range.Text = db + " " + i.ToString();

                        tbl.Cell(j + 1, 3).Range.Text = students[j].Room;
                    }

                    isFirst = false;
                }
            }
        }
    }
}
