using System;
using System.Collections.Generic;
using System.Text;

namespace HelloCourse
{
    class Block0
    {
        static int Add(int number, int addend)
        {
            return number + addend;
        }

        static string Greet(string Name)
        {
            return Name;
        }

        internal class Person
        {
            public string Name;
            public int Age;

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public void Introduce()
            {
                Console.WriteLine($"Hello, my name's {Name}, I'm {Age} years old");
            }
        }

        static void Main()
        {
            //Завдання 1:
            int num = 8;
            Console.WriteLine(num);

            string word = "Welcome";
            Console.WriteLine(word);

            string name = "Alex";
            Console.WriteLine(name);

            bool haveCat = false;
            Console.WriteLine(haveCat);

            double numWithPoint = 12.56;
            Console.WriteLine(numWithPoint);

            /*int number = null;  //Видається помилка, тому, що неможливо перетворити null у 'int' (або інший тип), оскільки це ненульований тип значення. 
                                  //У C# типи поділяються на типи посилань та типи значень. 
                                  //Типи посилань можуть вказувати на(порожньо / нічого).
                                  //Типи значень, однак, зберігають свої дані безпосередньо і завжди повинні мати дійсне значення.*/

            //Але, якщо ми поставимо знак ? після оголошення типу даних, то ми можемо присвоїти null:

            int? number = null;

            //Завдання 2:

            //int userInput = Convert.ToInt32(Console.ReadLine());
            int userInput = int.Parse(Console.ReadLine()); //ще один метод перетворення стрічки в числовий тип даних

            Console.WriteLine("You input " + userInput);

            if (userInput % 2 == 0)
                Console.WriteLine("This is an even number");
            else
                Console.WriteLine("This is an odd number");

            for (int i = 1; i <= userInput; i++)
            {
                Console.WriteLine(i);
            }

            int iter = 1;

            while (iter <= userInput)
            {
                Console.WriteLine(iter);
                iter++;
            }

            //Завдання 3:
            int sum = Add(4, 8);
            Console.WriteLine($"Total: {sum}");

            string firstName = Greet("Gennadii");
            Console.WriteLine(firstName);

            //Завдання 4:

            int[] numbers = { 4, 15, 7, 28, 3 };

            int maxInt = 4;

            for (int i = 1; i < numbers.Length; i++)

                if (maxInt < numbers[i])

                    maxInt = numbers[i];

            Console.WriteLine(maxInt);

            string[] List = { "John", "Alex", "July" };

            foreach (string names in List)

                Console.WriteLine(names);

            //Завдання 5:

            Person identPerson = new Person("Gennadii", 56);
            identPerson.Introduce();

            Person informPerson = new Person("Volodymyr", 24);
            Person anotherPerson = new Person("Max", 30);
            informPerson.Introduce();
            anotherPerson.Introduce();

        }
    }
}