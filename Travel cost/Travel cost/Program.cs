using System;

namespace Travel_Cost
{
    class Program
    {
        static void Main()
        {
            int[,] G =
                {
                    { 0, 6, 0, 0, 0, 0, 0, 9, 0 },
                    { 6, 0, 9, 0, 0, 0, 0, 11, 0 },
                    { 0, 9, 0, 5, 0, 6, 0, 0, 2 },
                    { 0, 0, 5, 0, 9, 16, 0, 0, 0 },
                    { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                    { 0, 0, 6, 0, 10, 0, 2, 0, 0 },
                    { 0, 0, 0, 16, 0, 2, 0, 1, 6 },
                    { 9, 11, 0, 0, 0, 0, 1, 0, 5 },
                    { 0, 0, 2, 0, 0, 0, 6, 5, 0 }
                };
            DijkstraAlg(G, 1, G.GetLength(1));
        }

        static void DijkstraAlg(int[,] G, int startpoint, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPath = new bool[verticesCount];
            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPath[i] = false;
            }
            distance[startpoint] = 0;
            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPath, verticesCount);
                shortestPath[u] = true;
                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPath[v] && Convert.ToBoolean(G[u, v]) && distance[u] != int.MaxValue && distance[u] + G[u, v] < distance[v])
                        distance[v] = distance[u] + G[u, v];
            }
            Print(distance, verticesCount);
        }

        //Определение минимального пути
        static int MinimumDistance(int[] distance, bool[] shortestPath, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
                if (shortestPath[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }

            return minIndex;
        }

        static void Print(int[] distance, int verticesCount)
        {
            Console.WriteLine("Вершина    Расстояние от источника");
            for (int i = 0; i < verticesCount; ++i)
                Console.WriteLine("{0}\t  {1}", i, distance[i]);
        }

    }
}