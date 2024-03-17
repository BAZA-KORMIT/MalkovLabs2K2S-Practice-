using System;
using System.Collections.Generic;

class Graph
{
    private int V; 
    private List<int>[] adj; 
   
    Graph(int v)
    {
        GraphCheck(v);
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; ++i)
            adj[i] = new List<int>();
    }

    void GraphCheck(int v)
    {
        if (v < 2 || v > 100)
        {
            Console.WriteLine("количество рёбер должно быть от 2 до 100");
            System.Environment.Exit(0);
        }
    }
   
    void addEdge(int v, int w)
    {
        addEdgeCheck(v, w);
        adj[v].Add(w);
        adj[w].Add(v);
    }

    void addEdgeCheck(int v,int w)
    {
        if (v > V - 1 || w > V - 1)
        {
            Console.WriteLine("номер ребра не может превышать количество ребёр в графе");
            System.Environment.Exit(0);
        }
    }
    bool isCyclicUtil(int v, bool[] visited,int parent)
    {        
        visited[v] = true;
        
        foreach (int i in adj[v])
        {          
            if (!visited[i])
            {
                if (isCyclicUtil(i, visited, v))
                    return true;
            }
            
            else if (i != parent)
                return true;
        }
        return false;
    }

    bool isTree()
    {
        bool[] visited = new bool[V];
        for (int i = 0; i < V; i++)
            visited[i] = false;

        if (isCyclicUtil(0, visited, -1))
            return false;

        for (int u = 0; u < V; u++)
            if (!visited[u])
                return false;

        return true;
    }

    public static void Main()
    {
        Graph g1 = new Graph(5);
        g1.addEdge(1, 0);
        g1.addEdge(0, 2);
        g1.addEdge(0, 3);
        g1.addEdge(3, 4);
        if (g1.isTree())
            Console.WriteLine("Graph is Tree");
        else
            Console.WriteLine("Graph is not Tree");

        Graph g2 = new Graph(5);
        g2.addEdge(1, 0);
        g2.addEdge(0, 2);
        g2.addEdge(2, 1);
        g2.addEdge(0, 3);
        g2.addEdge(3, 4);

        if (g2.isTree())
            Console.WriteLine("Graph is Tree");
        else
            Console.WriteLine("Graph is not Tree");

    }
}