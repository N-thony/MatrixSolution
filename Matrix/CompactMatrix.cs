using System;

namespace Matrix
{
    public class CompactMatrix
    {
        private readonly int[,] compactMatrix;

        // Private constructor to enforce the use of the factory method
        private CompactMatrix(int[,] compactMatrix)
        {
            this.compactMatrix = compactMatrix;
        }

        // Factory method to create CompactMatrix from a sparse matrix
        public static CompactMatrix CreateFromSparseMatrix(int[,] sparseMatrix)
        {
            ValidateSparseMatrix(sparseMatrix);

            int nonZeroCount = CountNonZeroElements(sparseMatrix);

            if (nonZeroCount == 0)
            {
                return new CompactMatrix(null);
            }

            int[,] compactMatrix = new int[3, nonZeroCount];

            int k = 0;
            for (int i = 0; i < sparseMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < sparseMatrix.GetLength(1); j++)
                {
                    if (sparseMatrix[i, j] != 0)
                    {
                        compactMatrix[0, k] = i;
                        compactMatrix[1, k] = j;
                        compactMatrix[2, k] = sparseMatrix[i, j];
                        k++;
                    }
                }
            }

            return new CompactMatrix(compactMatrix);
        }

        // Private method to validate sparse matrix
        private static void ValidateSparseMatrix(int[,] sparseMatrix)
        {
            if (sparseMatrix is null || sparseMatrix.GetLength(0) < 1)
            {
                throw new ArgumentException("Invalid sparse matrix");
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

        // Public method to get the compact matrix
        public int[,] GetCompactMatrix()
        {
            return compactMatrix;
        }
    }
}
