using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Reflection;
using ClassLibrary1;

namespace Libreriadll
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pregunta1
            Address address = new Address();
            Person person = new Person();
            Car car = new Car();
            List<Type> types = new List<Type>(address.GetType(), person.GetType(), car.GetType());

            foreach (Type t in types)
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

            //Pregunta2
            // Esta pregunta no se puede hacer debido al error del bonus 1
            List <Person> personas = new List<Person>();
            List<Address> direcciones = new List<Address>();
            List<Car> autos = new List<Car>();
            while(true)
            {
                Console.WriteLine("1. Inscribir persona");
                Console.WriteLine("2. Inscribir propiedad");
                Console.WriteLine("3. Inscribir auto");
                Console.WriteLine("Seleccione una opcion: ");
                string a = Console.ReadLine();
                if (a == "1")
                {
                    Console.WriteLine("Ingrese Nombre: ");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese Apellido: ");
                    string apellido = Console.ReadLine();
                    Console.WriteLine("Fecha de Nacimiento: ");
                    DateTime cumpleaños = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Ingrese Rut: ");
                    string rut = Console.ReadLine();
                    Console.WriteLine("Ingrese Calle de recidencia: ");
                    string calle = Console.ReadLine();
                    Console.WriteLine("Ingrese Calle de recidencia: ");
                    int numero = Convert.ToInt32(Console.ReadLine());
                    Address c;
                    foreach (Address b in direcciones)
                    {
                        if (b.Street == calle & b.Number == numero)
                        {
                            c = b;
                        }
                    }
                    Console.WriteLine("Ingrese Rut padre: ");
                    string rutP = Console.ReadLine();
                    Console.WriteLine("Ingrese Rut Madre: ");
                    string rutM = Console.ReadLine();
                    Person m;
                    Person k;
                    foreach (Person p in personas)
                    {
                        if(p.Rut==rutP)
                        {
                            m = p;
                        }
                        if(p.Rut == rutM)
                        {
                            k = p;
                        }
                    }
                    Person p = new Person(nombre, apellido, cumpleaños, c, rut, m, k);
                    personas.Add(p);
                    //esto nunca se podra hacer debido al error del bonus 1

                }
            }
        }
    }
}
