using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

public class MatricuSkaic
{
    public MatricuSkaic()
    {
    }

    // Metodas, skirtas matricų sudejimui
    public int[,] AddMatrices(int[,] firstMatrix, int[,] secondMatrix)
    {
        int rows = firstMatrix.GetLength(0);
        int columns = firstMatrix.GetLength(1);
        int[,] resultMatrix = new int[rows, columns];

        // Patikrina ar matricas galima sudeti
        if (rows != secondMatrix.GetLength(0) || columns != secondMatrix.GetLength(1))
        {
            throw new Exception("Matricos matmenys nesutampa.");
        }

        // Sukuriami threads
        Thread[] threads = new Thread[rows];

        for (int i = 0; i < rows; i++)
        {
            int rowIndex = i;
            threads[rowIndex] = new Thread(() =>
            {
                for (int j = 0; j < columns; j++)
                {
                    resultMatrix[rowIndex, j] = firstMatrix[rowIndex, j] + secondMatrix[rowIndex, j];
                }
            });
            threads[rowIndex].Start();
        }

        // Laukiama, kol visi siūlai baigs darbą
        for (int i = 0; i < rows; i++)
        {
            threads[i].Join();
        }

        return resultMatrix;
    }

    // Metodas, skirtas matricų atimčiai
    public int[,] SubtractMatrices(int[,] firstMatrix, int[,] secondMatrix)
    {
        int rows = firstMatrix.GetLength(0);
        int columns = firstMatrix.GetLength(1);
        int[,] resultMatrix = new int[rows, columns];

        // Patikrina ar matricas galima atimti
        if (rows != secondMatrix.GetLength(0) || columns != secondMatrix.GetLength(1))
        {
            throw new Exception("Matricos matmenys nesutampa.");
        }

        // Sukuriami threads
        Thread[] threads = new Thread[rows];

        for (int i = 0; i < rows; i++)
        {
            int rowIndex = i;
            threads[rowIndex] = new Thread(() =>
            {
                for (int j = 0; j < columns; j++)
                {
                    resultMatrix[rowIndex, j] = firstMatrix[rowIndex, j] - secondMatrix[rowIndex, j];
                }
            });
            threads[rowIndex].Start();
        }

        // Laukiama, kol visi siūlai baigs darbą
        for (int i = 0; i < rows; i++)
        {
            threads[i].Join();
        }

        return resultMatrix;
    }

    // Metodas, skirtas matricų daugybai
    public int[,] MultiplyMatrices(int[,] firstMatrix, int[,] secondMatrix)
    {
        int x1 = firstMatrix.GetLength(0);
        int y1 = firstMatrix.GetLength(1);
        int x2 = secondMatrix.GetLength(0);
        int y2 = secondMatrix.GetLength(1);

        // Patikrina ar matricas galima dauginti
        if (y1 != x2)
        {
            throw new Exception("Matricų matmenys nesutampa dauginti.");
        }

        int[,] resultMatrix = new int[x1, y2];

        // Sukuriami threads
        Thread[] threads = new Thread[x1];

        for (int i = 0; i < x1; i++)
        {
            for (int j = 0; j < y2; j++)
            {
                int x = i;
                int y = j;

                threads[j] = new Thread(() =>
                {
                    resultMatrix[x, y] = MultiplyCell(firstMatrix, secondMatrix, x, y);
                });
                threads[j].Start();
            }

            // Laukiama, kol visi siūlai baigs darbą
            for (int j = 0; j < y2; j++)
            {
                threads[j].Join();
            }
        }

        return resultMatrix;
    }

    private int MultiplyCell(int[,] firstMatrix, int[,] secondMatrix, int x, int y)
    {
        int result = 0;

        for (int i = 0; i < firstMatrix.GetLength(1); i++)
        {
            result += firstMatrix[x, i] * secondMatrix[i, y];
        }

        return result;
    }
}