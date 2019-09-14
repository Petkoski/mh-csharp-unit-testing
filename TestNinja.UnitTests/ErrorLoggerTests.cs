using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            var logger = new ErrorLogger();

            logger.Log("my message");

            Assert.That(logger.LastError, Is.EqualTo("my message"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            var logger = new ErrorLogger();

            //logger.Log(error); //Throws an exception

            Assert.That(() => logger.Log(error), Throws.ArgumentNullException); //Wraping logger.Log() into a delegate when writing the assertion.
            //Assert.That(() => logger.Log(error), Throws.Exception.TypeOf<DivideByZeroException>());
        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var logger = new ErrorLogger();

            /*
             * To test method that raises an event:
             * Before ACTING, we must subscribe to the event.
             * The lambda expression expresses our event handler.
             * When the ErrorLogged event is raised, the lambda
             * function is executed.
             */
            var id = Guid.Empty;
            logger.ErrorLogged += (sender, args) => { id = args; };
            
            logger.Log("a"); //If the event is raised, the lambda function is executed meaning that id will no longer be empty.

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }

        //[Test]
        //public void OnErrorLogged_WhenCalled_RaiseAnEvent()
        //{
        //    var logger = new ErrorLogger();

        //    logger.OnErrorLogged(Guid.NewGuid());

        //    Assert.That(true);
        //}
    }
}
