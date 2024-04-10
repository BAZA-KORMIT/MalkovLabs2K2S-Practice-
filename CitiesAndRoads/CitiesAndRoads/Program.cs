using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace CitiesAndRoads;

public class RoadsAndCities
{
    private static int[,] _adjMatrix;
    private static bool[] _visited;

    public static int FindComponents(int n, Tuple<int, int>[] edges)
    {
        _adjMatrix = new int[n + 1, n + 1];


        foreach (var edge in edges)
        {
            _adjMatrix[edge.Item1,edge.Item2] = 1;
            _adjMatrix[edge.Item2,edge.Item1] = 1;
        }

        _visited = new bool[n + 1];
        int components = 0;

        for (int i = 1; i <= n; i++)
        {
            if (!_visited[i])
            {
                DFS(i);
                components++;
            }
        }
        return components - 1;
    }

    private static void DFS(int i)
    {
        _visited[i] = true; 
        //Console.WriteLine("Посещена вершина " + i); 
        for (int j = 0; j < _adjMatrix.GetLength(1); j++)
        {
            if (_adjMatrix[i, j] == 1 && !_visited[j])
            {
                DFS(j);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        int N = 6; 
        Tuple<int, int>[] edges = {
            Tuple.Create(1, 2),
            Tuple.Create(1, 3),
            Tuple.Create(4, 5),
        };

        Console.WriteLine($"Минимальное количество новых дорог: {RoadsAndCities.FindComponents(N, edges)}");
    }
}