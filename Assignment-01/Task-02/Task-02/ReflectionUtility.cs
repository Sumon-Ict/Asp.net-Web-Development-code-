using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    public class ReflectionUtility
    {


    
        public object callPrivate(object targetobject, string methodname, object[] args)
        {

            var mi = targetobject.GetType().GetMethod(methodname, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (mi != null)
            {
                return mi.Invoke(targetobject, args);
            }
            return null;




        }
        public object callProtected(object targetobject,string methodname, object[]  args)
        {
            var mi = targetobject.GetType().GetMethod(methodname, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (mi != null)
            {
                return mi.Invoke(targetobject, args);
            }
            return null;
        }

        





    }
}
