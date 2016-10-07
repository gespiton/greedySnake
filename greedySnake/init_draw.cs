using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConsoleB = Colorful.Console;
//using Colorful;
using System.Drawing;

class drawwing
{
    //protected static int origRow;
    //protected static int origCol;
    static object lock_write = new object();
    static bool wait = false;
    const ConsoleColor fore_color = ConsoleColor.Black;
    const ConsoleColor back_color = ConsoleColor.DarkCyan;
    public static void WriteAt(string s, int x, int y,ConsoleColor fore = ConsoleColor.Black,ConsoleColor back = ConsoleColor.DarkCyan)
    {
        //while (wait) {
        //    Thread.Sleep(1);
        //}
        //try
        //{

        //wait = true;
        lock (lock_write)
        {
            Console.ForegroundColor = fore;
            Console.BackgroundColor = back;
            Console.SetCursorPosition(x, y);
            Console.Write(s);
            Console.ForegroundColor = fore_color;
            Console.BackgroundColor = back_color;
        }
            //wait = false;
        //}
        //catch (ArgumentOutOfRangeException e)
        //{
        //    Console.Clear();
        //    Console.WriteLine(e.Message);
        //}
    }
    public static void WriteAt(char s, int x, int y, ConsoleColor fore = ConsoleColor.Black, ConsoleColor back = ConsoleColor.DarkCyan)
    {
        //while (wait) { }
        //try
        //{
        //wait = true;
        lock (lock_write)
        {
            Console.ForegroundColor = fore;
            Console.BackgroundColor = back;
            Console.SetCursorPosition(x, y);
            Console.Write(s);
            Console.ForegroundColor = fore_color;
            Console.BackgroundColor = back_color;
        }
        //wait = false;
        //}
        //catch (ArgumentOutOfRangeException e)
        //{
        //    Console.Clear();
        //    Console.WriteLine(e.Message);
        //}
    }

    public static void draw()
    {
        // set the console size
        Console.SetWindowSize(110,35);
        Console.SetBufferSize(110, 35);
        // Clear the screen

        ConsoleB.BackgroundColor = Color.DarkCyan;
        ConsoleB.Clear();
        //Console.Clear();
        //Console.BackgroundColor = ConsoleColor.DarkCyan;
        //ConsoleB.BackgroundColor = Color.DarkCyan;
        //ConsoleB.Clear();
        Console.CursorVisible = false;


        // draw outline
        //origRow = 0;
        //origCol = 0;

        //Console.BackgroundColor = ConsoleColor.White; // if this line is above console.clear() the whole background will be white

        // use for loop to decrease the byte of the program
        for(int i =0;i < 31; ++i)
        {
            WriteAt("  ", 0, i,back:ConsoleColor.White);
            WriteAt("  ", 108, i,back:ConsoleColor.White);
            WriteAt(" ", 2, i, back: ConsoleColor.DarkCyan);
            WriteAt(" ", 107, i, back: ConsoleColor.DarkCyan);
            Thread.Sleep(15);
        }
        for(int i = 0; i < 110; ++i)
        {
            WriteAt(" ", i, 0,back:ConsoleColor.White);
            WriteAt(" ", i, 30,back:ConsoleColor.White);
            Thread.Sleep(15);
        }
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.ForegroundColor = ConsoleColor.Black;
        WriteAt("craft by @ sher", 94, 34,fore:ConsoleColor.White);
    }

    public static void ha_youDied()
    {
        var co = Color.Yellow;
        var coo = Color.YellowGreen;
        while(true)
        {
            ConsoleB.SetCursorPosition(0, 20);
            ConsoleB.BackgroundColor = Color.DarkCyan;
            ConsoleB.WriteAscii("    Haa, you lose", co);
            //for (int i = 0; i < 31; ++i)
            //{
            //   drawwing.WriteAt("  ", 0, i, back: ConsoleColor.White);
            //}

            ConsoleB.SetCursorPosition(86, 34);
            ConsoleB.BackgroundColor = Color.DarkCyan;
            ConsoleB.Write("Press space to restart",Color.WhiteSmoke);
            //WriteAt("press space to restart", 50, 34,back:ConsoleColor.DarkCyan,fore:ConsoleColor.DarkGreen);
            Thread.Sleep(200);
            var buf = co;
            co = coo;
            coo = buf;
        }
    }
    public static void death_comic(int score)
    {
        string buf="     "+"SCORE : " + (score * 10).ToString();
        for(int i = 10; i >= 0; --i)
        {
            ConsoleB.BackgroundColor = Color.DarkCyan;
            ConsoleB.SetCursorPosition(0, 14);
            Thread.Sleep(70);
            ConsoleB.WriteAscii(buf.Remove(0,i), color: Color.Orange);
            //for (int ii = 14; ii < 25; ++ii)
            //{
            //    WriteAt("  ", 0, ii, back: ConsoleColor.White);
            //    //WriteAt("  ", 108, ii, back: ConsoleColor.White);
            //}
        }
    }
    public static void window_jump()
    {
        while (true)
        {
            Console.SetWindowSize(105, 32);
            Console.SetBufferSize(105, 32);
            Thread.Sleep(150);
            Console.SetWindowSize(110, 35);
            Console.SetBufferSize(110, 35);
            Thread.Sleep(100);
        }
    }
}
