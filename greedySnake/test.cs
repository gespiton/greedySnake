using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using greedySnake;
namespace test
{
    class test
    {
        static void Main()
        {
            Console.Title = "greedySnake";
            init.draw();
            var s = new snake();
            var food = new feed();
            Thread move = new Thread(new ThreadStart(s.action));
            Thread key_handle = new Thread(new ThreadStart(s.key_handler));
            Thread generator = new Thread(new ThreadStart(food.generator));
            //Thread speed_control = new Thread(snake.shift_prssed);
            move.Start();
            key_handle.Start();
            generator.Start();
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
