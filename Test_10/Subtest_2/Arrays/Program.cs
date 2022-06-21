using System;

namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateArray createArray = new CreateArray();
            int[,] verriaclSnake = createArray.VerticalSnake(4, 4);
            Console.WriteLine(Print.ArrayToString(verriaclSnake));
            Console.WriteLine();
            Console.WriteLine("horizontal foreach");
            Matrix matrix = new Matrix(verriaclSnake);
            foreach (int elem in matrix)
            {
                Console.Write($"{elem} ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("diagonal foreach");
            MatrixDiagonal matrixDiagonal = new MatrixDiagonal(verriaclSnake);
            foreach(int elem in matrixDiagonal)
            {
                Console.Write($"{elem} ");
            }
        }
    }
}
