using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {

            //LinQ.EjemplosLinQ();
            //EjemploLinq();
            //EjemploSinIEnumerable();
            //EjemploLinqDiferenteTipos();
            //EjemploLinqDiferenteTiposObj();
            //EjemploProyeccion();
            //EjemploOperaciones();

            //Conjuntos.NoIntersectados();
            //Conjuntos.Intersectados();
            //Conjuntos.Union();
            //Conjuntos.Concatenacion();
            //Conjuntos.Distintos();

            //SintaxisLambda.Pares();
            //SintaxisLambda.FiltroTexto();
            //SintaxisLambda.Operadores();
            //SintaxisLambda.OperadoresExtra();
            //SintaxisLambda.SubQuery();
            SintaxisLambda.QueryProgresivo();
        }

        private static void EjemploOperaciones()
        {
            List<Estudiante> estudiantes = new List<Estudiante>()
            {
                new Estudiante("Ana","A1","Mercadeo",10.0),
                new Estudiante("Luis","A2","Programación",9.0),
                new Estudiante("Pedro","A3","Mercadeo",4.0),
                new Estudiante("María","A4","Matemáticas",7.0),
                new Estudiante("Laura","A5","Matemáticas",7.5),
            };


            //............................................
            // Máximo
            int[] numeros = { 1, 2, 5, 2, 6, 8, 4, 9 };
            var lista= from n in numeros select n;
            //int maximo = (from n in numeros select n).Max();

            Console.WriteLine("Máximo: " + lista.Max().ToString());
            Console.WriteLine("Mínimo: " + lista.Min().ToString());
            Console.WriteLine("Promedio: " + lista.Average().ToString());
            Console.WriteLine("Suma: " + lista.Sum().ToString());
            //............................................

            Console.WriteLine("---------------------");
            
            //............................................
            // Cuantos 
            int cantidad = (from e in estudiantes
                            where e.Promedio > 7
                            select e).Count();

            Console.WriteLine("Cantidad: " + cantidad.ToString());
            //............................................

            Console.WriteLine("---------------------");

            //............................................
            var aprobados = from e in estudiantes
                            where e.Promedio > 5
                            select e;
            Console.WriteLine("Aprobados:");
            foreach (Estudiante estudiante in aprobados)
            {
                Console.WriteLine(estudiante);
            }
            //............................................

            Console.WriteLine("---------------------");

            //............................................
            Console.WriteLine("Invertir Aprobados:");
            foreach (Estudiante estudiante in aprobados.Reverse())
            {
                Console.WriteLine(estudiante);
            }
            //............................................

            Console.WriteLine("---------------------");

            //............................................
            var ordenados = from e in estudiantes
                            orderby e.Promedio descending
                            select e;

            Console.WriteLine("Ordenados:");
            foreach (Estudiante estudiante in ordenados.Reverse())
            {
                Console.WriteLine(estudiante);
            }

        }
        private static void EjemploProyeccion()
        {
            List<Estudiante> estudiantes = new List<Estudiante>()
            {
                new Estudiante("Ana","A1","Mercadeo",10.0),
                new Estudiante("Luis","A2","Programación",9.0),
                new Estudiante("Pedro","A3","Mercadeo",4.0),
                new Estudiante("María","A4","Matemáticas",7.0),
                new Estudiante("Laura","A5","Matemáticas",7.5),
            };

            // solo los campos que necesitamos
            var nomProme = from e in estudiantes
                           select new { e.Nombre, e.Promedio };

            foreach (var np in nomProme)
            {
                Console.WriteLine(np.ToString());
            }
        }

        private static void EjemploLinqDiferenteTiposObj()
        {
            ArrayList estudiantes = new ArrayList()
            {
                new Estudiante("Ana","A1","Mercadeo",10.0),
                new Estudiante("Luis","A2","Programación",9.0),
                new Estudiante("Pedro","A3","Mercadeo",4.0),
                new Estudiante("María","A4","Matemáticas",7.0),
                new Estudiante("Laura","A5","Matemáticas",7.5),
            };

            // para poder usar LINQ es necesario que sea IEnumerable


            // tenemos que transformar el arraylist a un tipo que implemente
            // IEnumerable<T> para poder ser usado con LINQ
            var lstEst = estudiantes.OfType<Estudiante>();

            var reprobados = from e in lstEst
                             where e.Promedio <= 7.0
                             select e;

            Console.WriteLine("Reprobados");
            foreach (Estudiante estudiante in reprobados)
            {
                Console.WriteLine(estudiante);
            }
        }

        private static void EjemploLinqDiferenteTipos()
        {
            ArrayList lista = new ArrayList();
            lista.AddRange(
                new object[]
                { "hola", 5, 6.7, false, 4, 2, "saludos", 3.5, 3 }
                );


            // OfType():
            // tomar de la lista solo los de tipo INT:
            var enteros = lista.OfType<int>();


            foreach (int n in enteros)
                Console.WriteLine(n);


        }

        private static void EjemploSinIEnumerable()
        {
            //---------------------------------------------------
            Console.WriteLine(".................................");
            //---------------------------------------------------


            int[] numeros = { 1, 2, 5, 2, 6, 8, 4, 9, 1, 11, 5 };

            var valores = from n in numeros
                          where n % 2 == 0
                          select n;

            foreach (var v in valores)
                Console.WriteLine(v);

            InformacionxReflexion(valores);

            //---------------------------------------------------
            Console.WriteLine(".................................");
            Console.WriteLine("Ejecución diferida");
            //---------------------------------------------------


            // OJOOO: no es necesario volver a hacer la consulta...
            // los resultados en la variable valores se actualizan automáticamente
            numeros[1] = 100;

            foreach (var v in valores)
                Console.WriteLine(v);

            //---------------------------------------------------
            Console.WriteLine(".................................");
            Console.WriteLine("Ejecución inmediata");
            //---------------------------------------------------

            int[] array = (from n in numeros
                           where n % 2 == 0
                           select n).ToArray<int>();

            List<int> lista = (from n in numeros
                               where n % 2 == 0
                               select n).ToList<int>();

            Console.WriteLine("El arreglo:");
            foreach (var i in array)
                Console.WriteLine(i);

            // OJOOO: acá sí es necesario volver a hacer la consulta...
            // los resultados en la variable valores no se actualizan automáticamente
            numeros[0] = 28;
            Console.WriteLine("Se actualiza después de la modificación");
            foreach (var i in array)
                Console.WriteLine(i);

            Console.WriteLine("La lista:");
            foreach (var i in lista)
                Console.WriteLine(i);



        }

        private static void EjemploLinq()
        {
            //---------------------------------------------------
            Console.WriteLine(".................................");
            //---------------------------------------------------


            int[] numeros = { 1, 2, 5, 2, 6, 8, 4, 9 };

            IEnumerable<int> valores = from n in numeros
                                       where n > 3 && n < 8
                                       select n;

            foreach (int num in valores)
                Console.WriteLine(num);


            //---------------------------------------------------
            Console.WriteLine(".................................");
            //---------------------------------------------------


            string[] postres = { "postre de manzana",
                                 "pastel de chocolate",
                                 "manzana caramelizada",
                                 "fresas con crema"
            };

            IEnumerable<string> encontrados = from p in postres
                                              where p.Contains("manzana")
                                              orderby p descending
                                              select p;
            foreach (string postre in encontrados)
                Console.WriteLine(postre);

            //---------------------------------------------------
            Console.WriteLine(".................................");
            //---------------------------------------------------

            InformacionxReflexion(encontrados);

            //---------------------------------------------------
            Console.WriteLine(".................................");
            //---------------------------------------------------


        }

        static void InformacionxReflexion(object pResultados)
        {
            Console.WriteLine("Tipo {0}", pResultados.GetType().Name);
            Console.WriteLine("Locación {0}", pResultados.GetType().Assembly.GetName().Name);
        }
    }


    public class Estudiante
    {
        private string nombre;
        private string id;
        private string curso;
        private double promedio;

        public string Nombre { get => nombre; }
        public string Id { get => id; }
        public string Curso { get => curso; }
        public double Promedio { get => promedio; }


        public Estudiante(
            string pNombre,
            string pId,
            string pCurso,
            double pPromedio)
        {
            nombre = pNombre;
            id = pId;
            curso = pCurso;
            promedio = pPromedio;
        }

        public override string ToString()
        {
            //return base.ToString();
            return string.Format("N: {0}, {1}, C: {2}, P:{3}", nombre, id, curso, promedio);
        }
    }
}
