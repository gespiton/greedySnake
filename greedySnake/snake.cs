using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace greedySnake
{
    enum snake_head
    {
        UP = 30,
        DOWN = 31,
        LEFT = 17,
        RIGHT = 16
    }

    public class snake
    {
        // store the current color of the snake
        ConsoleColor fore_color = ConsoleColor.Black;
        ConsoleColor back_color = ConsoleColor.DarkCyan;
        // this is the initial dirction of the snake
        static snake_head snake_dir = snake_head.UP;

        static int snake_length = 2;

        static List<int[]> snake_body = new List<int[]>();

        //  this is my constructor
        public snake()
        {
            // generate the snake body
            snake_body.Add(new int[] { 50, 15 });
            snake_body.Insert(1,new int[] { 50, 16 });

            snake_drawHead(snake_body[0]);
            //////Console.WriteLine( snake_body.Count());
            WriteAt((char)15, 50, 16);
            Console.ReadKey();
            action();
            //snake_move_normal();

        }
        void snake_drawHead(int[] head)
        {
            //draw snake head
            WriteAt((char)snake_dir, head[0], head[1]);
        }
        void snake_reset(int[] tail)
        {
            WriteAt((char)0, tail[0], tail[1]);
        }
        void snake_drawBody(int[] body)
        {
            WriteAt((char)15, body[0], body[1]);
        }
        void snake_move_normal()
        {
            //while (true)
            //{

                switch (snake_dir)
                {
                  //move up
                  case snake_head.UP:              
                    snake_body.Insert(0, new int[] { snake_body[0][0], snake_body[0][1] - 1 });
                    snake_drawHead(snake_body[0]);
                    snake_drawBody(snake_body[1]);
                    snake_reset(snake_body[snake_body.Count() - 1]);
                    snake_body.RemoveAt(snake_body.Count() - 1);
                    break;
                // move down

                // move left 

                // move right
                }
            //}
        }
        void pase_fuc()
        {
            ;
        }

        void WriteAt(char s, int x, int y)
        {

            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }
        bool snake_check()
        {
            // check if hit the wall 

            // check if eat itself
            return true;
        }
        void action()
        {
            ThreadStart act = new ThreadStart(pase_fuc);
            Thread actThread = new Thread(act);
            actThread.Start();
            Thread.Sleep(1000);
            while (snake_check())
            {
                Console.Write(Thread.CurrentThread);
                Thread.Sleep(1000);
                snake_move_normal();
            }
            // ctrol the snacks movement
        }
    }
}
// key press should be handled outside