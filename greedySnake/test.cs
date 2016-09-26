using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using greedySnake;
using ConsoleB = Colorful.Console;
using System.Drawing;

namespace test
{
    class test
    {
        static void Main()
        {
            Console.Title = "greedySnake";
            drawwing.draw();
            ////ConsoleB.WriteAscii("haha");
            //snake.write_time();
            var s = new snake();
            var food = new feed();
            Thread move = new Thread(new ThreadStart(s.action));
            Thread key_handle = new Thread(new ThreadStart(s.key_handler));
            Thread generator = new Thread(new ThreadStart(food.generator));
            Thread time = new Thread(new ThreadStart(snake.write_time));
            //Thread speed_control = new Thread(snake.shift_prssed);
            //Thread draw = new Thread(() => drawwing.WriteAt("hh", 20, 2));
            //draw.Start();
            time.Start();
            move.Start();
            key_handle.Start();
            generator.Start();
            while (move.IsAlive)
            {}
            key_handle.Abort();
            generator.Abort();
            Console.WriteLine("you");
            Console.ReadKey();

            return;
           
            //speed_control.Start();

            //List<int[]> li = new List<int[]> { };
            //li.Add(new int[] { 1, 2 });
            //int[] t = new int[] { 1, 2 };
            //li.RemoveAt(0);
            //Console.WriteLine(li.Count.ToString());
            //Console.WriteLine("started");

            //////var key = Console.ReadKey(false);
            //////while (move.IsAlive){
            //////    Console.WriteLine(key.ToString());
            //////    key = Console.ReadKey();
            //////}
            //Sample.WriteAt("0", 50, 15);            
        }
        //void start_game()
        //{
        //    ThreadStart snake = new ThreadStart()
        //}
    }
}
