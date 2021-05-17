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

        private int sum(int a,int b)
        {
            return a + b;

        }
    }
}
