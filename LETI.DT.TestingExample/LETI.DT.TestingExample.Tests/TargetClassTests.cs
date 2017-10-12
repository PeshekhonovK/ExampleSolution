using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace LETI.DT.TestingExample.Tests
{
    [TestFixture]
    public class TargetClassTests
    {
        [Test]
        public void SimpleTest()
        {
            //Arrange
            var target = new TargetClass();
            var input = "input";

            //Act
            var result = target.GetResult(input);

            //Assert
            result.Should().Be("test: input");
        }

        [TestCase("input1", TestName = "case1")]
        [TestCase("input2", TestName = "case2")]
        public void CasesTest(string input)
        {
            //Arrange
            var target = new TargetClass();

            //Act
            var result = target.GetResult(input);

            //Assert
            result.Should().Be($"test: {input}");
        }

        private static IEnumerable<TestCaseData> cases
        {
            get
            {
                yield return new TestCaseData("input1").SetName("case1");
                yield return new TestCaseData("input2").SetName("case2");
            }
        }

        [TestCaseSource(nameof(cases))]
        public void DynamicCasesTest(string input)
        {
            //Arrange
            var target = new TargetClass();

            //Act
            var result = target.GetResult(input);

            //Assert
            result.Should().Be($"test: {input}");
        }
    }
}
