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

            var handler = GetConsoleHandle();

            using (var graphics = Graphics.FromHwnd(handler))
            using (var image = Image.FromFile("img101.png"))
                graphics.DrawImage(image, 50, 50, 250, 200);

            //bool running = true;
            //while (running)
            //{
            //    ChangeWorld();
            //    Render();
            //    HandleUserInput(ref running);

            //}
        }

        private static void Render()
        {

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(50, 2);
            Console.WriteLine("    *               ");
            Console.SetCursorPosition(50, 3);
            Console.WriteLine("              *     ");
            Console.SetCursorPosition(50, 4);
            Console.WriteLine("       *            ");
        }

        private static void ChangeWorld()
        {
            Console.BackgroundColor = ConsoleColor.Black;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(15, 15);
            Console.WriteLine("Textiles");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(15, 17);
            Console.WriteLine("Produce");
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.SetCursorPosition(15, 19);
            Console.WriteLine("Minerals");

            Console.WriteLine(DateTime.Now.ToLongTimeString());
        }

        private static void HandleUserInput(ref bool running)
        {
            Console.SetCursorPosition(1, 24);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            var x = Console.ReadLine();
            if (x.ToUpper().Equals("Q") )
                running = false;

            Console.SetCursorPosition(1, 24);
            Console.WriteLine("                          ");
        }
    }
}
