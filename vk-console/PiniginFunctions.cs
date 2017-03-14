using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_console
{
    class PiniginFunctions
    {
        public static void WriteColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void WriteColorLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static string ReadColorLine(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            string return_string = Console.ReadLine();
            Console.ResetColor();
            return return_string;
        }
    }
}
