using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG01_Frases_9B_II_2020
{
    class Poblacion_cruce
    {
        private readonly List<string> individuos;// lista de individuos

        private readonly Random azar;

        public Poblacion_cruce()
        {
            individuos = new List<string>();
            azar = new Random();
        }

        //Proceso de Algoritmo Genetico

        public string Proceso(string cad_original, int total_individuos, int total_ciclos)
        {
            Cadena objCadena = new Cadena();

            //Crear la poblacion al azar

            Console.WriteLine("-------------------------");
            Console.WriteLine("    Poblacion Cruce      ");
            Console.WriteLine("-------------------------");
            int pobla;
            for (pobla = 1; pobla < total_individuos; pobla++)
            {
                individuos.Add(objCadena.CadenaAzar(azar, cad_original.Length));
            }

            Console.WriteLine("-------------------------");
            Console.WriteLine("Total de Individuos / Poblacion Inicial " + pobla);
            //procesos genetico
            //Console.WriteLine("        Seleccionados        ");
            for (int ciclo = 1; ciclo <= total_ciclos; ciclo++)
            {
                //tomar 2 individuos al azar
                int individuo_a = azar.Next(individuos.Count);
                int individuo_b;

                do
                {
                    individuo_b = azar.Next(individuos.Count);
                } while (individuo_a == individuo_b);//verificar que los individuos sean distintos 



                //evaluar la adaptacion de los individuos, proceso de cruce********

                int pos_Azar = azar.Next(cad_original.Length);

                string parte_A = individuos[individuo_a].Substring(0, pos_Azar);
                string parte_B = individuos[individuo_b].Substring(pos_Azar);

                string hijo = parte_A + parte_B;

                //Evaluacion de los padre e hijos, seleccionar el peor  o los peores padres

                int valor_individuo_a = objCadena.EvaluacionCadena(cad_original, individuos[individuo_a]);
                int valor_individuo_b = objCadena.EvaluacionCadena(cad_original, individuos[individuo_b]);
                int valor_hijo = objCadena.EvaluacionCadena(cad_original, hijo);

                if (valor_hijo > valor_individuo_a) individuos[individuo_a] = hijo;
                if (valor_hijo > valor_individuo_b) individuos[individuo_b] = hijo;


           
            }
            //Despues de los ciclos, se busca el mejor individuo

            int mejor_individuos = 0;
            int mejor_puntaje = 0;
            Console.WriteLine("-------------------------");
            Console.WriteLine("Ultima generacion de Individuos");
            Console.WriteLine("-------------------------");


            for (int cont = 1; cont < individuos.Count; cont++)
            {
                int valor_individuo = objCadena.EvaluacionCadena(cad_original, individuos[cont]);

                if (valor_individuo > mejor_puntaje)
                {
                    mejor_individuos = cont;
                    mejor_puntaje = valor_individuo;
                } 
                Console.WriteLine(cont + " .- " + individuos[cont]);
            }
            Console.WriteLine("La posicion del individuo mejor adptado es: " + mejor_individuos);
            return individuos[mejor_individuos];
        }
    }
}
