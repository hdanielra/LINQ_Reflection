using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class LinQ
    {
        public static void EjemplosLinQ()
        {
            int[] numeros = { 1, 2, 5, 2, 6, 8, 4, 9, 10, 0, 5, 1 };

            //ListarTodos(numeros);
            //Listar2y5(numeros);
            ListarComplejo();
        }

        private static void ListarTodos(int[] numeros)
        {
            IEnumerable<int> lst = from d in numeros
                                   orderby d
                                   select d;

            foreach (var n in lst)
                Console.WriteLine(n);
        }
        private static void Listar2y5(int[] numeros)
        {
            IEnumerable<int> lst = from d in numeros
                                   where d == 2 || d == 5
                                   orderby d
                                   select d;

            foreach (var n in lst)
                Console.WriteLine(n);
        }

        private static void ListarComplejo()
        {
            Complejo[] lst =
            {
                new Complejo(2,"patito"),
                new Complejo(555,"diablito"),
                new Complejo(6,"perro"),
                new Complejo(10,"ave"),
                new Complejo(66,"foca")
            };

            var oLst = (from d in lst
                        where d.Cadena == "diablito"
                        select d).FirstOrDefault();

            Console.WriteLine(oLst.Imprime());


            var oLst2 = from d in lst
                        orderby d.Numero
                        select d;

            foreach (var d in oLst2)
                Console.WriteLine(d.Imprime());
        }
    }

    public class Complejo
    {
        public int Numero { get; set; }
        public string Cadena { get; set; }

        public Complejo(int numero, string cadena)
        {
            Numero = numero;
            Cadena = cadena;
        }

        public string Imprime()
        {
            return Numero + " " + Cadena;
        }
    }
}
