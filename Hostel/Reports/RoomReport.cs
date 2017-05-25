using Hostel.DB;
using Hostel.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using Word = Microsoft.Office.Interop.Word;

namespace Hostel.Reports
{
    static class RoomReport
    {
        public static void BuildAllRooms()
        {
            var rooms = new List<string>();
            foreach (var st in Store.Inst.GetCurrentStudents())
                if (!rooms.Contains(st.Room))
                    rooms.Add(st.Room);
            rooms.Sort(string.Compare);

            BuildRoomsReport(rooms);
        }

        public static void BuildRoomsReport(int level)
        {
            var levelStr = level.ToString();
            var rooms = new List<string>();
            foreach (var st in Store.Inst.GetCurrentStudents())
                if (st.Room.StartsWith(levelStr) && !rooms.Contains(st.Room))
                    rooms.Add(st.Room);
            rooms.Sort(string.Compare);

            BuildRoomsReport(rooms);
        }

        const int ROOM_ROW_COUNT = 4;

        static private void BuildRoomsReport(List<String> rooms)
        {
            var students = Store.Inst.GetCurrentStudents();

            var ti = CultureInfo.CurrentCulture.TextInfo;

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc";

            // Запуск приложения
            var appl = new Word.Application();
            appl.Visible = true;

            // Создание документа
            var oDoc = appl.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;
            oDoc.PageSetup.BottomMargin = 10;

            Word.Table tbl = null;

            var r = 1;
            for (var i = 0; i < rooms.Count; i++)
            {
                if (i % (2 * 5) == 0)
                {
                    r = 1;

                    var roomCount = rooms.Count - i; // Кол-во комнат на странице
                    if (roomCount > 10) roomCount = 10;

                    // Создание таблицы
                    var oRng = oDoc.Bookmarks[ref oEndOfDoc].Range;
                    //Word.Paragraph oP = oDoc.Content.Paragraphs.Add(ref oRng);
                    tbl = oDoc.Tables.Add(oRng, (int)Math.Round(roomCount / 2.0, MidpointRounding.AwayFromZero) * ROOM_ROW_COUNT, 4);
                    tbl.Rows.SetLeftIndent(-44.0f, Word.WdRulerStyle.wdAdjustNone);
                    //oP.Range.InsertBreak(Word.WdBreakType.wdLineBreak);
                    if (rooms.Count - i > 10)
                    {
                        oRng = oDoc.Bookmarks[ref oEndOfDoc].Range;
                        oRng.InsertBreak(Word.WdBreakType.wdPageBreak);
                    }

                    // Включение границ
                    tbl.Borders.Enable = 1;
                    tbl.Borders.InsideColor = Word.WdColor.wdColorBlack;

                    // Высота строк
                    tbl.Rows.HeightRule = Word.WdRowHeightRule.wdRowHeightExactly;
                    tbl.Rows.Height = 22.0f;

                    // Ширина столбцов
                    tbl.Columns[1].Width = 60.0f;
                    tbl.Columns[2].Width = 200.0f;
                    tbl.Columns[3].Width = 60.0f;
                    tbl.Columns[4].Width = 200.0f;
                }

                var c = 1 + (i % 2) * 2;

                var clRoom = tbl.Cell(r, c);
                clRoom.Merge(tbl.Cell(r + ROOM_ROW_COUNT - 1, c));
                clRoom.Range.Text = rooms[i];
                clRoom.Range.Font.Bold = 1;
                clRoom.Range.Font.Size = 22.0f;

                var sts = students.FindAll(s => s.Room == rooms[i]);
                sts.Sort(Student.CompareBySecondName);
                for (var j = 0; j < sts.Count && j < ROOM_ROW_COUNT; j++)
                {
                    var st = sts[j];
                    var text = ti.ToTitleCase((st.SecondName + " " + st.FirstName).ToLower()) + "  " + st.Year.ToString();
                    if (st.Speciality != null)
                        text += " " + st.Speciality.Faculty.Name.Substring(0, 1);

                    var clStudent = tbl.Cell(r + j, c + 1);
                    clStudent.Range.Text = text;
                    clStudent.Range.Font.Name = "Times New Roman";
                    clStudent.Range.Font.Size = 15.0f;
                }

                if (i % 2 == 1) r += ROOM_ROW_COUNT;
            }
        }
    }
}
