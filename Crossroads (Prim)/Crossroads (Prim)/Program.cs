using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossroads
{
    class Program
    {
        static void Main()
        {
            int crossroads = 5;
            int[] fare_amount = [9, 2, 6, 7, 9];
            int[,] graph = new int[,] {
                {0, 1, 1, 0, 0},
                {1, 0, 1, 1, 0},
                {1, 1, 0, 1, 1},
                {0, 1, 1, 0, 1},
                {0, 0, 1, 1, 0}
            };

            int cost = PrimAlg(graph, fare_amount, crossroads);

            Console.WriteLine($"Необходимо потратить {cost} русских долларов, чтобы до каждого перекрестка можно было бы доехать хотя бы из одного поста.");
        }

        static int PrimAlg(int[,] graph, int[] fare_amount, int crossroads)
        {
            bool[] inMST = new bool[crossroads]; //MST - Minimum spanning tree (отслеживает есть ли вершина в MST)
            int[] key = new int[crossroads]; // хранение веса ребра

            for (int i = 0; i < crossroads; i++)
            {
                key[i] = int.MaxValue;
                inMST[i] = false;
            }

            key[0] = fare_amount[0];
            int res = 0;

            for (int i = 0; i < crossroads; i++)
            {
                int u = MinKey(key, inMST, crossroads);
                inMST[u] = true;
                res += fare_amount[u];

                for (int j = 0; j < crossroads; j++)
                {
                    if (graph[u, j] != 0 && inMST[j] == false && graph[u, j] < key[j])
                    {
                        key[j] = graph[u, j];
                        fare_amount[j] = Math.Min(fare_amount[j], fare_amount[u]);
                    }
                }
            }

            return res;
        }

        //поиск наименьшего веса ребра, который уже находится в MST
        static int MinKey(int[] key, bool[] inMST, int crossroads)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int i = 0; i < crossroads; i++)
            {
                if (inMST[i] == false && key[i] < min)
                {
                    min = key[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }
    }
}
