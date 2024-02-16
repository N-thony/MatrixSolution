using Xunit;
using Matrix;

namespace MatrixTestXUnit
{
    public class SparseToCompactUnitTests
    {
        [Fact]
        public void CreateCompactMatrixTest()
        {
            int[,] sparseMatrix = {
            { 0, 0, 3, 0, 4 },
            { 0, 0, 5, 7, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 2, 6, 0, 0 }
            };

            SparseToCompactMatrix spToCompactMatrix = new SparseToCompactMatrix(sparseMatrix);
            int[,] compactMatrix = spToCompactMatrix.CreateCompactMatrix(6);

            int[,] expectedCompactMatrix = {
                { 0, 0, 1, 1, 3, 3 },
                { 2, 4, 2, 3, 1, 2 },
                { 3, 4, 5, 7, 2, 6 }
            };

            Assert.Equal(expectedCompactMatrix, compactMatrix);
        }

        [Fact]
        public void CountNonZeroElementsTest()
        {
            int[,] sparseMatrix = {
            { 0, 0, 3, 0, 4 },
            { 0, 0, 5, 7, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 2, 6, 0, 0 }
            };

            SparseToCompactMatrix spToCompactMatrix = new SparseToCompactMatrix(sparseMatrix);

            int count = spToCompactMatrix.CountNonZeroElements();

            Assert.Equal(6, count);
        }

        //[Fact]
        //public void DisplayCompactMatrixTest()
        //{
        //    int[,] sparseMatrix = {
        //    { 0, 0, 3, 0, 4 },
        //    { 0, 0, 5, 7, 0 },
        //    { 0, 0, 0, 0, 0 },
        //    { 0, 2, 6, 0, 0 }
        //    };

        //    SparseToCompactMatrix spToCompactMatrix = new SparseToCompactMatrix(sparseMatrix);

        //    Assert.DoesNotThrow() => spToCompactMatrix.DisplayCompactMatrix();
        //}
    }
}
