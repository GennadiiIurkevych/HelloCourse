
var students = new List<Student> 
{ 
  new("Оля", 92), 
  new("Іван", 67), 
  new("Марія", 88), 
  new("Петро", 55)
  
};
var bestStudents = students.Where(s => s.Grade >= 60).OrderByDescending(s => s.Grade).Select(s => s.Name);
foreach (var student in bestStudents)
{
    Console.WriteLine(student);
}

public record Student(string Name, int Grade);
