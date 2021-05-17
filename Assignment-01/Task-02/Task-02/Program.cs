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


             utility.callPrivate(target, "print", new object[] { "hello worlld" });
            // utility.callPrivate(target, "sum", new object[] { 12, 78 });
            utility.callProtected(target2, "print2", new object[] { "my name is sumon" });





        }
    }
}
