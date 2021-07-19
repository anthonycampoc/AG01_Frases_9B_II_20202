using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG01_Frases_9B_II_2020
{
    class Cadena
    {
        // retornar un caracter al azarr

        private char LetraAzar(Random azar)
        {
            string Permitido = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ áéúíóúÁÉÍÓÚÑñ¿?¡!äëïöüÄËÏÖÜ";
            return Permitido[azar.Next(Permitido.Length)];
        }

        //Genera cadena al azar

        public string CadenaAzar(Random azar, int longitud)
        {
            string cadena = "";
            for(int cont = 1; cont <= longitud; cont++)
            {
                cadena += LetraAzar(azar).ToString();
            }
            Console.WriteLine(cadena);
            return cadena;
        }
        //Evaluacion / Adaptacion
        public int EvaluacionCadena(string cadena_a, string cadena_b)
        {
            int acum = 0;
            for(int cont = 0; cont < cadena_a.Length; cont++)
            {
                if (cadena_a[cont] == cadena_b[cont]) acum++;
            }

            return acum;
        }

        //Mutacion, toma una cadena y le cambia por un caracter al azar

        public string MutaCadena(Random azar, string cadena)
        {
            int pos = azar.Next(cadena.Length);
            char[] cambia = cadena.ToCharArray();
            cambia[pos] = LetraAzar(azar);//cambio de gen
            string nuevo = new string(cambia);
            return nuevo;

        }
       
    }
}
