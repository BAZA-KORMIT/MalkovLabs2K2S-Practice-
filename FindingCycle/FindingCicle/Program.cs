using System;
using System.Collections.Generic;

namespace FCG
{
    class Program
    {
        public enum Color { WHITE, GRAY, BLACK }

        public static int[,] graph = {
               { 0, 1, 0, 0},
               { 0, 0, 1, 1},
               { 0, 0, 0, 1},
               { 0, 0, 0, 0}
        };
        public static int n = graph.GetLength(0);
        public static Color[] used = new Color[n];
        public static List<int> path = new List<int>();
        public static int[] previous = new int[n];
        public static bool directed;

        static void Main()
        {
            directed = IsDirected();
            Console.WriteLine("directed check: {0}", directed);
            if (directed )
                CycleD();
            else
                CycleND();
        }
        static void CycleD()
        {
            for (int i = 0; i < n; i++)
            {
                if (DFS(i, used))
                {
                    Console.WriteLine($"Цикл найден.");
                    Console.WriteLine("Путь цикла: " + string.Join(" -> ", path));
                    return;
                }
            }
            Console.WriteLine("В графе нет цикла.");
        }

        static void CycleND()
        {
            for (int i = 0; i < n; i++)
            {
                if (DFSND(i, used,-1))
                {
                    Console.WriteLine($"Цикл найден.");
                    Console.WriteLine("Путь цикла: " + string.Join(" -> ", path));
                    return;
                }
            }
            Console.WriteLine("В графе нет цикла.");
        }
        static bool DFS(int v, Color[] used) 
        {
            path.Add(v + 1);
            used[v] = Color.GRAY;
            for (int i = 0; i < n; i++)
            {
                if (graph[v, i] != 0)
                {
                    if (used[i] == Color.WHITE && DFS(i, used)) return true;
                    if (used[i] == Color.GRAY) { path.Add(i + 1); return true; }
                }
            }
            used[v] = Color.BLACK;
            path.RemoveAt(path.Count-1);
            return false;
        }

        static bool DFSND(int v, Color[] used,int parent)
        {
            path.Add(v + 1);
            used[v] = Color.GRAY;
            for (int i = 0; i < n; i++)
            {
                if (graph[v, i] != 0) 
                {
                    if (used[i] == Color.WHITE && DFSND(i, used,v)) return true;
                    if (used[i] == Color.GRAY && i!=parent) { path.Add(i + 1); return true; }
                }
            }
            used[v] = Color.BLACK;
            path.RemoveAt(path.Count - 1);
            return false;
        }
        public static bool IsDirected()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (graph[i, j]!=0 && graph[j, i]!= 0)
                        return false;
            return true;
        }
    }
}