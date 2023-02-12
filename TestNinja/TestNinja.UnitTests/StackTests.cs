using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;
namespace TestNinja.UnitTests
{
    public class StackTests
    {
        [Fact]
        public void Push_NotNullObj_AddObjToStack()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("abc");
            var result = stack.Count;
            Assert.Equal(1, result);
        }

        [Fact]
        public void Push_AddNullObjToStack_ThrowArgumentNullException()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.Throws<ArgumentNullException>(() => stack.Push(null));
        }

        [Fact]
        public void Count_WithEmptyStack_ReturnZero()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Count_WithNotEmptyStack_Return1()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("abc");
            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Pop_WithNotEmptyStack_ReturnTheLastItemOfThatStack()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            var result = stack.Pop();
            Assert.Equal("c", result);
        }

        [Fact]
        public void Pop_WithNotEmptyStack_RemoveTheLastItemOfThatStack()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Pop();
            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Pop_WithEmptyStack_ThrowsInvalidOperationException()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.Throws<InvalidOperationException>(()=> stack.Pop());
        }

        [Fact]
        public void Peek_WithNotEmptyStack_ReturnTheLastItemOfThatStack()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            var result = stack.Peek();
            Assert.Equal("a", result);
        }

        [Fact]
        public void Peek_WithEmptyStack_ThrowsInvalidOperationException()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }
    }
}
