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
        public void Resolution_given_a_list_of_written_screen_resolution_returns_the_widths_and_heights_as_tuples()
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
        public void InnerText_given_the_following_HTML_and_tag_a_returns_the_inner_text_of_the_a_tags()
        {
            //Asign
            var inputHTML = "<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>";
            var inputTag = "a";
            //Act
            var output = RegExpr.InnerText(inputHTML,inputTag);
            
            //Assert
            Assert.Equal(new[] {
                "theoretical computer science",
                "formal language",
                "characters",
                "pattern",
                "string searching algorithms",
                "strings"
            }, output);
        }
        [Fact]
        public void InnerText_given_the_following_HTML_and_tag_p_returns_the_inner_text_of_the_p_tag()
        {
            //Asign
            var inputHTML = "<div><p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p></div>";
            var inputTag = "p";
            //Act
            var output = RegExpr.InnerText(inputHTML,inputTag);
            
            //Assert
            Assert.Equal(new[] {"The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."}, output);
        }
    }
}
