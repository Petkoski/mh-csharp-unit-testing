using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class StackTests
    {
        [Test]
        public void Push_ArgumentIsNull_ThrowArgumentNullException()
        {
            var stack = new Stack<string>();

            Assert.That(() => { stack.Push(null); }, Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ValidArgument_AddTheObjectToTheStack()
        {
            var stack = new Stack<string>();

            stack.Push("a");

            Assert.That(stack.Count, Is.EqualTo(1)); //Simplest way to verify that the object is added to the stack.
        }

        /*
         * Because the Count method in Stack class has logic (line 10 in Stack.cs),
         * we are writing separate test cases just for it (testing its correctness).
         */
        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            var stack = new Stack<string>();

            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Stack<string>();

            Assert.That(() => { stack.Pop(); }, Throws.InvalidOperationException);
        }

        /*
         * Because 2 actions are done when Pop() method is called, we need 2 test cases. 
         */
        [Test]
        public void Pop_StackWithAFewObjects_ReturnObjectOnTheTop()
        {
            //Arrange:
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            //Act:
            var result = stack.Pop();

            //Assert:
            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Pop_StackWithAFewObjects_RemoveObjectOnTheTop()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            stack.Pop();

            Assert.That(stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peak_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Stack<string>();

            Assert.That(() => { stack.Peek(); }, Throws.InvalidOperationException);
        }

        [Test]
        public void Peak_StackWithAFewObjects_ReturnObjectOnTopOfTheStack()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Peek();

            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Peak_StackWithAFewObjects_DoesNotRemoveTheObjectOnTopOfTheStack()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            stack.Peek();

            Assert.That(stack.Count, Is.EqualTo(3));
        }
    }
}
