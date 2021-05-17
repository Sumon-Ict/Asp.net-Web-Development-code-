using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
  public   class ClassWithProtectedMethod
    {
        protected void print2(string value)
        {
            Console.WriteLine(value);

        }

       protected void multiply(int a,int b)
        {
            var mul = a * b;

            Console.WriteLine($"the multiplication of two integer value is {mul}");

        }

        protected int subtraction(int a,int b)
        {
            return a - b;
        }
            

    }
}
