using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BenhVienOffline.Utils
{
    public static class StringUtils
    {
        // Remove diacritics (Vietnamese) and return ASCII equivalent
        public static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            var normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var ch in normalized)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                    sb.Append(ch);
            }
            var cleaned = sb.ToString().Normalize(NormalizationForm.FormC);
            // Replace special Vietnamese characters
            cleaned = cleaned.Replace('đ', 'd').Replace('Đ', 'D');
            return cleaned;
        }

        // Create an identifier from a name: remove diacritics, non-alphanumeric, and join words without spaces
        public static string ToIdentifier(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            var noDiacritics = RemoveDiacritics(text);
            var sb = new StringBuilder();
            foreach (var ch in noDiacritics)
            {
                if (char.IsLetterOrDigit(ch)) sb.Append(ch);
                // skip other characters (spaces, punctuation)
            }
            return sb.ToString();
        }
    }
}
