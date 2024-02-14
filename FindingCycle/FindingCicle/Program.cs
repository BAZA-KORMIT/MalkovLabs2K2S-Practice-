﻿using System;

namespace FCG
{
    class Program
    {
        public enum Color { WHITE, GRAY, BLACK }

        public static int[,] graph = {
               { 0, 1, 1},
               { 0, 0, 1},
               {1, 1, 0}
        };
        public static int n = graph.GetLength(0);
        public static Color[] used = new Color[n];
        public static bool cycle;

        static void Main()
        {
            Console.WriteLine("diricted check: {0}", IsDirected());
            for (int i = 0; i < n; i++) // n - размерность матрицы
            {
                if (DFS(i, used))
                {
                    Console.WriteLine($"Цикл найден в вершине: {i+1}");
                    return;
                }
            }
            Console.WriteLine("В графе нет цикла.");
        }

        static bool DFS(int v, Color[] used) // v - текущая вершина
        {
            if (IsDirected())
            {
                used[v] = Color.GRAY;
                for (int i = 0; i < n; i++)
                    if (graph[v, i] != 0)
                    {
                        if (used[i] == Color.WHITE)
                            return DFS(i, used);
                        if (used[i] == Color.GRAY)
                            return true;
                    }
                used[v]= Color.BLACK;
                return false;
            }
            else
            {
                used[v] = Color.GRAY;
                for (int i = 0; i < n; i++)
                    if (graph[v, i] != 0)
                    {
                        if (used[i] == Color.WHITE)
                            return DFS(i, used);
                        if (used[i] == Color.GRAY && graph[i, v] == graph[v, i] && used[i] == used[v - 1])
                        {
                            continue;
                        }
                        if (used[i] == Color.GRAY)
                            return true;  
                    }
                used[v] = Color.BLACK;
                
                return false;
            }
        }

        public static bool IsDirected()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (graph[i, j] != 0 && graph[j, i] != 0)
                        return false;
            return true;
        }
    }
}