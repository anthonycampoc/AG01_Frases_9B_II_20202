using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG01_Frases_9B_II_2020
{
    class Program
    {
        static void Main()
        {
            string cad_original = "Nuestras virtudes y nuestros defectos son inseparables, como la fuerza y la materia";
            string mejor_individuo;

            Stopwatch tiempo = new Stopwatch();
            tiempo.Start();

            Console.WriteLine("Ingrese el total de individuos");
            int total_individuos = Convert.ToInt32(Console.ReadLine());
           
            Console.WriteLine("Ingrese el total de ciclos");
            int total_ciclos= Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Elija que proceso de AG quiere ejecutar");
            Console.WriteLine("1.- Mutacion");
            Console.WriteLine("2.- Cruce");
            Console.WriteLine("3.- Mutacion y cruce");
          

            int opc = Convert.ToInt32(Console.ReadLine());
            if (opc == 1){
                Poblacion_muta objpoblacion = new Poblacion_muta();
                mejor_individuo = objpoblacion.Proceso(cad_original, total_individuos, total_ciclos);
               
            }
           else if (opc == 2){
                Poblacion_cruce objpoblacion = new Poblacion_cruce();
                mejor_individuo = objpoblacion.Proceso(cad_original, total_individuos, total_ciclos);
              
            }
            else if (opc == 3){
                Poblacion_cruce_muta objpoblacion = new Poblacion_cruce_muta();
                mejor_individuo = objpoblacion.Proceso(cad_original, total_individuos, total_ciclos);
                
            }

            else{
                mejor_individuo = "NO HAY PROCESOS";
            }



            Console.WriteLine(mejor_individuo);
          
            tiempo.Stop();
            Console.WriteLine("Tiempo de demora: {0}", tiempo.ElapsedMilliseconds);
            
            Console.ReadKey();
        }

    
    }
}
