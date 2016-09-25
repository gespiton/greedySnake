using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class init
{
    //protected static int origRow;
    //protected static int origCol;
    static bool wait = false;
    const ConsoleColor fore_color = ConsoleColor.Black;
    const ConsoleColor back_color = ConsoleColor.DarkCyan;
    public static void WriteAt(string s, int x, int y,ConsoleColor fore = ConsoleColor.Black,ConsoleColor back = ConsoleColor.DarkCyan)
    {
        while (wait) { }
        try
        {
            wait = true;
            Console.ForegroundColor = fore;
            Console.BackgroundColor = back;
            Console.SetCursorPosition(x, y);
            Console.Write(s);
            Console.ForegroundColor = fore_color;
            Console.BackgroundColor = back_color;
            wait = false;
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
        }
    }
    public static void WriteAt(char s, int x, int y, ConsoleColor fore = ConsoleColor.Black, ConsoleColor back = ConsoleColor.DarkCyan)
    {
        while (wait) { }
        try
        {
            wait = true;
            Console.ForegroundColor = fore;
            Console.BackgroundColor = back;
            Console.SetCursorPosition(x, y);
            Console.Write(s);
            Console.ForegroundColor = fore_color;
            Console.BackgroundColor = back_color;
            wait = false;
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
        }
    }

    public static void draw()
    {
        // set the console size
        Console.SetWindowSize(110,35);
        Console.BufferHeight = 35;
        Console.BufferWidth = 110;
        // Clear the screen
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.Clear();
        Console.CursorVisible = false;


        // draw outline
        //origRow = 0;
        //origCol = 0;

        //Console.BackgroundColor = ConsoleColor.White; // if this line is above console.clear() the whole background will be white

        for(int i =0;i < 31; ++i)
        {
            WriteAt("  ", 0, i,back:ConsoleColor.White);
        }
        for(int i = 0; i < 110; ++i)
        {
            WriteAt(" ", i, 0,back:ConsoleColor.White);
        }
        for (int i = 0; i < 110; ++i)
        {
            WriteAt(" ", i, 30,back:ConsoleColor.White);
        }
        for (int i = 1; i < 31; ++i)
        {
            WriteAt("  ", 108, i,back:ConsoleColor.White);
        }
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.ForegroundColor = ConsoleColor.Black;
        WriteAt("craft by @ sher", 90, 34);
    }
}
