using Xunit;
using Matrix;
using System;
using System.IO;

namespace MatrixTestXUnit
{
    public class CompactToSparseMatrixTests
    {
        [Fact]
        public void CreateSparseMatrixTest()
        {
            int[,] compactMatrix = {
                { 0, 0, 1, 1, 3, 3 },
                { 2, 4, 2, 3, 1, 2 },
                { 3, 4, 5, 7, 2, 6 }
            };

            CompactToSparseMatrix compactToSparseMatrix = new CompactToSparseMatrix(compactMatrix);
            int[,] sparseMatrix = compactToSparseMatrix.CreateSparseMatrix();

            int[,] expectedSparseMatrix = {
            { 0, 0, 3, 0, 4 },
            { 0, 0, 5, 7, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 2, 6, 0, 0 }
            };


            Assert.Equal(sparseMatrix, expectedSparseMatrix);
        }

        [Fact]
        public void DisplaySparseMatrixTest()
        {
            int[,] compactMatrix = {
                { 0, 0, 1, 1, 3, 3 },
                { 2, 4, 2, 3, 1, 2 },
                { 3, 4, 5, 7, 2, 6 }
            };

            CompactToSparseMatrix compactToSparseMatrix = new CompactToSparseMatrix(compactMatrix);
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            compactToSparseMatrix.DisplaySparseMatrix();

            var expectedOutput = "Sparse Matrix:\n\r\n 0 0 3 0 4\r\n 0 0 5 7 0\r\n 0 0 0 0 0\r\n 0 2 6 0 0\r\n";

            Assert.Equal(expectedOutput.Trim(), consoleOutput.ToString().Trim());

        }
    }
}
