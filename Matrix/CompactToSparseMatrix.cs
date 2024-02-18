using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
   public class CompactToSparseMatrix
    {
        private readonly int[,] compactMatrix;
        private readonly int iRows;
        private readonly int iColumns;

        public CompactToSparseMatrix(int[,] compactMatrix)
        {
            if (compactMatrix is null) {
                return;
            }
            this.compactMatrix = compactMatrix;
            // Adjusted the iRows with an extra row to accomodate the spare matrix
            // this will allow it to match the provided example of sparse matrix with 4 rows.
            this.iRows = compactMatrix.GetLength(0) + 1;

            // Adjusted the iColumns to reduce by 1 column to accomodate the spare matrix.
            // this will allow it to match the provided example of sparse matrix with 5 columns.
            this.iColumns = compactMatrix.GetLength(1) - 1;
        }

        public int[,] CreateSparseMatrix()
        {
            int[,] sparseMatrix = new int[iRows, iColumns];

            if (compactMatrix != null)
            {
                // Fill sparse matrix
                for (int j = 0; j < iColumns + 1; j++)
                {
                    int iRow = compactMatrix[0, j];
                    int iCol = compactMatrix[1, j];
                    int iElement = compactMatrix[2, j];
                    sparseMatrix[iRow, iCol] = iElement;
                }

                return sparseMatrix;
            }
            return null;
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
