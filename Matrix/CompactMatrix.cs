namespace Matrix
{
    public class CompactMatrix
    {
        private int[,] compactMatrix = null;

        public CompactMatrix(int[,] sparseMatrix)
        {
            if (sparseMatrix is null || sparseMatrix.GetLength(0) != 4 || sparseMatrix.GetLength(1) != 5 )
            {
                return;
            }

            int iSize = 0;
            foreach (int element in sparseMatrix)
            {
                if (element != 0)
                    iSize++;
            }

            if (iSize == 0)
            {
                compactMatrix = null; // Set compactMatrix to null for an all-zero sparse matrix
                return;
            }

            compactMatrix = new int[3, iSize];

            int iRows = sparseMatrix.GetLength(0);
            int iColumns = sparseMatrix.GetLength(1);
            int k = 0;
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
        }

        public int[,] GetCompactMatrix()
        {
            return compactMatrix;
        }
    }
}