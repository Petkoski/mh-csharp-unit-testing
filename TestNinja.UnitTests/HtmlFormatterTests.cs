using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            var formatter = new HtmlFormatter();
            var result = formatter.FormatAsBold("abc");

            //Specific assertion - veryfing the exact string we should get from the method (tests can break easily this way):
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);

            //More general
            /*Assert.That(result, Does.StartWith("<strong>"));

            //Better solution:
            Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("abc"));*/
        }
    }
}
