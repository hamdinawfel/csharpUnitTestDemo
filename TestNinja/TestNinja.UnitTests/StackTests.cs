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
        public void Push_NotNullObj_AddObjToList()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("abc");
            var result = stack.Count;
            Assert.Equal(1, result);
        }

        [Fact]
        public void Push_NullObj_ThrowsException()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.Throws<ArgumentNullException>(() => stack.Push(null));
        }

        [Fact]
        public void Pop_WithNotEmptyList_RemoveTheLastItemOfThatList()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            var result = stack.Pop();
            Assert.Equal("c", result);
        }

        [Fact]
        public void Pop_WithEmptyList_ThrowsInvalidOperationException()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.Throws<InvalidOperationException>(()=> stack.Pop());
        }

        [Fact]
        public void Peek_WithNotEmptyList_ReturnTheLastItemOfThatList()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            var result = stack.Peek();
            Assert.Equal("a", result);
        }

        [Fact]
        public void Peek_WithEmptyList_ThrowsInvalidOperationException()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }
    }
}
