using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] sparseMatrix ={
                { 0, 0, 3, 0, 4 },
                { 0, 0, 5, 7, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 2, 6, 0, 0 }
            };

            int[,] compactMatrix = {
                { 0, 0, 1, 1, 3, 3 },
                { 2, 4, 2, 3, 1, 2 },
                { 3, 4, 5, 7, 2, 6 }
            };

            // Create a CompactMatrix instance from the sparse matrix
            CompactMatrix _compactMatrix = CompactMatrix.CreateFromSparseMatrix(sparseMatrix);

            // Retrieve the compact matrix
            int[,] result = _compactMatrix.GetCompactMatrix();

            // Create a SparseMatrix instance from the compact matrix
            // SparseMatrix _sparseMatrix = SparseMatrix.CreateFromCompactMatrix(compactMatrix);

            // Retrieve the sparse matrix
            //int[,] result = _sparseMatrix.GetSparseMatrix();

            int numRows = result.GetLength(0);
            int numCols = result.GetLength(1);
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine(); // Move to the next line for the next row
            }

            //Keep the console window open
            Console.ReadLine();
        }
    }
}
