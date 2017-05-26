using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Reports
{
    abstract class Report
    {
        protected SLDocument sl;

        static void PrepareFolder()
        {
            if (!Directory.Exists("reports"))
                Directory.CreateDirectory("reports");
        }

        public void Build()
        {
            PrepareFolder();

            var template = "templates/" + Template + ".xlsx";
            if (File.Exists(template))
                sl = new SLDocument(template);
            else
                sl = new SLDocument();

            try
            {
                Prepare();
                FillContent();

                var fileName = String.Format("reports/{0}_{1:ddMMyy_HHmmss}.xlsx", Template, DateTime.Now);
                sl.SaveAs(fileName);
                Process.Start(Path.GetFullPath(fileName));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                sl.Dispose();
                sl = null;
            }
        }

        protected virtual void Prepare()
        {
            //ReplaceCellValue("%PODR%", Settings.Default.Podrazd);
        }

        private void ReplaceCellValue(string from, string to)
        {
            foreach (var rows in sl.GetCells())
            {
                int row = rows.Key;
                foreach (var column in rows.Value)
                {
                    int col = column.Key;
                    var val = sl.GetCellValueAsString(row, col);
                    if (val.IndexOf(from) != -1)
                        sl.SetCellValue(row, col, val.Replace(from, to));
                }
            }
        }

        protected abstract void FillContent();

        protected abstract string Template { get; }
    }
}
