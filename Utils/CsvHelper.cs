using System;
using System.Collections.Generic;
using System.IO;

namespace BenhVienOffline.Utils
{
    public static class CsvHelper
    {
        // Very small CSV parser: supports commas and quoted fields with double quotes escaping.
        public static IEnumerable<string[]> ReadAll(string path)
        {
            if (!File.Exists(path)) yield break;
            using (var sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    yield return ParseLine(line);
                }
            }
        }

        private static string[] ParseLine(string line)
        {
            var values = new List<string>();
            bool inQuotes = false;
            var cur = new System.Text.StringBuilder();
            for (int i = 0; i < line.Length; i++)
            {
                var c = line[i];
                if (inQuotes)
                {
                    if (c == '"')
                    {
                        // look ahead for escaped quote
                        if (i + 1 < line.Length && line[i + 1] == '"')
                        {
                            cur.Append('"');
                            i++; // skip next
                        }
                        else
                        {
                            inQuotes = false;
                        }
                    }
                    else
                    {
                        cur.Append(c);
                    }
                }
                else
                {
                    if (c == ',')
                    {
                        values.Add(cur.ToString());
                        cur.Clear();
                    }
                    else if (c == '"')
                    {
                        inQuotes = true;
                    }
                    else
                    {
                        cur.Append(c);
                    }
                }
            }
            values.Add(cur.ToString());
            return values.ToArray();
        }
    }
}
