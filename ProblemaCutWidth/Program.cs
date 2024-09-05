using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaCutWidth
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Datos datos = new Datos();

            // Cargar los datos desde el archivo seleccionado
            datos.CargarDatos("datos2.txt");

            Console.WriteLine($"Cantidad Nodos: {datos.CNodos} , Cantidad Aristas: {datos.CAristas}\n");

            Console.WriteLine("Adyacencias: ");
            for (int i = 0; i < datos.CAristas; i++)
            {
                Console.Write($"{datos.Tuplas[i]} ");
            }
            Console.WriteLine("\n");

            datos.ImprimirMatriz();

            // Establecer la cantidad de muestras y combinaciones por muestra
            int numMuestras = 1000;
            int combinacionesPorMuestra = 3;

            Cutwidth objcutwidth = new Cutwidth();

            objcutwidth.Calcular_Cutwidth(numMuestras,combinacionesPorMuestra,datos.CNodos,datos.MatrizAdyacente);
        }
    }
}
