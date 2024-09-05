using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaCutWidth
{
    class Combinaciones
    {
        //Genera una lista con las permutaciones aleatorias
        public List<List<int>> GenerarPermuAle(List<int> lista, int cantidad)
        {
            var combinaciones = new List<List<int>>();
            var random = new Random();

            // Generar X(cantidad) permutaciones aleatorias
            for (int i = 0; i < cantidad; i++)
            {
                combinaciones.Add(GenerarCombiAle(new List<int>(lista), random));
            }

            return combinaciones;
        }

        //Genera la combinacion 
        private List<int> GenerarCombiAle(List<int> lista, Random random)
        {
            var resultado = new List<int>();

            while (lista.Count > 0)
            {
                //Genera una valor random de la cantidad de elementos de la lista.
                int index = random.Next(lista.Count);
                resultado.Add(lista[index]);
                lista.RemoveAt(index);
            }

            return resultado;
        }
    }
}
