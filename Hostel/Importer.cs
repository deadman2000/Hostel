using System;
using System.Collections.Generic;
using Hostel.DB;
using Hostel.Model;
using SpreadsheetLight;

namespace Hostel
{
    static class Importer
    {
        public static void Import(string fileName)
        {
            var S = Store.Inst;
            S.CreateNewDataBase();
            using (var doc = new SLDocument(fileName))
            {
                var sheets = doc.GetSheetNames();
                foreach (var sheetName in sheets)
                {
                    if (sheetName.Equals("отчет")) continue;
                    Console.WriteLine(sheetName);
                    doc.SelectWorksheet(sheetName);

                    int row = 2;
                    while (true)
                    {
                        row++;

                        var room = doc.GetCellValueAsString(row, 2);
                        if (String.IsNullOrEmpty(room)) break;

                        var name = doc.GetCellValueAsString(row, 3);
                        if (String.IsNullOrEmpty(name)) continue;

                        var nameParts = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (nameParts.Length < 1) continue;

                        Student st = new Student
                        {
                            SecondName = nameParts[0],
                            FirstName = nameParts[1],
                            Patronymic = nameParts.Length > 2 ? nameParts[2] : "",
                            Room = room,
                            Year = 1,
                            IsActive = true,
                            IsRemoved = false
                        };

                        st.BirthDate = doc.GetCellValueAsDateTime(row, 4);
                        st.IsBudget = doc.GetCellValueAsString(row, 7).Equals("Б");
                        st.Address = doc.GetCellValueAsString(row, 8);
                        st.ContractNum = doc.GetCellValueAsInt32(row, 11);
                        S.Add(st);
                    }
                }
            }
        }
    }
}
