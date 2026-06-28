using System;
using System.Collections.Generic;
using System.Text;

namespace Generic
{
    internal class Stack<T>
    {
        private readonly List<T> fruits = new List<T>();

        public void Push(T item) => fruits.Add(item);
        
        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");

            var item = fruits[^1];
            fruits.RemoveAt(fruits.Count - 1);
            return item;
            
        }
        public int Count => fruits.Count;

        // Подивитись елемент на вершині без видалення
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");

            return fruits[^1];
        }

        // Перевірка, чи стек порожній
        public bool IsEmpty => fruits.Count == 0;
    }
}
