using System;

namespace Vector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Vector arr = new Vector(20);
            //arr.InitRandom(1, 5);
            //Console.WriteLine(arr);
            //Pair[] pairs = arr.CalculateFreq();
            //for(int i = 0; i < pairs.Length; i++)
            //{
            //    Console.WriteLine(pairs[i]);
            //}
            //arr.InitPoliandr(1, 5);
            //Console.WriteLine(arr);
            //Console.WriteLine("Is Poliandr {0}", arr.IsPoliand());
            //arr.InitRandom(1,5);
            //Console.WriteLine(arr);
            //Console.WriteLine("Is Poliandr {0}", arr.IsPoliand());

            //Console.WriteLine("Matrix");
            //Matrix matrix = new Matrix(7, 7);
            //matrix.DiagonalSnake(Start.right);
            //Console.WriteLine(matrix);
            //Console.WriteLine("New array");
            //Matrix matrix1 = new Matrix(7, 4);
            //matrix1.DiagonalSnake(Start.down);
            //Console.WriteLine(matrix1);



            Vector v1 = new Vector(40);
            v1.InitRandom(2, 5);
            Console.WriteLine(v1);
            v1.Counting();
            Console.WriteLine(v1);
        }
    }
}
