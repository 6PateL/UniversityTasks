using System;
using System.Collections.Generic;
using System.IO;

class Dijkstra
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Виберіть спосіб введення графа:");
            Console.WriteLine("1 - Вручну");
            Console.WriteLine("2 - З файлу");
            Console.WriteLine("3 - Рандомно");
            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();

            int[,] adjacencyMatrix;

            switch (choice)
            {
                case "1":
                    adjacencyMatrix = InputGraphManually();
                    break;
                case "2":
                    Console.Write("Введіть шлях до файлу: ");
                    string filePath = Console.ReadLine();
                    adjacencyMatrix = ReadGraphFromFile(filePath);
                    break;
                case "3":
                    Console.Write("Введіть кількість вершин: ");
                    int vertices = int.Parse(Console.ReadLine());
                    adjacencyMatrix = GenerateRandomGraph(vertices);
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    continue;
            }

            Console.WriteLine("Граф у початковому поданні:");
            PrintMatrix(adjacencyMatrix);

            Console.Write("Введіть стартову вершину (0 - {0}): ", adjacencyMatrix.GetLength(0) - 1);
            int startVertex = int.Parse(Console.ReadLine());
            DijkstraAlgorithm(adjacencyMatrix, startVertex);

            Console.WriteLine("Хочете повторити спробу? (так/ні)");
            string repeat = Console.ReadLine();
            if (repeat.ToLower() != "так")
            {
                break;
            }
        }
    }

    static int[,] InputGraphManually()
    {
        Console.Write("Введіть кількість вершин: ");
        int vertices = int.Parse(Console.ReadLine());
        int[,] adjacencyMatrix = new int[vertices, vertices];

        for (int i = 0; i < vertices; i++)
        {
            for (int j = 0; j < vertices; j++)
            {
                Console.Write($"Введіть вагу ребра від вершини [{i}] до вершини [{j}] (0, якщо ребра немає): ");
                adjacencyMatrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        return adjacencyMatrix;
    }

    static int[,] ReadGraphFromFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        int vertices = int.Parse(lines[0]);
        int[,] adjacencyMatrix = new int[vertices, vertices];

        for (int i = 1; i <= vertices; i++)
        {
            var values = lines[i].Split(' ');
            for (int j = 0; j < values.Length; j++)
            {
                adjacencyMatrix[i - 1, j] = int.Parse(values[j]);
            }
        }

        return adjacencyMatrix;
    }

    static int[,] GenerateRandomGraph(int vertices)
    {
        var random = new Random();
        int[,] adjacencyMatrix = new int[vertices, vertices];

        for (int i = 0; i < vertices; i++)
        {
            for (int j = 0; j < vertices; j++)
            {
                if (i == j)
                {
                    adjacencyMatrix[i, j] = 0;
                }
                else
                {
                    adjacencyMatrix[i, j] = random.Next(0, 20); 
                }
            }
        }

        return adjacencyMatrix;
    }

    static void DijkstraAlgorithm(int[,] graph, int startVertex)
    {
        int vertices = graph.GetLength(0);
        int[] distance = new int[vertices];
        bool[] shortestPathTreeSet = new bool[vertices];

        for (int i = 0; i < vertices; i++)
        {
            distance[i] = int.MaxValue;
            shortestPathTreeSet[i] = false;
        }

        distance[startVertex] = 0;

        for (int count = 0; count < vertices - 1; count++)
        {
            int u = MinDistance(distance, shortestPathTreeSet, vertices);
            shortestPathTreeSet[u] = true;

            for (int v = 0; v < vertices; v++)
            {
                if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                {
                    distance[v] = distance[u] + graph[u, v];
                }
            }
        }

        PrintSolution(distance, vertices);
    }

    static int MinDistance(int[] distance, bool[] shortestPathTreeSet, int vertices)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < vertices; v++)
        {
            if (shortestPathTreeSet[v] == false && distance[v] <= min)
            {
                min = distance[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    static void PrintSolution(int[] distance, int vertices)
    {
        Console.WriteLine("Вершина \t Відстань від початкової вершини");
        for (int i = 0; i < vertices; i++)
        {
            Console.WriteLine(i + " \t\t " + distance[i]);
        }
    }

    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
