using System;
using System.Collections.Generic;

class Maze
{
    private int[,] _maze;
    private int _rows, _cols;
    private bool[,] _visited;

    public Maze(int[,] maze)
    {
        this._maze = maze;
        this._rows = maze.GetLength(0);
        this._cols = maze.GetLength(1);
        this._visited = new bool[_rows, _cols];
    }

    public bool Solve() => DFS(0, 0);

    private bool DFS(int row, int col)
    {
        // проверка границ
        if (row < 0 || row >= _rows || col < 0 || col >= _cols || _maze[row, col] == 0 || _visited[row, col])
            return false;

        //проверка в конце мы или нет
        if (row == _rows - 1 && col == _cols - 1)
        {
            PrintPath(row, col);
            return true;
        }

        _visited[row, col] = true;

        //поиск пути
        if (DFS(row + 1, col) || DFS(row - 1, col) || DFS(row, col + 1) || DFS(row, col - 1))
        {
            PrintPath(row, col);
            return true;
        }

        _visited[row, col] = false;
        return false;
    }

    private static void PrintPath(int row, int col)
    {
        Console.Write("{0},{1} <- ", row, col);
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
    static void Main()
    {
        //0 - стена 1 - дорога
        int[,] maze = new int[,] {
            {1, 1, 0, 1},
            {0, 1, 1, 1},
            {0, 0, 1, 0},
            {0, 0, 1, 1}
        };
        if (!Check(maze))
            return;

        Maze m = new(maze);

        if (m.Solve())
            Console.WriteLine("Начало работы\nПуть найден!");
        else
            Console.WriteLine("Начало работы\nПуть не найден.");
    }
}