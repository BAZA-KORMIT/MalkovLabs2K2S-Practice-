using System;
using System.Collections.Generic;

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
            {0, 1, 1, 0},
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

    private bool DFS(int _row, int _col)
    {
        // проверка границ
        if (_row < 0 || _row >= _rows || _col < 0 || _col >= _cols || _maze[_row, _col] == 0 || _visited[_row, _col])
            return false;

        //проверка в конце мы или нет
        if (_row == _rows - 1 && _col == _cols - 1)
        {
            PrintPath(_row, _col);
            return true;
        }

        _visited[_row, _col] = true;

        //поиск пути
        if (DFS(_row + 1, _col) || DFS(_row - 1, _col) || DFS(_row, _col + 1) || DFS(_row, _col - 1))
        {
            PrintPath(_row, _col);
            return true;
        }

        _visited[_row, _col] = false;
        return false;
    }

    private static void PrintPath(int row, int col)
    {
        Console.Write("{0},{1} <- ", row, col);
    }
}
    
