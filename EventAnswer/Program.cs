using System;
using System.Collections.Generic;

namespace EventAnswer
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> IntStack = new MyStack<int>();
            StackEventSubscriber<int> stackEventSubscriber = new StackEventSubscriber<int>();
            IntStack.EventHandlerItemPushed += stackEventSubscriber.StackItemPushedEventHandler;
            IntStack.EventHandlerItemPopped += stackEventSubscriber.StackItemPoppedEventHandler;
            IntStack.push(5);
            IntStack.push(6);
            IntStack.push(7);
            IntStack.push(8);

            Console.WriteLine("After Push");
            IntStack.DisplayStack();

            IntStack.pop();
            IntStack.pop();
            IntStack.pop();
            Console.WriteLine("After Pop");
            IntStack.DisplayStack();

            IntStack.pop();
            IntStack.pop();
            IntStack.pop();
            Console.WriteLine("After Pop");
            IntStack.DisplayStack();
        }
    }
    public class MyStack<T>
    {
        List<T> StackItem = new List<T>();
        int _count = 0;

        public EventHandler<StackEventArgs<T>> EventHandlerItemPushed;
        public EventHandler<StackEventArgs<T>> EventHandlerItemPopped;

        public void push(T item)
        {
            StackItem.Add(item);
            _count++;
            OnPush(item);
        }
        public void pop()
        {
            if (_count > 0)
            {
                OnPop(StackItem[--_count]);
                StackItem.RemoveAt(_count);
            }
            else
                Console.WriteLine("No item to pop");
        }
        protected void OnPush(T item)
        {
            if (EventHandlerItemPushed != null)
                EventHandlerItemPushed(this, new StackEventArgs<T>(item));
        }
        protected void OnPop(T item)
        {
            if (EventHandlerItemPushed != null)
                EventHandlerItemPopped(this, new StackEventArgs<T>(item));
        }
        public void DisplayStack()
        {
            foreach (var item in StackItem)
            {
                Console.WriteLine(item);
            }
        }
    }
    public class StackEventSubscriber<T>
    {
        public void StackItemPushedEventHandler(object o, StackEventArgs<T> e)
        {
            Console.WriteLine($"Item pushed {e.item}");
        }
        public void StackItemPoppedEventHandler(object o, StackEventArgs<T> e)
        {
            Console.WriteLine($"Item popped {e.item}");
        }
    }
    public class StackEventArgs<T> : EventArgs
    {
        public T item { get; set; }
        public StackEventArgs(T item)
        {
            this.item = item;
        }
    }
}
