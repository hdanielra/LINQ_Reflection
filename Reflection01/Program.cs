using System;

using System.Linq;
using System.Reflection;


namespace Reflection01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Type t = Type.GetType("System.Math");
            Type t = Type.GetType("System.Array");
            CaracteristicasTipo(t);
            EncuentraCampos(t);
            EncuentraPropiedades(t);
            EncuentraMetodos(t);
            EncuentraInterfaces(t);
        }


        public static void CaracteristicasTipo(Type t)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Las características que tiene son: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("La clase base: {0}", t.BaseType);
            Console.WriteLine("Es una clase: {0}", t.IsClass);
            Console.WriteLine("Abstracta: {0}", t.IsAbstract);
            Console.WriteLine("Sellada: {0}", t.IsSealed);
            Console.WriteLine("Genérica: {0}", t.IsGenericTypeDefinition);
        }

        public static void EncuentraCampos(Type t)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Los campos encontrados son: ");
            Console.ForegroundColor = ConsoleColor.White;

            var nombres = from f in t.GetFields()
                          select f.Name;

            foreach (var nombre in nombres)
            {
                Console.WriteLine("{0}", nombre);
            }
        }

        public static void EncuentraPropiedades(Type t)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Las propiedades encontradas son: ");
            Console.ForegroundColor = ConsoleColor.White;

            var nombres = from f in t.GetProperties()
                          select f.Name;

            foreach (var nombre in nombres)
            {
                Console.WriteLine("{0}", nombre);
            }
        }

        public static void EncuentraMetodos(Type t)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Los métodos encontrados son: ");
            Console.ForegroundColor = ConsoleColor.White;

            var nombres = from f in t.GetMethods()
                          select f.Name;

            foreach (var nombre in nombres)
            {
                Console.WriteLine("{0}", nombre);
            }
        }

        public static void EncuentraInterfaces(Type t)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Las interfaces encontradas son: ");
            Console.ForegroundColor = ConsoleColor.White;

            var nombres = from f in t.GetInterfaces()
                          select f.Name;

            foreach (var nombre in nombres)
            {
                Console.WriteLine("{0}", nombre);
            }
        }


    }
}
