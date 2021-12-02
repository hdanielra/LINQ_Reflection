using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public static class SintaxisLambda
    {
        // Secuence: un objeto que implementa IEnumerable
        // Element: elemmento de la secuence
        // Query Operator: método que transforma la secuence (secIN -> secSAL)
        // Query: expresión que cuando se enumera transforma la secuencia usando los operadores

        static int[] numeros = { 5, 4, 5, 2, 6, 8, 4, 9, 3, 6, 3, 10 };

        static string[] postres = { "postre de manzana",
                                 "pastel de chocolate",
                                 "manzana caramelizada",
                                 "fresas con crema"
            };

        public static void Pares()
        {
            // expresión lambda:
            //      n es el item que se está iterando (enumerando)
            //      cuando la expresión sea TRUE, tome ese elemento n
            IEnumerable<int> pares = numeros.Where(n => n % 2 == 0);

            Console.WriteLine("Pares con lambda:");
            foreach (int n in pares)
                Console.WriteLine(n);
        }

        internal static void SubQuery()
        {
            // ordenar por la última palabra de cada elemento
            // 1ro ejecuta el subquery: o sea la expresión lambda (toma la última palabra del elemento)
            // 2do ordena los postres: es como si para la ordenación tuviese en cuenta
            // un conjunto compuesto por la última palabra de cada elemento
            IEnumerable<string> res = postres.OrderBy(p => p.Split().Last());

            Console.WriteLine("Ordenar por la última palabra de cada elemento");
            foreach (string postre in res)
                Console.WriteLine(postre);

            Console.WriteLine("Lista números menores al primer registro");
            IEnumerable<int> nums = numeros
                .Where(n => n < numeros.First());
            foreach (int n in nums)
                Console.WriteLine(n);


            // 1 subquery: numeros pares, pero solo el primer número par encontrado (4)
            // 2 subquery: con el resultado anterior, se toman los elementos <= 
            Console.WriteLine("Lista números menores o igual al primer registro par que retorne el subquery");
            IEnumerable<int> nums2 = numeros
                .Where(n => n <= (numeros
                                    .Where(n2 => n2 % 2 == 0)
                                  ).First()
                      );

            foreach (int n in nums2)
                Console.WriteLine(n);
        }

        public static void FiltroTexto()
        {
            IEnumerable<string> encontrados = postres.Where(p => p.Contains("manzana"));
            foreach (string postre in encontrados)
                Console.WriteLine(postre);
        }
        public static void Operadores()
        {

            // Where: condición sea TRUE
            // Order by: un campo o valor de campo
            // Select: para campos específicos o modificados 
            IEnumerable<string> manzanas = postres
                .Where(p => p.Contains("manzana"))
                .OrderBy(p => p.Length)
                //.OrderBy(p => p.ToString())
                //.OrderByDescending(p => p.ToString()) 
                .Select(p => p.ToUpper());

            foreach (string postre in manzanas)
                Console.WriteLine(postre);
        }
        public static void OperadoresExtra()
        {

            // tomar los 5 primeros elementos
            Console.WriteLine("Primeros 5 elementos");
            IEnumerable<int> desdeInicio = numeros.Take(5);
            foreach (int n in desdeInicio)
                Console.WriteLine(n);

            // Saltar los 5 primeros elementos
            Console.WriteLine("Salta 5 elementos");
            IEnumerable<int> brinco = numeros.Skip(5);
            foreach (int n in brinco)
                Console.WriteLine(n);

            // Reversar elementos
            Console.WriteLine("Reversa elementos");
            IEnumerable<int> reverso = numeros.Reverse();
            foreach (int n in reverso)
                Console.WriteLine(n);

            // 1er elemento
            Console.WriteLine("1er elemento " + numeros.First());
            // últ elemento
            Console.WriteLine("Ult elemento " + numeros.Last());

            // encontrar x índice
            Console.WriteLine("Elemento en índice 3: {0}", numeros.ElementAt(3));
            // Contiene
            Console.WriteLine("Contiene 6: {0}", numeros.Contains(6));
            Console.WriteLine("Contiene 7: {0}", numeros.Contains(7));
            // Contiene algún elemento
            Console.WriteLine("Contiene algún elemento: {0}", numeros.Any());

            // Contiene algún elemento múltiplo de 5
            Console.WriteLine("Hay múltiplos de 5: {0}", numeros.Any(n => n % 5 == 0));
            Console.WriteLine("Hay múltiplos de 7: {0}", numeros.Any(n => n % 7 == 0));

            int valor = 2;
            IEnumerable<int> res = numeros.Where(n => n % valor == 0);
            valor = 3;
            // OJO que para la expresión lambda usa el últ valor o sea 3 (no 2)
            Console.WriteLine("Cambiando valor lambda");
            foreach (int n in res)
                Console.WriteLine(n);

        }


        public static void QueryProgresivo()
        {

        }


    }
}
