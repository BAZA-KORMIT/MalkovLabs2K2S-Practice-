using System;
using System.Collections.Generic;

class Maze
{
    int[,] maze;
    int rows, cols;
    bool[,] visited;

    public Maze(int[,] maze)
    {
        this.maze = maze;
        this.rows = maze.GetLength(0);
        this.cols = maze.GetLength(1);
        this.visited = new bool[rows, cols];
    }

    public bool Solve()
    {
        return DFS(0, 0);
    }

    private bool DFS(int row, int col)
    {
        if (row < 0 || row >= rows || col < 0 || col >= cols) 
            return false;
        if (maze[row, col] == 0) 
            return false;
        if (visited[row, col]) 
            return false;
        if (row == rows - 1 && col == cols - 1) 
            return true;
        visited[row, col] = true; 
        if (DFS(row + 1, col)) return true; 
        if (DFS(row - 1, col)) return true; 
        if (DFS(row, col + 1)) return true; 
        if (DFS(row, col - 1)) return true; 
        return false; 
    }
}
    
class Program
{
    static bool Check(int[,] maze)
    {
        int n = maze.GetLength(0);
        int m = maze.GetLength(1);
        if (maze[0, 0] == 0)
        {
            Console.WriteLine("Начало пути не может начинаться с нуля");
            return false;
        }
        if (maze[n - 1, m - 1] == 0)
        {
            Console.WriteLine("Конец пути не может являтся нулём(выхода нет)");
            return false;
        }
        return true;
    }
    static void Main(string[] args)
    {
        int[,] maze = new int[,] {
            {1, 1, 0, 1},
            {0, 1, 1, 1},
            {0, 0, 1, 0},
            {0, 0, 1, 1}
        };
        if (!Check(maze))
            return;
        Maze m = new Maze(maze);

        if (m.Solve())
            Console.WriteLine("Путь найден!");
        else
            Console.WriteLine("Путь не найден.");
    }
}
