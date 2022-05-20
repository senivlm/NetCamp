using System;

namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateArray createArray = new CreateArray();
            int[,] verriaclSnake = createArray.VerticalSnake(5, 6);
            Print.PrintArray(verriaclSnake);
            int[,] diagonalSnake = createArray.DiagonalSnake(7, 6);
            Print.PrintArray(diagonalSnake);
            int[,] spiralSnake = createArray.SpiralSnake(7, 5);
            Print.PrintArray(spiralSnake);
        }
    }
}
