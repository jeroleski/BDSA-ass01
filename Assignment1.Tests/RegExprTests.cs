using Xunit;
using System.Collections.Generic;

namespace Assignment1.Tests
{
    public class RegExprTests
    {
        [Fact]
        public void SplitLine_Given_hej_Kaj_and_Huset_sta2r_p0a_marken_and_10_6_45_returns_hej_Kaj_Huset_sta2r_p0a_marken_10_6_45()
        {
            //Asign
            List<string> stream = new List<string>(new[] {"hej Kaj", "Huset-sta2r._p0a/marken", "/10, .&6_45."});

            //Act
            var output = RegExpr.SplitLine(stream);
            
            //Assert
            Assert.Equal(new[] {"hej", "Kaj", "Huset", "sta2r", "p0a", "marken", "10", "6", "45"}, output);
        }

        [Fact]
        public void t2()
        {
            //Asign
            List<string> stream = new List<string>(new[] {
                "1920x1080", 
                "1024x768, 800x600, 640x480", 
                "320x200, 320x240, 800x600", 
                "1280x960"});

            //Act
            IEnumerable<(int width, int height)> output = RegExpr.Resolution(stream);
            
            //Assert
            Assert.Equal(new[] {
                (1920, 1080),
                (1024, 768),
                (800, 600),
                (640, 480),
                (320, 200),
                (320, 240),
                (800, 600),
                (1280, 960)}, output);
        }

        [Fact]
        public void t3()
        {
            //Asign


            //Act
            //var output = RegExpr.Resolution();
            
            //Assert
            //Assert.Equal(, output);
        }
    }
}
