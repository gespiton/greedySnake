using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
        void snake_drawHead(int[] head)
        {
            //draw snake head

            Sample.WriteAt((char)snake_dir, head[0], head[1]);

        }
        void snake_reset(int[] tail)
        {
            WriteAt((char)0, tail[0], tail[1]);
        }
        void snake_progress_normal()
        {
            switch (snake_dir)
            {
                case snake_head.UP:
                    if (snake_check())
                    {
                        snake_body.Insert(0, new int[] { snake_body[0][0], snake_body[0][1] + 1 });
                        snake_drawHead(snake_body[0]);

                        snake_body.RemoveAt(snake_body.Count() - 1);
                    }
                    break;
            }
        }

         void WriteAt(char s, int x, int y)
        {

            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }

        bool snake_check()
        {

            return true;
        }
    }
}
// key press should be handled outside