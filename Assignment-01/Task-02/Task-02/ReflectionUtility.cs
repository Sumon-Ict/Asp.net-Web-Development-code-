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

            var methodinfo = targetobject.GetType().GetMethod(methodname, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (methodinfo != null)
            {
                return methodinfo.Invoke(targetobject, args);
            }
            return null;




        }
        public object callProtected(object targetobject,string methodname, object[]  args)
        {
            var methodinfo = targetobject.GetType().GetMethod(methodname, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (methodinfo != null)
            {
                return methodinfo.Invoke(targetobject, args);
            }
            return null;
        }

        





    }
}
