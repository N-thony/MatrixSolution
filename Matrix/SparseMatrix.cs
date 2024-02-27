using System;

namespace Matrix
{
    public class SparseMatrix
    {
        private readonly int[,] sparseMatrix;

        // Private constructor to enforce the use of the factory method
        private SparseMatrix(int[,] sparseMatrix)
        {
            this.sparseMatrix = sparseMatrix;
        }

        // Factory method to create SparseMatrix from a compact matrix
        public static SparseMatrix CreateFromCompactMatrix(int[,] compactMatrix)
        {
            ValidateCompactMatrix(compactMatrix);

            int iRows = compactMatrix.GetLength(0) + 1;
            int iColumns = compactMatrix.GetLength(1) - 1;
            int iCountNonZero = CountNonZeroElements(compactMatrix);

            if (iCountNonZero == 0)
            {
                return new SparseMatrix(null);
            }

            int[,] sparseMatrix = new int[iRows, iColumns];

            for (int j = 0; j < iColumns + 1; j++)
            {
                int iRow = compactMatrix[0, j];
                int iCol = compactMatrix[1, j];
                int iElement = compactMatrix[2, j];
                sparseMatrix[iRow, iCol] = iElement;
            }

            return new SparseMatrix(sparseMatrix);
        }

        // Private method to validate compact matrix
        private static void ValidateCompactMatrix(int[,] compactMatrix)
        {
            if (compactMatrix is null || compactMatrix.GetLength(0) < 3)
            {
                throw new ArgumentException("Invalid compact matrix");
            }
        }

        // Private method to count non-zero elements
        private static int CountNonZeroElements(int[,] matrix)
        {
            int count = 0;
            foreach (int element in matrix)
            {
                if (element != 0)
                {
                    count++;
                }
            }
            return count;
        }

        // Public method to get the sparse matrix
        public int[,] GetSparseMatrix()
        {
            return sparseMatrix;
        }
    }
}
