using System;
using System.Reflection;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassWithPrivateMethod target = new ClassWithPrivateMethod();

            ReflectionUtility utility = new ReflectionUtility();

            

           // utility.print("sumon");
            MethodInfo privMethod = utility.GetType().GetMethod("print", BindingFlags.NonPublic | BindingFlags.Instance);
            privMethod.Invoke(utility, new object[] {"sumon" });





            // utility.callPrivate(target, "print", new object[] { "hello world" });



        }
    }
}
