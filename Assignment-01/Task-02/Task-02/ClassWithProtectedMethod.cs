using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
  public   class ClassWithProtectedMethod
    {
        protected void print(string value)
        {
            Console.WriteLine(value);

        }

        protected int sum(int a,int b)
        {
            return a + b;

        }

    }
}
