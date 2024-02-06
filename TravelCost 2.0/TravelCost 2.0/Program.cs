using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public class Graph
{
    private int Vertices;
    private List<int>[] adj;

    public Graph(int v)
    {
        Vertices = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; ++i)
            adj[i] = new List<int>();
    }

    static void Main()
    {
        int[] cost = { 0, 1, 2, 3, 4, 5 }; // стоимость посещения каждой вершины
        Graph g = new Graph(6); // количество вершин в графе
        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(1, 2);
        g.AddEdge(1, 3);
        g.AddEdge(2, 3);
        g.AddEdge(3, 4);
        g.AddEdge(4, 5);
        g.ShortestPath(0, cost);

    }

    public void AddEdge(int v, int w)
    {
        adj[v].Add(w);
    }

    public void ShortestPath(int src, int[] cost)
    {
        var dist = new int[Vertices];

        for (int i = 0; i < Vertices; i++)
            dist[i] = int.MaxValue;

        dist[src] = cost[src];

        var sptSet = new bool[Vertices];

        for (int count = 0; count < Vertices - 1; count++)
        {
            int u = MinimumDistance(dist, sptSet);

            sptSet[u] = true;

            for (int v = 0; v < Vertices; v++)
                if (!sptSet[v] && Convert.ToBoolean(adj[u].Contains(v)) && dist[u] != int.MaxValue && dist[u] + cost[v] < dist[v])
                    dist[v] = dist[u] + cost[v];
        }

        PrintSolution(dist);
    }

    private int MinimumDistance(int[] dist, bool[] sptSet)
    {
        int min = int.MaxValue, min_index = -1;

        for (int v = 0; v < Vertices; v++)
            if (sptSet[v] == false && dist[v] <= min)
            {
                min = dist[v];
                min_index = v;
            }

        return min_index;
    }

    private void PrintSolution(int[] dist)
    {
        Console.Write("Вершина     Дистанция\n");
        for (int i = 0; i < Vertices; ++i)
            Console.Write(i + " \t\t " + dist[i] + "\n");
    }
}

