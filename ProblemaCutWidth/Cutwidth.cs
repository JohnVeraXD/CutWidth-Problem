using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaCutWidth
{
    internal class Cutwidth
    {
        Combinaciones objCombi = new Combinaciones();
        private List<int> mejorcombinacion; //almacenar la mejor combinación
        public void Calcular_Cutwidth(int numMuestras, int combinacionesPorMuestra, int CNodos , int[,] MatrizAdyacente) {

            // Iniciar el cronómetro
            Stopwatch tiempo = new Stopwatch();
            tiempo.Start();

            int minCutWidth = int.MaxValue;
            int mejorMuestra = 0;

            mejorcombinacion = new List<int>();

            for (int muestra = 1; muestra <= numMuestras; muestra++)
            {
                Console.WriteLine($"\n--------------------------------Muestra {muestra}-----------------------------");

                var combinaciones = objCombi.GenerarPermuAle(Enumerable.Range(0, CNodos).ToList(), combinacionesPorMuestra);

                int minimoCutWidthMuestra = int.MaxValue;
                var mejorcombinacionMuestra = new List<int>(); // Almacena la mejor combinación de esta muestra

                for (int numeroCombinacion = 1; numeroCombinacion <= combinaciones.Count; numeroCombinacion++)
                {
                    var combinacion = combinaciones[numeroCombinacion - 1];
                    Console.WriteLine($"  Interación {numeroCombinacion}: {string.Join(", ", combinacion.Select(x => x + 1))}");
                    int maxCutWidth = 0;

                    for (int i = 1; i < combinacion.Count; i++)
                    {
                        int corte = 0;
                        for (int j = 0; j < i; j++)
                        {
                            for (int k = i; k < combinacion.Count; k++)
                            {
                                if (MatrizAdyacente[combinacion[j], combinacion[k]] == 1)
                                {
                                    corte++;
                                }
                            }
                        }
                        Console.WriteLine($"    = Corte: {i} , (Aristas cortadas): {corte}");
                        if (corte > maxCutWidth)
                        {
                            maxCutWidth = corte;

                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine($"  Maximo Corte calculado de la interación {numeroCombinacion}: {maxCutWidth}");
                    Console.WriteLine(new string('-', 50));

                    if (maxCutWidth < minimoCutWidthMuestra)
                    {
                        minimoCutWidthMuestra = maxCutWidth;
                        mejorcombinacionMuestra = new List<int>(combinacion); // Guardar la combinación actual
                    }
                }

                Console.WriteLine($"Minimo CutWidth de la muestra {muestra} : {minimoCutWidthMuestra}\n");
                //Console.WriteLine(new string('-', 100));

                if (minimoCutWidthMuestra < minCutWidth)
                {
                    minCutWidth = minimoCutWidthMuestra;
                    mejorMuestra = muestra;
                    mejorcombinacion = new List<int>(mejorcombinacionMuestra);
                }
            }

            // Detener el cronómetro
            tiempo.Stop();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new string('-', 100));
            Console.WriteLine("\n----------------------Mejor CutWidth encontrado:----------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nMinimo CutWidth encontrado es : {minCutWidth} de la muestra: {mejorMuestra}");
            Console.WriteLine($"De la Combinacion:  {string.Join(", ", mejorcombinacion.Select(x => x + 1))}");

            Imprimir_Cortes_Mejor( MatrizAdyacente);

            Console.WriteLine($"\nTiempo: {tiempo.Elapsed.TotalSeconds} segundo(s).\n");

            Console.ReadLine();
        }

        private void Imprimir_Cortes_Mejor(int[,] MatrizAdyacente)
        {
            Console.WriteLine("Cortes de la combinacion");
            for (int i = 1; i < mejorcombinacion.Count; i++)
            {
                int corte = 0;
                for (int j = 0; j < i; j++)
                {
                    for (int k = i; k < mejorcombinacion.Count; k++)
                    {
                        if (MatrizAdyacente[mejorcombinacion[j], mejorcombinacion[k]] == 1)
                        {
                            corte++;
                        }
                    }
                }
                Console.WriteLine($"  Corte {i} , (Aristas cortadas): {corte}");
            }
        }
    }

}
