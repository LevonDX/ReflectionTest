using System.Reflection;

namespace ReflectionTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // RTTI - runtime type information

            int arg = 100;
            string s = $"Sqrt({arg})";

            string methodName = s.Substring(0, s.IndexOf('('));

            // step 1: get type of class which method we are going to call
            Type t = typeof(Math);

            // step 2: find the method by name
            // MethodInfo? mi = t.GetOneParameterMethod(methodName);
            MethodInfo? mi = t.GetMethod(methodName, BindingFlags.NonPublic);

            if (mi == null)
            {
                Console.WriteLine($"Method {methodName} not found");
                return;
            }

            // step 3: call the method (via methodinfo class)
            // arguments of invoke:
            //  1) instance for which the method is being called (null for static methods)
            //  2) list of arguments of that method
            object? result = mi.Invoke(null, new object[] { arg });

            double? d = result as double?;

            Console.WriteLine(d);
        }
    }
}