using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConsoleB = Colorful.Console;
//using Colorful;
using System.Drawing;
using Colorful;

class drawwing
{
    static Color _back = Color.FromArgb(187, 207, 213);
    static object lock_write = new object();
    public static void WriteAt(string s, int x, int y,Color fore, Color back)
    {
        lock (lock_write)
        {
            ConsoleB.ForegroundColor = fore;
            ConsoleB.BackgroundColor = back;
            ConsoleB.SetCursorPosition(x, y);
            ConsoleB.Write(s);
        }
    }
    public static void WriteAt(string s, int x, int y)
    {
        lock (lock_write)
        {
            ConsoleB.ForegroundColor = Color.White;
            ConsoleB.BackgroundColor = _back;
            ConsoleB.SetCursorPosition(x, y);
            ConsoleB.Write(s);
            //ConsoleB.ForegroundColor = Color.White;
            //ConsoleB.BackgroundColor = Color.DarkCyan;
        }
    }
    public static void WriteAt(char s, int x, int y, Color fore, Color back)
    {
        lock (lock_write)
        {
            ConsoleB.ForegroundColor = fore;
            ConsoleB.BackgroundColor = back;
            ConsoleB.SetCursorPosition(x, y);
            ConsoleB.Write(s);
            //ConsoleB.ForegroundColor = Color.White;
            //ConsoleB.BackgroundColor = Color.White;
        }
    }
    public static void WriteAt(char s, int x, int y,ColorAlternator alter)
    {
        lock (lock_write)
        {
            //ConsoleB.ForegroundColor = fore;
            //ConsoleB.BackgroundColor = back;
            ConsoleB.BackgroundColor = _back;
            ConsoleB.SetCursorPosition(x, y);
            ConsoleB.WriteAlternating(s,alter);
            //ConsoleB.ForegroundColor = Color.White;
            //ConsoleB.BackgroundColor = Color.White;
        }
    }

    public static void draw()
    {
        // set the console size
        ConsoleB.SetWindowSize(110,35);
        ConsoleB.SetBufferSize(110, 35);
        // Clear the screen
        ConsoleB.BackgroundColor = _back;
        ConsoleB.Clear();
        //Console.Clear();
        //Console.BackgroundColor = ConsoleColor.DarkCyan;
        //ConsoleB.BackgroundColor = Color.DarkCyan;
        //ConsoleB.Clear();
        ConsoleB.CursorVisible = false;


        // draw outline
        //origRow = 0;
        //origCol = 0;

        //Console.BackgroundColor = ConsoleColor.White; // if this line is above console.clear() the whole background will be white

        // use for loop to decrease the byte of the program
        for(int i =0;i < 31; ++i)
        {
            WriteAt("  ", 0, i,back:Color.White,fore:Color.White);
            WriteAt("  ", 108, i,back:Color.White,fore:Color.White);
            WriteAt(" ", 2, i, back: _back, fore: _back);
            WriteAt(" ", 107, i, back: _back, fore: _back);
            Thread.Sleep(15);
        }
        for(int i = 0; i < 110; ++i)
        {
            WriteAt(" ", i, 0, back: Color.White, fore: Color.White);
            WriteAt(" ", i, 30, back: Color.White, fore: Color.White);
            Thread.Sleep(15);
        }

        ConsoleB.BackgroundColor = _back;
        ConsoleB.ForegroundColor = Color.White;
        WriteAt("craft by @ sher", 94, 34, back: _back, fore: Color.White);
    }

    public static void ha_youDied()
    {
        var co = ConsoleColor.Yellow;
        var coo = ConsoleColor.Red;
        //ConsoleB.SetCursorPosition(86, 34);
        //ConsoleB.BackgroundColor = _back;
        //ConsoleB.Write("Press space to restart", Color.Blue);
        while (true)
        {
            ConsoleB.SetCursorPosition(0, 20);
            ConsoleB.BackgroundColor = _back;
            System.Console.ForegroundColor = co;
            //ConsoleB.Write("haha", co);
            System.Console.Write(@"
                   __ __                                              __
                  / // / ___ _ ___ _          __ __ ___  __ __       / / ___   ___ ___
                 / _  / / _ `// _ `/ _       / // // _ \/ // /      / / / _ \ (_-</ -_)
                /_//_/  \_,_/ \_,_/ ( )      \_, / \___/\_,_/      /_/  \___//___/\__/
                                    |/      /___/
                space to continue
", 0, 20);
            Thread.Sleep(200);
            var buf = co;
            co = coo;
            coo = buf;
            //}
        }
    }
    public static void death_comic(int score)
    {
        string buf="     "+"SCORE : " + (score * 10).ToString();
        ConsoleB.BackgroundColor = _back;
        ConsoleB.Clear();
        for(int i = 10; i >= 0; --i)
        {
            ConsoleB.BackgroundColor = _back;
            ConsoleB.SetCursorPosition(0, 14);
            Thread.Sleep(70);
            ConsoleB.WriteAscii(buf.Remove(0,i), color: Color.Black);
        }
    }
    public static void window_jump()
    {
        while (true)
        {
            ConsoleB.SetWindowSize(105, 32);
            ConsoleB.SetBufferSize(105, 32);
            Thread.Sleep(150);
            ConsoleB.SetWindowSize(110, 35);
            ConsoleB.SetBufferSize(110, 35);
            Thread.Sleep(100);
        }
    }
}
