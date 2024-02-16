using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class CompactMatrix
    {
        private int[,] compactMatrix;
        private int iRows;
        private int iColumns;

        public CompactMatrix(int[,] compactMatrix)
        {
            this.compactMatrix = compactMatrix;
            this.iRows = compactMatrix.GetLength(0) + 1; // Assuming compactMatrix has a fixed structure with 3 rows.
            this.iColumns = compactMatrix.GetLength(1) - 1;
        }

        public int[,] CreateSparseMatrix()
        {
            int[,] sparseMatrix = new int[iRows, iColumns]; // Assuming compactMatrix has a fixed structure with 3 rows.

            // Fill sparse matrix
            for (int j = 0; j < iColumns; j ++)
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
