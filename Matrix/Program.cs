using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            CompactMatrix _compactMatrix = new CompactMatrix(sparseMatrix);

            SparseMatrix _sparseMatrix = new SparseMatrix(compactMatrix);

            //var expectedMatrix = _sparseMatrix.GetSparseMatrix();
            var expectedMatrix = _compactMatrix.GetCompactMatrix();

            int numRows = expectedMatrix.GetLength(0);
            int numCols = expectedMatrix.GetLength(1);
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    Console.Write(expectedMatrix[i, j] + " ");
                }
                Console.WriteLine(); // Move to the next line for the next row
            }

            //Keep the console window open
            Console.ReadLine();
        }
    }
}
