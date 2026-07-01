using System.Xml.Linq;

var students = new List<Student>
{
    new("Олег", 85),
    new("Юля", 92),
    new("Влад", 78),
    new("Аня", 92),
    new("Петро", 65),
};

var selectedStudents = (from person in students where person.Grade > 80 select person).OrderBy(person => person.Grade).ThenBy(person => person.Name);
foreach (var person in selectedStudents)
    Console.WriteLine($"{person.Name} - grade {person.Grade}");
    Console.WriteLine();

selectedStudents = (from student in students  select student).OrderByDescending(student => student.Grade).ThenBy(student => student.Name);
foreach (var person in selectedStudents)
    Console.WriteLine($"{person.Name} - grade {person.Grade}");
    Console.WriteLine();

var arithmeticMean = (from num in students select num.Grade).Sum()/students.Count;
    Console.WriteLine(arithmeticMean);
    Console.WriteLine();

selectedStudents = (from person in students where person.Grade == students.Max(person => person.Grade) select person).OrderBy(student => student.Name); 
foreach (var student in selectedStudents)
    Console.WriteLine($"{student.Name} - grade {student.Grade}");
    Console.WriteLine();

var groupGrade = (from person in students group person by person.Grade).OrderByDescending(student => student.Key);
foreach (var student in groupGrade)
{
    Console.WriteLine(student.Key);
    foreach (var person in student)
    {
        Console.WriteLine(person.Name);
    }
    Console.WriteLine();
}

public record Student(string Name, double Grade);

//Task8 - Відкладене виконання

/* Поясни що виведе цей код і чому -- до запуску:
 * 
var numbers = new List<int> { 1, 2, 3, 4, 5 };  //тут створюється джерело даних
var query = numbers.Where(x => x > 2);          //тут створюється запит

numbers.Add(6);                                 //додаємо елементи в джерело даних
numbers.Add(7);

foreach (var n in query)                        //тут виконуємо запит і отримуємо результати
    Console.WriteLine(n); */

/* 
 Відкладене виконання - один із способів реалізації LINQ-запитів, при цьому LINQ-вираз не виконується допоки
 не буде здійснено ітерацію, або перебірпо вибірці, наприклад у циклі foreach.
 Тому, в консоль виведеться: 3, 4, 5, 6, 7 так як 6 і 7 відповідають умовам Where, а перебір в циклі ми
 виконуємо після додавання елементів в колекцію.
*/

/*
 Що зміниться якщо додати .ToList() після Where(...)?
 Метод ToList() належить до методів негайного виконання LINQ-запитів. Методи, що реалізують негайне виконання
 виконуються одразу і повертають результат у вигляді колекцій Array, List, Dictionary, один елемент, атомарне значення.
 Тому, в консоль виведеться: 3, 4, 5 а додавані елементи даний метод не бачить
 */