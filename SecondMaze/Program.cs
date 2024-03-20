using System;
using System.Collections.Generic;

class Maze
{
    int[,] maze;
    int rows, cols;
    bool[,] visited;
    private List<List<string>> allPaths;

    public Maze(int[,] maze)
    {
        this.maze = maze;
        this.rows = maze.GetLength(0);
        this.cols = maze.GetLength(1);
        this.visited = new bool[rows, cols];
        allPaths = new List<List<string>>();
    }

    public void Solve()
    {
        DFS(0, 0, new List<string>());
        foreach (var path in allPaths)
        {
            Console.WriteLine("Путь: " + string.Join(" -> ", path));
        }
    }

    private void DFS(int row, int col, List<string> currentPath)
    {
        if (row < 0 || row >= rows || col < 0 || col >= cols)
            return;

        if (maze[row, col] == 0 || visited[row, col])
            return;

        if (row == rows - 1 && col == cols - 1)
        {
            currentPath.Add($"{row},{col}");
            allPaths.Add(new List<string>(currentPath)); // Добавляем найденный путь в список всех путей
            return;
        }

        visited[row, col] = true;
        currentPath.Add($"{row},{col}");

        // Рекурсивный вызов для каждого направления
        //DFS(row + 1, col, currentPath);
        //DFS(row - 1, col, currentPath);
        //DFS(row, col + 1, currentPath);
        //DFS(row, col - 1, currentPath);

        DFS(row + 1, col, new List<string>(currentPath));
        DFS(row - 1, col, new List<string>(currentPath));
        DFS(row, col + 1, new List<string>(currentPath));
        DFS(row, col - 1, new List<string>(currentPath));

        visited[row, col] = false;
        currentPath.RemoveAt(currentPath.Count - 1);
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
            {1, 1, 1, 1},
            {0, 1, 1, 0},
            {0, 1, 1, 1}
        };

        if (!Check(maze))
            return;
        Maze m = new Maze(maze);

        m.Solve();
           
    }
}
