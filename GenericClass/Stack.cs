//using System;
//using System.Linq;
//using System.Collections;
//using System.Collections.Generic;
//using System.Text;
//using System.ComponentModel.DataAnnotations;

//namespace GenericClass
//{
//    public class Stack<T>
//    {
//        private readonly List<T> fruits = new List<T>();

//        public void Push(T item) => fruits.Add(item);
//        public int Count => fruits.Count;

//        public T Pop()
//        {
//            if (fruits.Count == 0) /*(IsEmpty)*/
//            {
//                throw new InvalidOperationException("Stack is empty");
//            }

//            var item = fruits[^1];
//            fruits.RemoveAt(fruits.Count - 1);
//            return item;
//        }

//        public T Peek()
//        {
//            if (fruits.Count == 0) /*(IsEmpty)*/
//                throw new InvalidOperationException("Stack is empty");

//            return fruits[^1];
//        }
//        public bool IsEmpty() => fruits.Count == 0;

//        static void Main()
//        {
//            var stack = new Stack<string>();

//            stack.Push("apple");
//            stack.Push("banana");
//            stack.Push("orange");
//            stack.Push("mango");

//            Console.WriteLine(stack.Peek());
//            Console.WriteLine(stack.Pop());
//            Console.WriteLine(stack.Pop());
//            Console.WriteLine(stack.IsEmpty);

//        }
//    }
//}

//namespace GenericClass
//{
//    internal class GenericMethod
//    {
//        // Generic-метод Swapз, що міняє місцями два значення
//        static void Swap<T>(ref T arg, ref T contrarg)
//        {
//            /*Чи потрібний цей блок?
//                if (arg == null && contrarg == null)  //перевірка на null для захисту від помилок при роботі з типом посилання
//                    return;
//            */

//            // Тимчасова змінна для збереження першого значення
//            T exchange = arg;
//            arg = contrarg;
//            contrarg = exchange;
//        }
//        static void Main(string[] args)
//        {
//            int num = 5, number = 10;
//            Console.WriteLine($"До обмiну: num = {num}, number = {number}");
//            Swap(ref num, ref number);
//            Console.WriteLine($"Пiсля обмiну num = {num}, number = {number}");

//            string slogan = "hello", word = "world";
//            Console.WriteLine($"До обмiну: slogan = {slogan}, word = {word}");
//            Swap(ref slogan, ref word);
//            Console.WriteLine($"Пiсля обмiну slogan = {slogan}, word = {word}");
//        }
//    }
//}


namespace GenericClass
{
    public class Stack<T>
    {
        private List<T> _items = new List<T>();

        // Додати елемент на вершину
        public void Push(T item)
        {
            _items.Add(item);
        }

        // Забрати елемент з вершини
        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек порожній.");

            int lastIndex = _items.Count - 1;
            T item = _items[lastIndex];
            _items.RemoveAt(lastIndex);
            return item;
        }

        // Подивитись елемент на вершині без видалення
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек порожній.");

            return _items[_items.Count - 1];
        }

        // Перевірка, чи стек порожній
        public bool IsEmpty => _items.Count == 0;

        static void Main()
        {
            var stack = new Stack<srting>();

            stack.Push("apple");
            stack.Push("banana");
            stack.Push("mango");
            stack.Push("orange");

            Console.WriteLine(stack.Peek()); // 30
            Console.WriteLine(stack.Pop());  // 30
            Console.WriteLine(stack.Pop());  // 20
            Console.WriteLine(stack.IsEmpty); // False
        }
    }
}