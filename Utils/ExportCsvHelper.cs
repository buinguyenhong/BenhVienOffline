using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BenhVienOffline.Utils
{
    public static class ExportCsvHelper
    {
        public static void WriteLines(string path, IEnumerable<string> lines)
        {
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            File.WriteAllLines(path, lines, Encoding.UTF8);
        }

        public static string Escape(string value)
        {
            if (value == null) return string.Empty;
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n") || value.Contains("\r"))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }
            return value;
        }
    }
}
