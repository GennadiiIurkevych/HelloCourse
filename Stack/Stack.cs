
namespace Stack
{
    internal class Stack<T>
    {
        private readonly List<T> fruits = new List<T>();

        public void Push(T item) => fruits.Add(item);
        public int Count => fruits.Count;

        public T Pop()
        {
            if (fruits.Count == 0) /*(IsEmpty)*/
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var item = fruits[^1];
            fruits.RemoveAt(fruits.Count - 1);
            return item;
        }

        public T Peek()
        {
            if (fruits.Count == 0) /*(IsEmpty)*/
                throw new InvalidOperationException("Stack is empty");

            return fruits[^1];
        }
        public bool IsEmpty() => fruits.Count == 0;
        static void Main(string[] args)
        {
            var stack = new Stack<T>();

            stack.Push(string "apple");
            stack.Push("banana");
            stack.Push("orange");
            stack.Push("mango");

            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.IsEmpty);
        }
    }
}
