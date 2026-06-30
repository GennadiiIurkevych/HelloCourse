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
    Console.WriteLine("\n");

selectedStudents = (from student in students  select student).OrderByDescending(student => student.Grade).ThenBy(student => student.Name);
foreach (var person in selectedStudents)
    Console.WriteLine($"{person.Name} - grade {person.Grade}");
    Console.WriteLine("\n");

var arithmeticMean = (from num in students select num.Grade).Sum()/students.Count;
    Console.WriteLine(arithmeticMean);
    Console.WriteLine("\n");

selectedStudents = (from person in students where person.Grade == students.Max(person => person.Grade) select person).OrderBy(student => student.Name); 
foreach (var student in selectedStudents)
    Console.WriteLine($"{student.Name} - grade {student.Grade}");
    Console.WriteLine("\n");

var groupGrade = from student in students group student by student.Grade; //продовжую працювати над цим
foreach (var person in selectedStudents)
    Console.WriteLine(person.Grade);
    Console.WriteLine("\n");
public record Student(string Name, double Grade);
