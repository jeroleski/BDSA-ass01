using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment1
{
    public static class RegExpr
    {
        public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
        {
            foreach (string line in lines)
            {
                var words = Regex.Split(line, @"[^a-zA-Z0-9]");
                foreach (string word in words)
                {
                    if (word != "")
                    {
                        yield return word;
                    }
                }
            }
        }
        
        public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions)
        {
            foreach(string line in resolutions)
            {
                foreach (Match m in Regex.Matches(line, @"(?<width>\d*)[x](?<height>\d*)"))
                {
                    var w = m.Groups["width"].Value;
                    var h = m.Groups["height"].Value;

                    yield return (Int32.Parse(w), Int32.Parse(h));
                }
            }
        }

        public static IEnumerable<string> InnerText(string html, string tag)
        {
            throw new NotImplementedException();
        }
    }
}
