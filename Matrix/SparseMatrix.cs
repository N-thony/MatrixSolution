﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
   public class SparseMatrix
    {
        private int[,] sparseMatrix = null;

        public SparseMatrix(int[,] compactMatrix)
        {
            if (compactMatrix is null) {
                return;
            }

            // Adjusted the iRows with an extra row to accomodate the spare matrix
            // this will allow it to match the provided example of sparse matrix with 4 rows.
            int iRows = compactMatrix.GetLength(0) + 1;

            // Adjusted the iColumns to reduce by 1 column to accomodate the spare matrix.
            // this will allow it to match the provided example of sparse matrix with 5 columns.
            int iColumns = compactMatrix.GetLength(1) - 1;

            sparseMatrix = new int[iRows, iColumns];
            // Fill sparse matrix
            for (int j = 0; j < iColumns + 1; j++)
            {
                int iRow = compactMatrix[0, j];
                int iCol = compactMatrix[1, j];
                int iElement = compactMatrix[2, j];
                sparseMatrix[iRow, iCol] = iElement;
            }
        }
        public int[,] GetSparseMatrix()
        {
            return sparseMatrix;
        }
    }
}
