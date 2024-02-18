using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
   public class SparseToCompactMatrix
    {
        private readonly int[,] sparseMatrix;
        private readonly int iRows;
        private readonly int iColumns;

        private const int iCompactMatrixRows = 3;

        public SparseToCompactMatrix(int[,] sparseMatrix)
        {
            if(sparseMatrix is null)
            {
                return;
            }
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
            for (int i = 0; i < iCompactMatrixRows; i++)
            {
                for (int j = 0; j < iSize; j++)
                    Console.Write(" " + compactMatrix[i, j]);
                    Console.WriteLine();
            }
        }

        public int CountNonZeroElements()
        {
            if (sparseMatrix != null)
            {
                int iSize = 0;
                foreach (int element in sparseMatrix)
                {
                    if (element != 0)
                        iSize++;
                }
                return iSize;
            }
            return 0;
        }

        public int[,] CreateCompactMatrix(int size)
        {
            int[,] compactMatrix = new int[iCompactMatrixRows, size];
            int k = 0;

            if (sparseMatrix != null)
            {             // Fill compact matrix
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
            return null;
        }
    }
}
