using Xunit;
using Matrix;

namespace MatrixTestXUnit
{
    public class SparseMatrixTests
    {
        [Fact]
        public void SparseMatrixUnitTest1()
        {
            int[,] compactMatrix = {
                { 0, 0, 1, 1, 3, 3 },
                { 2, 4, 2, 3, 1, 2 },
                { 3, 4, 5, 7, 2, 6 }
            };

            SparseMatrix _sparseMatrix = new SparseMatrix(compactMatrix);

            int[,] expectedSparseMatrix = {
            { 0, 0, 3, 0, 4 },
            { 0, 0, 5, 7, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 2, 6, 0, 0 }
            };

            Assert.Equal(_sparseMatrix.GetSparseMatrix(), expectedSparseMatrix);
        }
    }
}
