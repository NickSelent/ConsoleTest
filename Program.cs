using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Merchants
{
    class Program
    {

        [DllImport("kernel32.dll", EntryPoint = "GetConsoleWindow", SetLastError = true)]
        private static extern IntPtr GetConsoleHandle();

        static void Main(string[] args)
        {

            int textiles = 0;
            int produce = 0;
            int minerals = 0;


            ChangeWorld();

            bool running = true;
            while (running)
            {
                Render();
                HandleUserInput(ref running, ref textiles, ref produce, ref minerals);
            }
        }

        private static void Render()
        {

            Random rnd = new Random(DateTime.Now.Millisecond);
            int x = rnd.Next(1, 19); 
            int y = rnd.Next(1, 19); 
            int z = rnd.Next(1, 19); 

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(75+x, 10);
            Console.Write("*");
            Console.SetCursorPosition(75+y, 11);
            Console.Write("*");
            Console.SetCursorPosition(75+z, 12);
            Console.Write("*");


            var handler = GetConsoleHandle();

            using (var graphics = Graphics.FromHwnd(handler))
            {
                using (var image = Image.FromFile("img101.png"))
                {
                    graphics.DrawImage(image, 600, 5, 150, 150);
                }
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, 22);
            Console.Write(DateTime.Now.ToLongTimeString());

        }

        private static void ChangeWorld()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(75, 10);
            Console.Write("                   ");
            Console.SetCursorPosition(75, 11);
            Console.Write("                   ");
            Console.SetCursorPosition(75, 12);
            Console.Write("                   ");

            Console.BackgroundColor = ConsoleColor.Black;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(15, 15);
            Console.Write("Textiles");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(15, 17);
            Console.Write("Produce");
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.SetCursorPosition(15, 19);
            Console.Write("Minerals");


        }

        private static void HandleUserInput(ref bool running, ref int textiles, ref int produce, ref int minerals)
        {

            var result = 0;

            Console.SetCursorPosition(1, 24);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            var x = Console.ReadLine();
            if (x.ToUpper().Equals("Q") )
                running = false;

            if (textiles.Equals(0))
            {
                if (int.TryParse(x, out textiles)) ;
                Console.SetCursorPosition(30, 15);
                Console.Write("     ");
                Console.SetCursorPosition(30, 15);
                Console.Write(textiles);
                produce = 0;
            }
            else
            {
                if (produce.Equals(0))
                { if (int.TryParse(x, out produce)) ;
                    Console.SetCursorPosition(30, 17);
                    Console.Write("     ");
                    Console.SetCursorPosition(30, 17);
                    Console.Write(produce);
                    minerals = 0;
                }
                else { if (int.TryParse(x, out minerals)) ;
                    Console.SetCursorPosition(30, 19);
                    Console.Write("     ");
                    Console.SetCursorPosition(30, 19);
                    Console.Write(minerals);
                    textiles = 0;
                }
            }

            Console.SetCursorPosition(1, 24);
            Console.Write("                                                   ");
        }
    }
}
