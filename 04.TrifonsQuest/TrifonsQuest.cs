namespace _04.TrifonsQuest
{
    using System;
    using System.Linq;

    public static class TrifonsQuest
    {
        private static long health;
        private static int turns;
        private static char[,] matrix;

        public static void Main()
        {
            health = long.Parse(Console.ReadLine());
            var matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = matrixSize[0];
            var cols = matrixSize[1];

            matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            var goingDown = true;
            for (int col = 0; col < cols; col++)
            {
                if (goingDown)
                {
                    for (int row = 0; row < rows; row++)
                    {
                        ProcessMove(row, col);
                    }

                    goingDown = false;
                }
                else
                {
                    for (int row = rows - 1; row >= 0; row--)
                    {
                        ProcessMove(row, col);
                    }

                    goingDown = true;
                }
            }

            Console.WriteLine("Quest completed!");
            Console.WriteLine($"Health: {health}");
            Console.WriteLine($"Turns: {turns}");
        }

        private static void ProcessMove(int row, int col)
        {
            switch (matrix[row, col])
            {
                case 'F':
                    var loss = turns / 2;
                    health -= loss;
                    break;
                case 'H':
                    var restore = turns / 3;
                    health += restore;
                    break;
                case 'T':
                    turns += 2;
                    break;
                default:
                    break;
            }

            turns++;

            if (health <= 0)
            {
                Console.WriteLine($"Died at: [{row}, {col}]");
                Environment.Exit(0);
            }
        }
    }
}
