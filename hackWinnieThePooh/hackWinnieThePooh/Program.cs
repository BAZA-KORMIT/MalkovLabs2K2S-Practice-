using System;

namespace WinniesPoohHack;

class Program
{
    static void Main()
    {
        int[] term_amount = { 900, 400, 500, 600, 10, 300 };
        int[,] Network = {
            { 0, 1, 1, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 0 },
            { 0, 0, 0, 1, 0, 0 },
            { 1, 0, 0, 0, 1, 0 },
            { 0, 0, 0, 0, 0, 1 },
            { 1, 1, 0, 0, 0, 0 }
        };

        int terms = AlgPrim(Network, term_amount, Network.GetLength(0));
        Console.WriteLine(terms);
    }

    static int AlgPrim(int[,] Network, int[] term_amount, int compCount)
    {
        bool[] inMST = new bool[compCount]; //MST - Minimum spanning tree (отслеживает есть ли вершина в MST)
        int[] key = new int[compCount]; // хранение кол-ва терминалов

        for (int i = 0; i < compCount; i++)
        {
            key[i] = int.MaxValue;
            inMST[i] = false;
        }

        key[0] = term_amount[0];
        int res = 0;

        for (int i=0; i< compCount; i++)
        {
            int u = MinKey(key, inMST, compCount);
            inMST[u] = true;
            res += term_amount[u];

            for (int j = 0; j < compCount; j++)
            {
                if (Network[u, j] != 0 && inMST[j] == false && Network[u, j] < key[j])
                {
                    key[j] = Network[u, j];
                    term_amount[j] = Math.Min(term_amount[j], term_amount[u]);
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

