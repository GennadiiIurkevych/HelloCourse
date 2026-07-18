namespace Generic
{
    internal class GenericMethod
    {
        // Generic-метод Swap, що міняє місцями два значення
        static void Swap<T>(ref T arg, ref T contrarg)
        {
            /*Чи потрібний цей блок?
                if (arg == null && contrarg == null)  //перевірка на null для захисту від помилок при роботі з типом посилання
                    return;
            */

            // Тимчасова змінна для збереження першого значення
            T exchange = arg;
            arg = contrarg;
            contrarg = exchange;
        }
        static void Main(string[] args)
        {
            int num = 5, number = 10;
            Console.WriteLine($"До обмiну: num = {num}, number = {number}");
            Swap(ref num, ref number);
            Console.WriteLine($"Пiсля обмiну num = {num}, number = {number}");

            string slogan = "hello", word = "world";
            Console.WriteLine($"До обмiну: slogan = {slogan}, word = {word}");
            Swap(ref slogan, ref word);
            Console.WriteLine($"Пiсля обмiну slogan = {slogan}, word = {word}");



            var stack = new Stack<string>();

            stack.Push("apple");
            stack.Push("banana");
            stack.Push("orange");
            stack.Push("mango");

            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.IsEmpty);
            Console.WriteLine();
            Console.WriteLine(RawProduct.Deconstruct());

        }
    }
}

