using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Libreriadll
{
    class Program
    {
        //[DllImport(@"c:\ClassLibrary.dll")]
        //private static extern int hola(string h);
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom("../../ClassLibrary1.dll");

            Type [] types = assembly.GetTypes();

            foreach(Type t in types)
            {
                Console.WriteLine("Nombre del tipo:" + t.Name);
                if(t.IsClass)
                {
                    Console.WriteLine("Es una clase");
                }
                PropertyInfo[] properties = t.GetProperties();
                MethodInfo[] methods = t.GetMethods();

                Console.WriteLine("Atributos: ");
                foreach (PropertyInfo property in properties)
                {
                    Console.WriteLine("Property Name: { 0}\n", property.Name);
                    Console.WriteLine("Property Type Name: {0}\n", property.PropertyType.Name);
                    Console.WriteLine("Property Type FullName: {0}\n", property.PropertyType.FullName);
                    Console.WriteLine("Can we read the property?: {0}\n", property.CanRead.ToString());
                    Console.WriteLine("Can we write the property?: {0}\n", property.CanWrite.ToString());
                    
                }

                Console.WriteLine("Metodos: ");

                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine("Method info: {0}\n", t.GetMethod(method.Name));
                }
            }
        }
    }
}
