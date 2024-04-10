using System;

namespace Chto_za_biznes;

class Program
{
    private static int N = 3; // Количество вышек
    private static int M = 4; // Количество заводов
    private static int[] a = { 3, 6, 7 }; // Производительность вышек
    private static int[] b = { 2, 5, 1, 8 }; // Производительность заводов
    private static int[,] c = { { 1, 2, 3, 4 }, { 8, 7, 6, 5 }, { 9, 12, 10, 11 } }; // Стоимость транспортировки
    private static int[,] _graph;
    private static int[,] _cost;
    private static int[] _parent;
    private static bool[] _visited;

    static void Main()
    {
        _graph = new int[N + M + 2, N + M + 2];
        _cost = new int[N + M + 2, N + M + 2];
        _parent = new int[N + M + 2];
        _visited = new bool[N + M + 2];

        //Метод для инициализации графа
        InitializeGraph();
        //Применение алгоритма для вычисления
        int maxFlow = MaxFlowLowCost(0, N + M + 1);

        Console.WriteLine("Общий объем перекачки: " + maxFlow);
    }

    static void InitializeGraph()
    {
        // два цикла for отвечают за связи источников с вышками и заводов с вышками
        for (int i = 0; i < a.Length; i++)
        {
            _graph[0, i + 1] = a[i];
            _cost[0, i + 1] = 0;
        }

        for (int i = 0; i < b.Length; i++)
        {
            _graph[N + 1 + i, N + M + 1] = b[i];
            _cost[N + 1 + i, N + M + 1] = 0;
        }

        // связь вышек и заводов с учетом цен
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                _graph[i + 1, N + 1 + j] = c[i, j];
                _cost[i + 1, N + 1 + j] = c[i, j]; // Предполагаем, что стоимость равна цене
            }
        }
    }

    // алгоритм эдмонса карпа
    static int MaxFlowLowCost(int _source, int sink)
    {
        int flow = 0;
        int cost = 0;
        while (BFS(_source, sink))
        {
            int pathFlow = int.MaxValue;
            int pathCost = 0;
            for (int v = sink; v!=_source; v = _parent[v])
            {
                int u = _parent[v];
                pathFlow = Math.Min(pathFlow, _graph[u,v]);
                pathCost += _cost[u, v];
            }

            for (int v = sink; v!=_source; v = _parent[v])
            {
                int u = _parent[v];
                _graph[u, v] -= pathFlow;
                _graph[v, u] += pathFlow;
            }
            flow += pathFlow;
            cost += pathFlow * pathCost;
        }
        Console.WriteLine("Общая стоимость: " + cost + " русских долларов.");
        return flow;
    }

    static bool BFS(int _source, int sink)
    {
        Array.Fill(_visited, false);
        var queue = new Queue<int>();
        queue.Enqueue(_source);
        _visited[_source] = true;
        _parent[_source] = -1;

        while (queue.Count > 0)
        {
            int u = queue.Dequeue();
            for (int v = 0; v < _graph.GetLength(0); v++)
            {
                if (!_visited[v] && _graph[u, v] > 0)
                {
                    queue.Enqueue(v);
                    _parent[v] = u;
                    _visited[v] = true;
                }
            }
        }

        return _visited[sink];
    }
}