using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest
{
    internal static class Extensions
    {
        public static MethodInfo? GetOneParameterMethod(this Type type, string methodName)
        {
            foreach (MethodInfo item in type.GetMethods())
            {
                if(item.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase) &&
                    item.GetParameters().Length == 1)
                    return item;
            }

            return null;
        }
    }
}
