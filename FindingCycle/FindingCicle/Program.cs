using System;
using System.Collections.Generic;

namespace FCG
{
    class Program
    {
        public enum Color { WHITE, GRAY, BLACK }

        public static int[,] graph = {
               { 0, 1, 0, 0},
               { 0, 0, 1, 0},
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
            for (int i = 0; i < n; i++) // n - размерность матрицы
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

        static bool DFS(int v, Color[] used) // v - текущая вершина
        {
            path.Add(v + 1);
            used[v] = Color.GRAY;
            for (int i = 0; i < n; i++)
            {
                if (directed)
                {
                    if (graph[v, i] != 0)
                    {
                        if (used[i] == Color.WHITE) return DFS(i, used);
                        if (used[i] == Color.GRAY) { path.Add(i + 1);return true; }
                    }
                }
                else
                {
                    if (graph[v, i] != 0)
                    {
                        if (used[i] == Color.WHITE) { previous[i] = v; return DFS(i, used); }
                        if (used[i] == Color.GRAY && graph[i, v] == graph[v, i] && used[i] == used[v - 1]) continue;
                        if (used[i] == Color.GRAY && previous[v] != i) { path.Add(i + 1); return true; }
                    }
                }
            }
            used[v] = Color.BLACK;
            path.RemoveAt(path.Count-1);
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