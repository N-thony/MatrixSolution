using Xunit;
using Matrix;

namespace MatrixTestXUnit
{
    public class SparseMatrixTests
    {
        [Fact]
        public void Constructor_WithValidCompactMatrix_CreatesSparseMatrix1()
        {
            int[,] compactMatrix = {
                { 0, 0, 1, 1, 3, 3 },
                { 2, 4, 2, 3, 1, 2 },
                { 3, 4, 5, 7, 2, 6 }
            };

            // Create a SparseMatrix instance from the compact matrix
            SparseMatrix _sparseMatrix = SparseMatrix.CreateFromCompactMatrix(compactMatrix);

            int[,] expectedSparseMatrix = {
                { 0, 0, 3, 0, 4 },
                { 0, 0, 5, 7, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 2, 6, 0, 0 }
            };

            Assert.Equal(_sparseMatrix.GetSparseMatrix(), expectedSparseMatrix);
        }

        [Fact]
        public void Constructor_WithValidCompactMatrix_CreatesSparseMatrix2()
        {
            int[,] compactMatrix = {
                {0, 1, 2, 2, 3, 3},
                {0, 1, 2, 3, 2, 3},
                {1 ,2, 3, 4, 3, 8}
            };

            // Create a SparseMatrix instance from the compact matrix
            SparseMatrix _sparseMatrix = SparseMatrix.CreateFromCompactMatrix(compactMatrix);

            int[,] result = _sparseMatrix.GetSparseMatrix();
            Assert.Equal(5, result.GetLength(1));
            Assert.Equal(4, result.GetLength(0));
            Assert.Equal(1, result[0, 0]);
            Assert.Equal(0, result[1, 3]);
            Assert.Equal(8, result[3, 3]);
        }

        [Fact]
        public void Constructor_WithValidCompactMatrixContainingNegative_CreatesSparseMatrix3()
        {
            int[,] compactMatrix = {
                { 0, 1, 2, 2, 2, 3 },
                { 0, 1, 1, 2, 3, 1 },
                { 1, -3, -5, 3, 4, -9}
            };

            // Create a SparseMatrix instance from the compact matrix
            SparseMatrix _sparseMatrix = SparseMatrix.CreateFromCompactMatrix(compactMatrix);

            int[,] result = _sparseMatrix.GetSparseMatrix();
            Assert.Equal(5, result.GetLength(1));
            Assert.Equal(4, result.GetLength(0));
            Assert.Equal(-5, result[2, 1]);
            Assert.Equal(-3, result[1, 1]);
            Assert.Equal(4, result[2, 3]);
            Assert.Equal(0, result[2, 4]);
            Assert.Equal(-9, result[3, 1]);
        }

        [Fact]
        public void Constructor_WithAllZeroCompactMatrix_ReturnsNullSparseMatrix()
        {
            int[,] compactMatrix = {
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0}
            };

            // Create a SparseMatrix instance from the compact matrix
            SparseMatrix _sparseMatrix = SparseMatrix.CreateFromCompactMatrix(compactMatrix);
            Assert.Null(_sparseMatrix.GetSparseMatrix());
        }

        [Fact]
        public void GetSparseMatrix_WithoutCallingConstructor_ReturnsNull()
        {
            // Create a SparseMatrix instance from the compact matrix
            SparseMatrix _sparseMatrix = SparseMatrix.CreateFromCompactMatrix(null);

            int[,] result = _sparseMatrix.GetSparseMatrix();

            Assert.Null(result);
        }
    }
}
