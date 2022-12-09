// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int ReadData(string line)
{
    Console.Write(line);
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}



int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns]; // 0, 1
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++) //2
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(min, max + 1); // 2- 3
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write("|");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j],4}, ");
            else Console.Write($"{matrix[i, j],4} ");
        }
        Console.WriteLine("|");
    }
}

int[,] MultiMatrix(int[,] matrix1, int[,] matrix2)
{
    int[,] resultMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < resultMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < resultMatrix.GetLength(1); j++)
        {
            int multiElement = 0;
            int sumMulti = 0;
            for (int j1 = 0; j1 < matrix1.GetLength(1); j1++)
            {
                for (int i1 = 0; i1 < matrix2.GetLength(0); i1++)
                {
                    if (i1 == j1)
                    {
                        multiElement = matrix1[i, j1] * matrix2[i1, j];
                        sumMulti += multiElement;
                    }

                }
            }
            resultMatrix[i, j] = sumMulti;
        }
    }
    return resultMatrix;
}



Console.WriteLine("Задайте количество строк и столбцов для первой и второй матрицы: ");
Console.WriteLine();
int rows1 = ReadData("Введите число СТРОК для матрицы A: ");
int columns1 = ReadData("Введите число СТОЛБЦОВ для матрицы A: ");
int rows2 = ReadData("Введите число СТРОК для матрицы B: ");
int columns2 = ReadData("Введите число СТОЛБЦОВ для матрицы B: ");

int[,] matrixA = CreateMatrixRndInt(rows1, columns1, 1, 10);
PrintMatrix(matrixA);
Console.WriteLine();
int[,] matrixB = CreateMatrixRndInt(rows2, columns2, 1, 10);
PrintMatrix(matrixB);
Console.WriteLine();
int[,] result = MultiMatrix(matrixA, matrixB);


if (columns1 == rows2)
{
    Console.WriteLine("Результат перемножения матриц: ");
    PrintMatrix(result);
}
else
{
    Console.WriteLine("Число столбцов матрицы A не равно числу строк матрицы В. Перемножение не возможно!");
}



