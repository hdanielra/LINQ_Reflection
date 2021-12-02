using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public static class Conjuntos
    {

       static List<int> conjunto1 = new List<int> { 1, 2, 5, 2, 6, 8, 4, 9 };
       static List<int> conjunto2 = new List<int> { 1, 2, 5, 2, 5, 7, 4, 9 };


        public static void NoIntersectados()
        {
            // diferencia entre 2 contenedores (toma los datos de resultado del primer conjunto)
            var res = (from n1 in conjunto1 select n1).
                Except(from n2 in conjunto2 select n2);

            Console.WriteLine("Except: ");
            foreach (int n in res)
            {
                Console.WriteLine(n);
            }
        }

        public static void Intersectados()
        {
            // intercepción entre 2 contenedores 
            var res = (from n1 in conjunto1 select n1).
                Intersect(from n2 in conjunto2 select n2);

            Console.WriteLine("Intersect: ");
            foreach (int n in res)
            {
                Console.WriteLine(n);
            }
        }

        public static void Union()
        {
            // Unión 2 conjuntos (sin repetidos)
            var res = (from n1 in conjunto1 select n1).
                Union(from n2 in conjunto2 select n2);

            Console.WriteLine("Union: ");
            foreach (int n in res)
            {
                Console.WriteLine(n);
            }
        }

        public static void Concatenacion()
        {
            // Concatenar dos conjuntos (con repetidos)
            var res = (from n1 in conjunto1 select n1).
                Concat(from n2 in conjunto2 select n2);

            Console.WriteLine("Concat: ");
            foreach (int n in res)
            {
                Console.WriteLine(n);
            }
        }

        public static void Distintos()
        {

            // Concatenar dos conjuntos (con repetidos)
            var res = (from n1 in conjunto1 select n1).
                Concat(from n2 in conjunto2 select n2);


            Console.WriteLine("Distinct: ");
            foreach (int n in res.Distinct())
            {
                Console.WriteLine(n);
            }
        }


    }
}
