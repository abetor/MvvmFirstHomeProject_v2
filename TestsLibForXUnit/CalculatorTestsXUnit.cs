using LibForTestImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestsLibForXUnit
{
    public class CalculatorTestsXUnit
    {
        [Fact]
        public void AddShouldReturnSumOfValues()
        {
            var calculator = new Calculator();
            var result = calculator.Add(2, 3);
            Assert.Equal(5, result);
        }
    }
}
