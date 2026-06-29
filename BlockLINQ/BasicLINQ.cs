//string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };

//var selectedPeople = from p in people where p.ToUpper().StartsWith("T") orderby p select p; //спосіб операторів запиту LINQ
//var selectedPeople2 = people.Where(p => p.ToUpper().StartsWith("T")).OrderBy(p => p); //спосіб методів розширення LINQ

//foreach (var person in selectedPeople)
//    Console.WriteLine(person);
//foreach (var person in selectedPeople2)
//    Console.WriteLine(person);

var students = new List<Student>
{
    new("Олег", 85),
    new("Юля", 92),
    new("Влад", 78),
    new("Аня", 92),
    new("Петро", 65),
};
foreach (var person in students)
    Console.WriteLine($"{person.Name} - grade {person.Grade}");

var selectedStudents = from person in students where person.Grade > 80 select person;
foreach (var person in selectedStudents)
    Console.WriteLine($"\n{person.Name} - grade {person.Grade}");


selectedStudents = (from student in students  select student).OrderByDescending(student => student.Grade); //ще треба посортувати за іменем
foreach (var person in selectedStudents)
    Console.WriteLine($"\n{person.Name} - grade {person.Grade}");

var arithmeticMean = (from num in students select num.Grade).Sum()/students.Count; //ще треба перетворення типів
    Console.WriteLine(arithmeticMean);

/* selectedStudents = (from best in students select best).Max(best => best.Grade);  // треба допрацювати
Console.WriteLine($"\n{person.Name} - grade {person.Grade}"); */

record Student(string Name, int Grade);
