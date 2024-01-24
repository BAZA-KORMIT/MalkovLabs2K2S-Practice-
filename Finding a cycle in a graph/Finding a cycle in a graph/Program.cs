using System;

namespace FCG
{
    class Program
    {
        public enum Color { WHITE, GRAY, BLACK }
        
        public static int[,] graph = {
                {0,1,0},
                {1,0,1},
                {1,1,1}
        };
        public static int n = graph.GetLength(0);
        public static Color[] used = new Color[n];
        public static bool cycle;

        static void Main()
        {
            for (int i = 0;i<n; i++) // n - размерность матрицы
            {
               
                if (DFS(i ,used))
                {
                    Console.WriteLine("CYCLE");
                    return;
                }
            }
            Console.WriteLine("The End");
        }

        static bool DFS(int v, Color[] used) // v - текущая вершина
        {
            used[v] = Color.GRAY;
            for (int i =0;i<n;i++)
                if (graph[v,i]!=0)
                {
                    if (used[i] == Color.WHITE)
                        return DFS(i, used);
                    if (used[i] == Color.GRAY)
                        return true;
                }
            used[v] = Color.BLACK;
            return false;
        }
    }
}