using System;
using GameofLifeDojo;
using static System.Int32;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var columns = 0;
            var rows = 0;
            var seeds = 0;
            var truechar = 'X';
            var falsechar = '-';
            if (args.Length > 0)
            {
                columns = Parse(args[0]);
                rows = Parse(args[1]);
                seeds = Parse(args[2]);
            }

            if (args.Length > 3)
            {
                truechar = args[3].ToCharArray()[0];
                falsechar = args[4].ToCharArray()[0];
            }

            if (columns <= 0 || rows <= 0 || seeds <= 0) return;

            var lifeGrid = new LifeGrid(columns, rows);

            //seed
            for (var i = seeds; i > 0; i--)
            {
                Random rnd = new Random(DateTime.Now.Millisecond);

                var x = rnd.Next(columns);
                var y = rnd.Next(rows);

                while (lifeGrid.GetCell(x, y))
                {

                    x = rnd.Next(columns);
                    y = rnd.Next(rows);
                }

                lifeGrid.Seed(x, y);
            }
            DisplayGrid(lifeGrid, truechar, falsechar);
            while (true) 
            {
                Console.WriteLine("Press Enter to generate next generation");
                var line = Console.ReadLine(); 
                if (line == "exit") 
                {
                    break;
                }

                lifeGrid.Generate();
                DisplayGrid(lifeGrid, truechar, falsechar);
            }
        }

        private static void DisplayGrid(LifeGrid lifeGrid, char truechar, char falsechar)
        {
            foreach(string row in lifeGrid.GetRows(truechar,falsechar))
            Console.WriteLine(row);
        }
    }
}
