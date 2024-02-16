using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class SparseMatrix
    {
        private int[,] sparseMatrix;
        private int iRows;
        private int iColumns;

        public SparseMatrix(int[,] sparseMatrix)
        {
            this.sparseMatrix = sparseMatrix;
            this.iRows = sparseMatrix.GetLength(0);
            this.iColumns = sparseMatrix.GetLength(1);
        }

        public void DisplayCompactMatrix()
        {
            int size = CountNonZeroElements();
            int[,] compactMatrix = CreateCompactMatrix(size);

            Console.WriteLine("Sparse Representation:\n");
            // Display compact matrix
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write(" " + compactMatrix[i, j]);
                    Console.WriteLine();
            }
        }

        private int CountNonZeroElements()
        {
            int size = 0;
            for (int i = 0; i < iRows; i++)
                for (int j = 0; j < iColumns; j++)
                    if (sparseMatrix[i, j] != 0)
                        size++;
            return size;
        }

        private int[,] CreateCompactMatrix(int size)
        {
            int[,] compactMatrix = new int[3, size];
            int k = 0;

            // Fill compact matrix
            for (int i = 0; i < iRows; i++)
            {
                for (int j = 0; j < iColumns; j++)
                    if (sparseMatrix[i, j] != 0)
                    {
                        compactMatrix[0, k] = i;
                        compactMatrix[1, k] = j;
                        compactMatrix[2, k] = sparseMatrix[i, j];
                        k++;
                    }
            }

            return compactMatrix;
        }
    }
}
