using Xunit;
using System;
using System.Collections.Generic;

namespace Assignment1.Tests
{
    public class IteratorsTests
    {
        [Fact]
        public void Flatten_Given_1_2_and_3_4_returns_1_2_3_4()
        {
            //Arrenge
            List<List<int>> stream = new List<List<int>>();
            stream.Add(new List<int>(new[] {1, 2}) );
            stream.Add(new List<int>(new[] {3, 4}) );
            
            //Act
            var output = Iterators.Flatten<int>(stream);
            
            //Assert
            Assert.Equal(new[] {1, 2, 3, 4}, output);
        }

        [Fact]
        public void Filter_Given_1_2_3_4_5_6_7_and_Mod3_returns_3_6()
        {
            //Arrenge
            List<int> stream = new List<int>(new[] {1,2, 3, 4, 5, 6, 7});

            bool Mod3(int i) => i % 3 == 0;
            Predicate<int> pred = Mod3;
            
            //Act
            var output = Iterators.Filter<int>(stream, pred);
            
            //Assert
            Assert.Equal(new[] {3, 6}, output);
        }
    }
}
