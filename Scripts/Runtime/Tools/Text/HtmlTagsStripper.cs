using System.Text.RegularExpressions;

namespace Tools.Text
{
    public static class HtmlTagsStripper
    {
        private const string Pattern = @"<(.|\n)*?>";

        public static string StripHtml(string htmlString, string replacement = "")
        {
            return Regex.Replace(htmlString, Pattern, replacement);
        }
    }
}