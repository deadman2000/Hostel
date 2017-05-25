using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Reports
{
    static class ReportUtils
    {
        const string REPORTS_DIR = "reports";

        public static string GetFilePath(string fileName)
        {
            if (!Directory.Exists(REPORTS_DIR))
                Directory.CreateDirectory(REPORTS_DIR);
            return REPORTS_DIR + "\\" + fileName;
        }
    }
}
