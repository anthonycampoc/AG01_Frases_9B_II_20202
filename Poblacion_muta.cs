using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG01_Frases_9B_II_2020
{
    class Poblacion_muta
    {
        private readonly List<string> individuos;// lista de individuos

        private readonly Random azar;

        public Poblacion_muta()
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
            Console.WriteLine("        Poblacion        ");
            Console.WriteLine("-------------------------");
            int pobla;
            for (pobla = 1; pobla<total_individuos; pobla++)
            {
                individuos.Add(objCadena.CadenaAzar(azar, cad_original.Length));
            }

            Console.WriteLine("-------------------------");
            Console.WriteLine("Total de Individuos / Poblacion Inicial " +  pobla);
            //procesos genetico
            //Console.WriteLine("        Seleccionados        ");
            for (int ciclo = 1; ciclo <= total_ciclos; ciclo++)
            {
                //tomar 2 individuos al azar
                int individuo_a = azar.Next(individuos.Count);
                int individuo_b = individuo_a; 

                //evaluar la adaptacion de los individuos, proceso de mutacion********
                int valor_individuo_a = objCadena.EvaluacionCadena(cad_original, individuos[individuo_a]);
                int valor_individuo_b = objCadena.EvaluacionCadena(cad_original, individuos[individuo_b]);

           

                // si individuo A esta mejor adaptado que B, entonces se elimina B, se copia A y se muta

                if (valor_individuo_a > valor_individuo_b){
                    individuos[individuo_b] = objCadena.MutaCadena(azar, individuos[individuo_a]);
                }
                else{
                    individuos[individuo_a] = objCadena.MutaCadena(azar, individuos[individuo_b]);
                    //Console.WriteLine("individuo A: " + individuos[individuo_a]);
                }
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

                if( valor_individuo > mejor_puntaje)
                {
                    mejor_individuos = cont;
                    mejor_puntaje = valor_individuo;

                    
                }
                if (individuos[cont] == cad_original)
                {
                    Console.WriteLine("-------------------------");
                    Console.WriteLine("-------MUTACION----------");
                    Console.WriteLine("-------------------------");
                    Console.WriteLine( " VALIDACION DE CADENA ENCONTRADA FIN DEL PROGRAMA " );
                    Console.WriteLine(cont + " .- " + individuos[cont]);
                    Console.ReadKey();
                }

                Console.WriteLine(cont + " .- " + individuos[cont]);
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine("-----MUTACION-----------");
            Console.WriteLine("-------------------------");
            Console.WriteLine("La posicion del individuo mejor adptado es: "+ mejor_individuos);
            return individuos[mejor_individuos];
        }
    }
}
