using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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

            Console.SetCursorPosition(1, 23);
            Console.Write("Input # (q to quit):");


            Task t = Task.Run(() => {

                Random rnd = new Random(DateTime.Now.Millisecond);
                int x = rnd.Next(1, 19);
                int milliseconds = 100;
                     Thread.Sleep(milliseconds);
                int y = rnd.Next(1, 19);

                    Thread.Sleep(milliseconds);
                int z = rnd.Next(1, 19);
                int dx = 0;
                int dy = 1; //0 move right, 1 move left
                int dz = 0;
                int ex = 75;
                int ey = 75; // last position so we can clear the prior *
                int ez = 75;

                // Just loop.
                int ctr = 0;
                for (ctr = 0; ctr <= 1000000; ctr++)
                {
                    Thread.Sleep(milliseconds);

                    var cx = Console.CursorLeft;
                    var cz = Console.CursorTop;

                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(75 + x, 10);
                    Console.Write("*");
                    Console.SetCursorPosition(75 + y, 11);
                    Console.Write("*");
                    Console.SetCursorPosition(75 + z, 12);
                    Console.Write("*");

                    Console.SetCursorPosition(ex, 10);
                    Console.Write(" ");
                    Console.SetCursorPosition(ey, 11);
                    Console.Write(" ");
                    Console.SetCursorPosition(ez, 12);
                    Console.Write(" ");

                    ex = 75 + x;
                    ey = 75 + y;
                    ez = 75 + z;

                    if (x.Equals(18))
                    {
                        dx = 1;
                    } else if(x.Equals(0))
                    {
                        dx = 0;
                    }

                    if (dx.Equals(0))
                    {
                        x++;
                    }
                    else
                    {
                        x--;
                    }

                    if (y.Equals(18))
                    {
                        dy = 1;
                    }
                    else if (y.Equals(0))
                    {
                        dy = 0;
                    }

                    if (dy.Equals(0))
                    {
                        y++;
                    }
                    else
                    {
                        y--;
                    }

                    if (z.Equals(18))
                    {
                        dz = 1;
                    }
                    else if (z.Equals(0))
                    {
                        dz = 0;
                    }

                    if (dz.Equals(0))
                    {
                        z++;
                    }
                    else
                    {
                        z--;
                    }
                    


                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(cx, cz);
                }
            });
            //t.Wait();


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
