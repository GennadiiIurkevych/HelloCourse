using System;
using System.Collections.Generic;
using System.Text;

namespace HelloCsharpCourseLearning
{
    internal class HashSet
    {
        static void Main()
        {
            HashSet<string> firstGroup = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Володимир",
                "Олена",
                "Тарас",
                "Iгор",
                "Юлiя",
                "Роман"
            };

            HashSet<string> secondGroup = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Вiкторiя",
                "Олена",
                "Захар",
                "Iгор",
                "Наталiя",
                "Анатолiй",
                "Олег"
            };

            HashSet<string> studentsGroups = new HashSet<string>(firstGroup);
            studentsGroups.IntersectWith(secondGroup);
            Console.WriteLine("В обох групах: " + string.Join(", ", studentsGroups));

            HashSet<string> studentsOnlyInFirstGroup = new HashSet<string>(firstGroup);
            studentsOnlyInFirstGroup.ExceptWith(secondGroup);
            Console.WriteLine("В обох групах: " + string.Join(", ", studentsOnlyInFirstGroup));

            HashSet<string> studentsUnique = new HashSet<string>(firstGroup);
            studentsUnique.UnionWith(secondGroup);
            Console.WriteLine("В обох групах: " + string.Join(", ", studentsUnique));
        }
    }
}
