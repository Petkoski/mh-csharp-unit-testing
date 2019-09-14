using NUnit.Framework;
using TestNinja.Fundamentals;
//using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestNinja.UnitTests
{
    [TestFixture] //[TestClass] & [TestMethod] belong to MSTest Framework.
    public class ReservationTests
    {
        /*
         * Test class naming convention:
         * ReservationTests
         * since here we are testing
         * TestNinja.Fundamentals.Reservation
         */

        /*
         * Test method naming convention:
         * public void Method_Scenario_ExpectedBehavior()
         * {Method} - Name of the method that we are testing (belongs to the class we are testing)
         * {Scenario} - Scenario name
         * {ExpectedBehavior} - What the method returns
         */
        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {
            //Inside every test method, we have 3 parts:
            // Arrange - initialize our objects, prepare the object we are testing
            var reservation = new Reservation();

            // Act - act on the initialized object (call some method)
            var result = reservation.CanBeCancelledBy(new User {IsAdmin = true});

            // Assert (assertion = tvrdenje)
            //Assert.IsTrue(result);
            //Assert.That(result == true);
            Assert.That(result, Is.True);

            //This convention is called - Tripple A or Arrange, Act & Assert

            /*
             * Test -> Run -> All Tests (no ability in VS to run only a single test)
             * Test -> Windows -> Test Explorer
             */
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancelling_ReturnsTrue()
        {
            var user = new User();
            var reservation = new Reservation { MadeBy = user };


            var result = reservation.CanBeCancelledBy(user);

            //Assert.IsTrue(result);
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnsFalse()
        {
            var user = new User();
            var reservation = new Reservation { MadeBy = new User() }; //Reservation made by some user

            var result = reservation.CanBeCancelledBy(new User()); //Cancelled by a DIFFERENT user object

            //Assert.IsFalse(result);
            Assert.That(result, Is.False);
        }
    }
}


/*
 * Test-driven development (TDD):
 * Development is driven by tests (test-first, in contrast to this is code-first).
 * 1. Write a failing test.
 * 2. Write the simplest code to make the test pass.
 * 3. Refactor if necessary.
 *
 * Benefits:
 * 1. Testable source code.
 * 2. Full coverage by tests.
 * 3. Simpler implementation.
 */
