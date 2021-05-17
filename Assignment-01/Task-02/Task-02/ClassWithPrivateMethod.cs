using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
   public  class ClassWithPrivateMethod
    {

       private void print(string value)
        {
            Console.WriteLine(value);

        }

      private void sum(int a,int b)
        {
            var result = a + b;

            Console.WriteLine($"the sum of two integer value is {result}");

        }

        private int sub(int a,int b)
        {
            return a - b;
        }
    }
}
