using System;
using System.Reflection;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassWithPrivateMethod target = new ClassWithPrivateMethod();
            ClassWithProtectedMethod target2 = new ClassWithProtectedMethod();

            ReflectionUtility utility = new ReflectionUtility();

              //use of  private method 
             utility.callPrivate(target, "print", new object[] { "hello worlld" });

             utility.callPrivate(target, "sum", new object[] { 12, 78 });

            var result = utility.callPrivate(target, "sub", new object[] { 100, 23 });

            Console.WriteLine($"the subtraction of two value is {result}");




            // use of protected method 
            utility.callProtected(target2, "print2", new object[] { "my name is sumon" });

            utility.callProtected(target2, "multiply", new object[] { 78, 90 });

            var result2 = utility.callProtected(target2, "subtraction", new object[] { 123, 887 });

            Console.WriteLine($"the subtraction of  two value is {result2}");




        }
    }
}
