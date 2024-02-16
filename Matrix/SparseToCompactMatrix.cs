using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class SparseToCompactMatrix
    {
        private int[,] sparseMatrix;
        private int iRows;
        private int iColumns;

        public SparseToCompactMatrix(int[,] sparseMatrix)
        {
            this.sparseMatrix = sparseMatrix;
            this.iRows = sparseMatrix.GetLength(0);
            this.iColumns = sparseMatrix.GetLength(1);
        }

        public void DisplayCompactMatrix()
        {
            int iSize = CountNonZeroElements();
            int[,] compactMatrix = CreateCompactMatrix(iSize);

            Console.WriteLine("Compact Matrix:\n");
            // Display compact matrix
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < iSize; j++)
                    Console.Write(" " + compactMatrix[i, j]);
                    Console.WriteLine();
            }
        }

        private int CountNonZeroElements()
        {
            int iSize = 0;
            for (int i = 0; i < iRows; i++)
                for (int j = 0; j < iColumns; j++)
                    if (sparseMatrix[i, j] != 0)
                        iSize++;
            return iSize;
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
