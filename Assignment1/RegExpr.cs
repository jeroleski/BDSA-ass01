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
        
        public static void Main(String[] args)
        {
            //Asign
            List<string> stream = new List<string>(new[] {
                "1920x1080", 
                "1024x768, 800x600, 640x480", 
                "320x200, 320x240, 800x600", 
                "1280x960"});

            //Act
            IEnumerable<(int width, int height)> output = RegExpr.Resolution(stream);
        }
        public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions)
        {
            foreach(string line in resolutions)
            {
                Match m = Regex.Match(line, @"(?<width>\d*)[x](?<height>\d*)");
                while (m.Success)
                {
                    var w = m.Groups["width"].Value;
                    var h = m.Groups["hight"].Value;

                    Console.WriteLine(w + "     " + h);
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
