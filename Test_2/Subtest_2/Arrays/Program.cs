using System;

namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateArray createArray = new CreateArray();
            int[,] verriaclSnake = createArray.VerticalSnake(5, 6);
            Console.WriteLine(Print.ArrayToString(verriaclSnake));
            int[,] diagonalSnake = createArray.DiagonalSnake(7, 6);
            Console.WriteLine(Print.ArrayToString(diagonalSnake));
            int[,] spiralSnake = createArray.SpiralSnake(7, 5);
            Console.WriteLine(Print.ArrayToString(spiralSnake));
        }
    }
}
