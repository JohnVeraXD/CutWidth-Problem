using System;
using System.Collections.Generic;
using System.IO;


namespace ProblemaCutWidth
{
    internal class Datos
    {
        public int CNodos;
        public int CAristas;
        public int[,] MatrizAdyacente;
        public List<(int, int)> Tuplas { get; private set; }


        public void CargarDatos(string nomArchivo)
        {
            // Obtener la ruta completa al archivo en la carpeta 'datos'
            string Ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datos", nomArchivo);

            //Verifica si existe el archivo
            if (!File.Exists(Ruta))
            {
                Console.WriteLine("Archivo no encontrado: " + Ruta);
                return;
            }

            //Leer los datos con el separador de " "
            var lines = File.ReadAllLines(Ruta);
            var header = lines[0].Split(' ');

            //Leer la cantidad de nodos y aristas
            CNodos = int.Parse(header[0]);
            CAristas = int.Parse(header[2]);

            //Declaramos la matriz (con 0) y la tuplas
            MatrizAdyacente = new int[CNodos, CNodos];
            Tuplas = new List<(int, int)>();

            //Lee las aristas 
            for (int i = 1; i <= CAristas; i++)
            {
                var arista = lines[i].Split(' ');
                int node1 = int.Parse(arista[0]) - 1;
                int node2 = int.Parse(arista[1]) - 1;
                AggArista(node1, node2);
            }
        }

        //Almacena las aristas las matriz de ayacencia y la lista
        //Pone un 1 en las posiciones donde estan las aristas
        public void AggArista(int node1, int node2)
        {
            MatrizAdyacente[node1, node2] = 1;
            MatrizAdyacente[node2, node1] = 1;
            Tuplas.Add((node1, node2));
        }

        public void ImprimirMatriz()
        {
            Console.WriteLine("Matriz de Adyacencia:");
            for (int i = 0; i < CNodos; i++)
            {
                for (int j = 0; j < CNodos; j++)
                {
                    Console.Write(MatrizAdyacente[i, j] + " ");
                }
                Console.WriteLine(); 
            }
        }
    }
}
