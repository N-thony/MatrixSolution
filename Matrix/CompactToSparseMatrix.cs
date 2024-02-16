using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
   public class CompactToSparseMatrix
    {
        private int[,] compactMatrix;
        private int iRows;
        private int iColumns;

        public CompactToSparseMatrix(int[,] compactMatrix)
        {
            this.compactMatrix = compactMatrix;
            this.iRows = compactMatrix.GetLength(0) + 1; // Added 1 to get the number of rows (4) for the expected sparse matrix.
            this.iColumns = compactMatrix.GetLength(1) - 1; // Reduced by 1 to get the number of columns (5) for the expected sparse matrix.
        }

        public int[,] CreateSparseMatrix()
        {
            int[,] sparseMatrix = new int[iRows, iColumns];

            // Fill sparse matrix
            for (int j = 0; j < iColumns + 1; j ++)
            {
                int iRow = compactMatrix[0, j];
                int iCol = compactMatrix[1, j];
                int iElement = compactMatrix[2, j];
                sparseMatrix[iRow, iCol] = iElement;
            }

            return sparseMatrix;
        }

        public void DisplaySparseMatrix()
        {
            Console.WriteLine("Sparse Matrix:\n");
            int[,] sparseMatrix = CreateSparseMatrix();
            for (int i = 0; i < iRows; i++)
            {
                for (int j = 0; j < iColumns; j++)
                    Console.Write(" " + sparseMatrix[i, j]);
                    Console.WriteLine();
            }
        }
    }
}
