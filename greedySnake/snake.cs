using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConsoleB = Colorful.Console;
using System.Drawing;
using Colorful;
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
        static Color _back = Color.FromArgb(187, 207, 213);
        // build a dict that map the key to snake_dir
        Dictionary<ConsoleKey, snake_head> key_map = new Dictionary<ConsoleKey, snake_head>
        {
            {ConsoleKey.UpArrow,snake_head.UP },
            {ConsoleKey.DownArrow,snake_head.DOWN },
            {ConsoleKey.LeftArrow,snake_head.LEFT },
            {ConsoleKey.RightArrow,snake_head.RIGHT }
        };
        public static int normal_speed = 200;
        public static int speed = 200;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
        //////// key buffer
        ////////List<ConsoleKeyInfo> buf = new List<ConsoleKeyInfo>();
        // store the current color of the snake
        //ConsoleColor fore_color = ConsoleColor.Black;
        //ConsoleColor back_color = ConsoleColor.DarkCyan;
        // this is the initial dirction of the snake
        snake_head snake_dir = snake_head.UP; // when key pressed, change this
        //snake_head cur_dir = snake_head.UP;   // store the current direction

        //bool can_write = true;
        //bool key_waiting = false;
        //int snake_length = 2;

        static ConsoleKeyInfo key = new ConsoleKeyInfo();

        public List<int[]> snake_body = new List<int[]>();

        //  this is my constructor
        public snake()
        {
            // generate the snake body
            snake_body.Add(new int[] { 50, 11 });   // if the colum is even, then the gen should generate even position for food
            snake_body.Insert(1, new int[] { 50, 12 });
            snake_drawHead(snake_body[0],Color.Indigo);
            snake_drawBody(snake_body[1]);
            drawwing.WriteAt(
            "press arrowKey to move the snake", 35, 15, back: _back, fore: Color.FromArgb(120,1,225));
            drawwing.WriteAt("press shift while press arrowKey to speed up", 35, 16, back: _back, fore: Color.FromArgb(120, 1, 225));
            drawwing.WriteAt("eat you own tail,hehe", 35, 17, back: _back, fore: Color.FromArgb(120, 1, 225));
            drawwing.WriteAt("NOW, are you ready?(press Enter)", 35, 19, back: _back, fore: Color.FromArgb(120, 1, 225));
            ConsoleB.SetCursorPosition(35, 15);
            feed.body = snake_body;
            while (true)
            {
                drawwing.WriteAt("press Enter", 55, 19, back: _back, fore: Color.PowderBlue);
                drawwing.WriteAt("press Enter", 55, 19, back: _back, fore: Color.Red);
                Thread.Sleep(100);
                drawwing.WriteAt("press Enter", 55, 19, back: _back, fore: Color.PowderBlue);
                if (ConsoleB.ReadKey(true).Key == ConsoleKey.Enter)
                    break;
                Thread.Sleep(50);
            }
            drawwing.WriteAt("                                ", 35, 15);
            drawwing.WriteAt("                                            ", 35, 16);
            drawwing.WriteAt("                          ", 35, 17);
            drawwing.WriteAt("                                ", 35, 19);
        }
        void snake_drawHead(int[] head, Color fore_)
        {
            //draw snake head
            //drawwing.WriteAt((char)snake_dir, head[0], head[1]);
            drawwing.WriteAt('¤', head[0], head[1],fore:fore_,back: _back);
        }
        static public void snake_reset(int[] tail)
        {
            if (tail == null)
                return;
            drawwing.WriteAt("  ", tail[0], tail[1]);
        }
        void snake_drawBody(int[] body)
        {
            drawwing.WriteAt('☉', body[0], body[1], fore:Color.Firebrick,back: _back);
        }
        void snake_move_normal()
        {
            switch (snake_dir)
            {
                //move up
                case snake_head.UP:
                    snake_body.Insert(0, new int[] { snake_body[0][0], snake_body[0][1] - 1 });
                    snake_reset(snake_body[snake_body.Count() - 1]); // reset should be here, in case,,, you know
                    snake_drawBody(snake_body[1]);
                    snake_drawHead(snake_body[0],Color.Indigo);
                    snake_body.RemoveAt(snake_body.Count() - 1);
                    break;
                // move down
                case snake_head.DOWN:
                    snake_body.Insert(0, new int[] { snake_body[0][0], snake_body[0][1] + 1 });
                    snake_reset(snake_body[snake_body.Count() - 1]);
                    snake_drawHead(snake_body[0],Color.Indigo);
                    snake_drawBody(snake_body[1]);
                    snake_body.RemoveAt(snake_body.Count() - 1);
                    break;

                // move left 
                case snake_head.LEFT:
                    snake_body.Insert(0, new int[] { snake_body[0][0] - 2, snake_body[0][1] });
                    snake_reset(snake_body[snake_body.Count() - 1]);
                    snake_drawHead(snake_body[0],Color.Indigo);
                    snake_drawBody(snake_body[1]);
                    snake_body.RemoveAt(snake_body.Count() - 1);
                    break;
                // move right
                case snake_head.RIGHT:
                    snake_body.Insert(0, new int[] { snake_body[0][0] + 2, snake_body[0][1] });
                    snake_reset(snake_body[snake_body.Count() - 1]);
                    snake_drawHead(snake_body[0],Color.Indigo);
                    snake_drawBody(snake_body[1]);
                    snake_body.RemoveAt(snake_body.Count() - 1);
                    break;
            }

        }


        //void WriteAt(char s, int x, int y)
        //{

        //    Console.SetCursorPosition(x, y);
        //    Console.Write(s);
        //}
        //void WriteAt(string s, int x, int y)
        //{

        //    Console.SetCursorPosition(x, y);
        //    Console.Write(s);
        //}
        bool snake_check()
        {
            var head_pos = new int[] { snake_body[0][0], snake_body[0][1] };
            switch (snake_dir)
            {
                case snake_head.UP:
                    head_pos[1] -= 1;
                    break;
                case snake_head.DOWN:
                    head_pos[1] += 1;
                    break;
                case snake_head.LEFT:
                    head_pos[0] -= 2;
                    break;
                case snake_head.RIGHT:
                    head_pos[0] += 2;
                    break;
            }
            if (head_pos[0] < 2 || head_pos[0] > 107 || head_pos[1] < 1 || head_pos[1] > 29)
                return false;

            //if the direction isn't changing there is no need to check



            //check if eat itself
            var limit = snake_body.Count - 1;
            for (int i = 1; i != limit; ++i)
            {
                if (snake_body[0].SequenceEqual(snake_body[i]))
                {
                    // eat it self

                    // animation goes here
                    return false;
                }
            }
            // if eat the tail, trigger the roop animation
            if (snake_body[limit]!=null) {
                if (snake_body[0].SequenceEqual(snake_body[limit]))
                {
                    eat_tail();
                    //drawwing.WriteAt("most delicious", 50, 15, ConsoleColor.Red);
                    return false;
                }

            }

            try
            {
                foreach (var iter in feed.food_table)
                {
                    if (iter.SequenceEqual(snake_body[0]))
                    {
                        feed.eaten(iter);
                        snake_body.Add(null);
                        return true;
                    }
                }
            }
            catch (InvalidOperationException)
            {
                return true;
            }

            return true;
        }
        //public void key_pressed()
        //{
        //    while (true)
        //    {
        //           if (buf.Count < 4)
        //            {
        //            lock (buf)
        //            {
        //                buf.Add(Console.ReadKey(true));

        //            }
        //            }
        //    }
        //}
        public void key_handler()
        {
            // could it be: press a key after we just pass the test;
            while (true)
            {
                Thread.Sleep(1);
                //if(buf.Count<3)
                //    buf.Add(Console.ReadKey(true));
                // check if it is valid key
                //if (key_waiting) continue;
                key = ConsoleB.ReadKey(true);
                snake_head cur_dir = snake_dir;

                // if the key enter is valid
                try
                {
                    cur_dir = key_map[key.Key];
                }
                catch (KeyNotFoundException)
                {
                    continue;
                }


                // this piece change the speed of the snack
                if ((key.Modifiers & ConsoleModifiers.Shift) != 0)
                {
                    speed = 100;
                }
                else
                {
                    // if the key was not pressed
                    speed = normal_speed;
                }


                // if it's not a logical key
                if (cur_dir == snake_dir || cur_dir - snake_dir == -1 || cur_dir - snake_dir == 1)
                {
                    continue;
                }
                //key_waiting = true;
                snake_dir = cur_dir;
                Thread.Sleep(speed);
                //++press;


                //switch (key.Key)
                //{
                //    case ConsoleKey.UpArrow:
                //        snake_dir = snake_head.UP;
                //        ++press;
                //        key_waiting = true;
                //        break;
                //    case ConsoleKey.DownArrow:
                //        snake_dir = snake_head.DOWN;
                //        ++press;
                //        key_waiting = true;
                //        break;
                //    case ConsoleKey.LeftArrow:
                //        snake_dir = snake_head.LEFT;
                //        ++press;
                //        key_waiting = true;
                //        break;
                //    case ConsoleKey.RightArrow:
                //        ++press;
                //        snake_dir = snake_head.RIGHT;
                //        key_waiting = true;
                //        break;
                //}
            }
        }
        public void action()
        {
            //ThreadStart act = new ThreadStart(pase_fuc);
            //Thread actThread = new Thread(act);
            //actThread.Start();
            while (true)
            {
                Thread.Sleep(speed);
                if (snake_check())
                {
                    snake_move_normal();
                    //key_waiting = false;
                }
                else
                    return;                // if the snake hit something, stop moving
            }
            // ctrol the snacks movement
        }
        // i failed to make the thread take the parameter so I make this method static
        void change_speed(int cur_speed)
        {
            speed = cur_speed;
        }
        //public static void shift_prssed()
        //{
        //    while (true)
        //    {
        //        if((key.Modifiers& ConsoleModifiers.Shift )!= 0)
        //        {
        //            change_speed(100);
        //        }
        //        else
        //        {
        //            // if the key was not pressed
        //            change_speed(200);
        //        }
        //        Thread.Sleep(100);
        //    }
        //}
        void eat_tail()
        {
            //Thread.Sleep(2000);
            snake_drawHead(snake_body[0], Color.Red);
            for (int i = 0; i != 5; ++i)
            {
                Thread.Sleep(500 - i*100);
                snake_drawHead(snake_body[0],Color.Indigo);
                Thread.Sleep(70);
                snake_drawHead(snake_body[0], Color.Red);
            }
            for (int i = snake_body.Count - 2; i > 0; --i)
            {
                Thread.Sleep(70);
                snake_drawHead(snake_body[i], Color.Red);
                snake_reset(snake_body[i + 1]);
            }
            drawwing.WriteAt("delicious =_=", 45, 15, fore: Color.Red, back: _back);
            Thread.Sleep(4000);

            //var buf = snake_body[1];
            //snake_body.Clear();
            //snake_body.Add(buf);
        }
        public static void write_time()
        {
            while (true)
            {
                //string t = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
                //drawwing.WriteAt("        ",100, 0, back: ConsoleColor.White, fore: ConsoleColor.DarkMagenta);
                //drawwing.WriteAt(t, 100, 0, back: ConsoleColor.White, fore: ConsoleColor.DarkMagenta);
                drawwing.WriteAt(DateTime.Now.ToLongTimeString(), 100, 0, back: Color.White, fore: Color.Indigo);
                Thread.Sleep(1000);
            }
        }
        public List<int[]> body()
        {
            return snake_body;
        }
    }
    public class feed
    {
        public static List<int[]> body = null;
        static Color _back = Color.FromArgb(187, 207, 213);

        // alternator 
        ColorAlternatorFactory alternatorFactory = new ColorAlternatorFactory();
        ColorAlternator alternator;
        public static List<int[]> food_table = new List<int[]>();
        public static int cur_score = 0;
        int max_food = 3;
        //ConsoleColor fore_color = ConsoleColor.Blue;
        //ConsoleColor back_color = ConsoleB.BackgroundColor;
        Random gen;
        //public static int total = 0;
        public feed()
        {
            alternator = alternatorFactory.GetAlternator(1, Color.Plum, Color.PaleVioletRed,Color.HotPink,
                Color.BlueViolet,Color.DarkOrange);
            gen = new Random();
        }

        public void generator()
        {
            var last_second = DateTime.Now.Second;
            var cur_second = DateTime.Now.Second;
            Out:
            while (true)
            {

                Thread.Sleep(1);
                cur_second = DateTime.Now.Second;
                //drawwing.WriteAt(food_table.Count.ToString(), 0, 32);
                if(food_table.Count > max_food)
                {
                    if (cur_second - last_second > 3|last_second-cur_second>3)
                    {
                        last_second = cur_second;
                        snake.snake_reset(food_table[0]);
                        food_table.RemoveAt(0);
                    }
                    Thread.Sleep(1000);
                    continue;
                }
                int[] new_pos = new int[] { gen.Next(2, 106), gen.Next(1, 29) };
                if (new_pos[0] % 2 != 0)
                    new_pos[0] += 1;
                foreach(var pos in body)
                {
                    try
                    {
                        if (pos.SequenceEqual(new_pos))
                        {
                            goto Out;
                        }
                    }
                    catch
                    {
                        goto Out;
                    }
                }
                food_table.Add(new_pos);  // add the new food to table
                //++total;
                drawwing.WriteAt('●', new_pos[0], new_pos[1], alternator);
                //if (cur_second - last_second > 5)
                //{
                //    last_second = cur_second;
                //    snake.snake_reset(food_table[0]);
                //    food_table.RemoveAt(0);
                //}
                Thread.Sleep(2000);
            }
        }
        public static void score()
        {
            drawwing.WriteAt("SCORE : " + (cur_score * 10).ToString(), 0, 32, fore: Color.Indigo, back: _back);
        }
        static public void eaten(int[] pos)
        {
            ++cur_score;
            if(snake.normal_speed >= 100)
            {
                snake.normal_speed -= 5;
            }
            score();
            //when the food is eaten, decrease the total
            for (var iter = 0; iter < food_table.Count; ++iter)
            {
                if (food_table[iter].SequenceEqual(pos))
                {
                    food_table.RemoveAt(iter);
                    break;
                }
            }
        }
    }
}
// key press should be handled outside