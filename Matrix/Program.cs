using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] sparseMatrix = {
                {1, 0, 0, -7, 0},
                {0, -3, 0, -4, 5},
                {0, 0, 0, 4, 0},
                {2, 0, 6, 0, 0}
            };

            CompactMatrix _compactMatrix = new CompactMatrix(sparseMatrix);
            Console.WriteLine(_compactMatrix.GetCompactMatrix());

            //int[,] compactMatrix = {
            //    { 0, 0, 1, 1, 3, 3 },
            //    { 2, 4, 2, 3, 1, 2 },
            //    { 3, 4, 5, 7, 2, 6 }
            //};

            //SparseMatrix converter = new SparseMatrix(compactMatrix);
            //converter.DisplaySparseMatrix();

            //Keep the console window open
            Console.ReadLine();
        }
    }
}
