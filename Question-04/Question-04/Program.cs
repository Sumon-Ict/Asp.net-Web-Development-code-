using System;
using System.Collections.Generic;
namespace Question_04
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentnames =
                from SQ1 in list1
                join SQ2 in list2 on Student
             

                

                 
                

        }

        static List<Student> list1 = new List<Student>()
        {
            new Student{Name="sumon",Age=23},
            new Student{Name="sujon",Age=45},
            new Student{Name="suvo",Age=21 },
            new Student{Name="kajol",Age=34},
            new Student{Name="rashid",Age=32}

            
        };
        static List<Student> list2 = new List<Student>()
        {
             new Student{Name="suvo",Age=13},
            new Student{Name="kalam",Age=50},
            new Student{Name="marful",Age=26 },
            new Student{Name="Humayun",Age=30},
            new Student{Name="Imran",Age=35}
        };
    }
}
