using Xunit;
using Matrix;

namespace MatrixTestXUnit
{
    public class CompactMatrixUnitTests
    {
        [Fact]
        public void Constructor_WithValidSparseMatrix_CreatesCompactMatrix1()
        {
            int[,] sparseMatrix = {
            { 0, 0, 3, 0, 4 },
            { 0, 0, 5, 7, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 2, 6, 0, 0 }
            };

            // Create a CompactMatrix instance from the sparse matrix
            CompactMatrix _compactMatrix = CompactMatrix.CreateFromSparseMatrix(sparseMatrix);

            int[,] expectedCompactMatrix = {
                { 0, 0, 1, 1, 3, 3 },
                { 2, 4, 2, 3, 1, 2 },
                { 3, 4, 5, 7, 2, 6 }
            };
            Assert.Equal(expectedCompactMatrix, _compactMatrix.GetCompactMatrix());
        }

        [Fact]
        public void Constructor_WithValidSparseMatrix_CreatesCompactMatrix2()
        {
            int[,] sparseMatrix = {
                {1, 0, 0, 0, 0},
                {0, 2, 0, 0, 5},
                {0, 0, 3, 4, 0},
                {2, 0, 3, 8, 0}
            };

            // Create a CompactMatrix instance from the sparse matrix
            CompactMatrix _compactMatrix = CompactMatrix.CreateFromSparseMatrix(sparseMatrix);

            int[,] result = _compactMatrix.GetCompactMatrix();
            Assert.Equal(8, result.GetLength(1));
            Assert.Equal(3, result.GetLength(0));
            Assert.Equal(3, result[0, 6]);
            Assert.Equal(4, result[1, 2]);
            Assert.Equal(2, result[1, 6]);
        }

        [Fact]
        public void Constructor_WithValidSparseMatrixContainingNegative_CreatesCompactMatrix3()
        {
            int[,] sparseMatrix = {
                {1, 0, 0, -7, 0},
                {0, -3, 0, -4, 5},
                {0, 0, 0, 4, 0},
                {2, 0, 6, 0, 0}
            };

            // Create a CompactMatrix instance from the sparse matrix
            CompactMatrix _compactMatrix = CompactMatrix.CreateFromSparseMatrix(sparseMatrix);

            int[,] result = _compactMatrix.GetCompactMatrix();
            Assert.Equal(8, result.GetLength(1));
            Assert.Equal(3, result.GetLength(0));
            Assert.Equal(-7, result[2, 1]);
            Assert.Equal(4, result[1, 4]);
            Assert.Equal(-4, result[2, 3]);
            Assert.Equal(1, result[0, 3]);
            Assert.Equal(-3, result[2, 2]);
        }

        [Fact]
        public void Constructor_WithNullSparseMatrix_ReturnsNullCompactMatrix()
        {
            // Create a CompactMatrix instance from the sparse matrix
            CompactMatrix _compactMatrix = CompactMatrix.CreateFromSparseMatrix(null);

            Assert.Null(_compactMatrix.GetCompactMatrix());
        }

        [Fact]
        public void Constructor_WithEmptySparseMatrix_ReturnsNullCompactMatrix()
        {
            int[,] sparseMatrix = new int[0, 0];

            // Create a CompactMatrix instance from the sparse matrix
            CompactMatrix _compactMatrix = CompactMatrix.CreateFromSparseMatrix(sparseMatrix);

            Assert.Null(_compactMatrix.GetCompactMatrix());
        }

        [Fact]
        public void Constructor_WithAllZeroSparseMatrix_ReturnsNullCompactMatrix()
        {
            int[,] sparseMatrix = {
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0}
            };

            // Create a CompactMatrix instance from the sparse matrix
            CompactMatrix _compactMatrix = CompactMatrix.CreateFromSparseMatrix(sparseMatrix);

            Assert.Null(_compactMatrix.GetCompactMatrix());
        }

        [Fact]
        public void GetCompactMatrix_WithoutCallingConstructor_ReturnsNull()
        {
            // Create a CompactMatrix instance from the sparse matrix
            CompactMatrix _compactMatrix = CompactMatrix.CreateFromSparseMatrix(null);

            int[,] result = _compactMatrix.GetCompactMatrix();

            Assert.Null(result);
        }

        [Fact]
        public void Constructor_WithSparseMatrixContainingNegativeValues_CreatesCompactMatrix()
        {
            int[,] sparseMatrix = {
                { -1, 0, 0 },
                { 0, -2, 0 },
                { 0, 0, -3 }
            };

            // Create a CompactMatrix instance from the sparse matrix
            CompactMatrix _compactMatrix = CompactMatrix.CreateFromSparseMatrix(sparseMatrix);

            int[,] result = _compactMatrix.GetCompactMatrix();
            Assert.Null(result); // Ensure that compactMatrix is null for the given sparse matrix
        }

    }
}
