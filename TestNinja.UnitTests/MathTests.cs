using System.Linq;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class MathTests
    {
        /*
         * In NUnit we have 2 special attributes:
         * SetUp - decorate a method with this attribute, NUnit test runner will call it before running each test.
         * TearDown - NUnit test runner will call it after each test.
         */

        private Math _math;
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        //[Ignore("Because I wanted to!")]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            var result = _math.Add(3, 4);
            
            Assert.That(result, Is.EqualTo(7));
            //Assert.That(_math, Is.Not.Null);
        }

        //[Test]
        //public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        //{
        //    var result = _math.Max(5, 3);
        //    Assert.That(result, Is.EqualTo(5));
        //}
        //[Test]
        //public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        //{
        //    var result = _math.Max(3, 5);
        //    Assert.That(result, Is.EqualTo(5));
        //}
        //[Test]
        //public void Max_BothArgumentsAreEqual_ReturnTheSameArgument()
        //{
        //    var result = _math.Max(5, 5);
        //    Assert.That(result, Is.EqualTo(5));
        //}

        //Generic parametrized test method (instead of three separate test, which are same, except of the arguments passed)
        [Test]
        [TestCase(3, 5, 5)]
        [TestCase(5, 3, 5)]
        [TestCase(5, 5, 5)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_OddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(7);

            //Most general way:
            //Assert.That(result, Is.Not.Empty);

            //More specific:
            //Assert.That(result.Count(), Is.EqualTo(4));

            //Check for existance of certain items in the array
            //Assert.That(result, Does.Contain(1));
            //Assert.That(result, Does.Contain(3));
            //Assert.That(result, Does.Contain(5));
            //Assert.That(result, Does.Contain(7));

            //Cleaner way
            Assert.That(result, Is.EquivalentTo(new [] {1, 3, 5, 7})); //Compare the result to a newly created array (order does not matter)

            //Other useful assertions:
            //Assert.That(result, Is.Ordered);
            //Assert.That(result, Is.Unique);
        }
    }
}
