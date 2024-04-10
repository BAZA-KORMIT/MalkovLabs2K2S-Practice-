using System;

namespace Chto_za_biznes;

class Program
{
    static void Main()
    {
        int N = 2; // Количество вышек
        int M = 2; // Количество заводов
        int[] a = { 10000, 20000 }; // Производительность вышек
        int[] b = { 15000, 15000 }; // Производительность заводов
        int[,] c = { { 500, 900 }, { 600, 700 } }; // Стоимость транспортировки

        // Создание графа
        int[,] graph = new int[N + M + 2, N + M + 2];

        // Инициализация графа
        for (int i = 0; i < a.Length; i++)
        {
            graph[0, i + 1] = a[i]; // Связь источника с вышками
        }

        for (int i = 0; i < b.Length; i++)
        {
            graph[N + 1 + i, N + M + 1] = b[i]; // Связь заводов со стоком
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                graph[i + 1, N + 1 + j] = int.MaxValue; // Максимальная пропускная способность
            }
        }


    }

    //static bool CanConnect(int i, int j) => a[i] <= b[j];
    //static int GetPrice(int i, int j) => c[i, j];

    static void MaxFlowLowCost()
    {
       
    }
}