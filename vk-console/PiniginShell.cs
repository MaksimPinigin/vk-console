using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_console
{
    class PiniginShell
    {
        public static void Shell(string input_prefix = ">")
        {
            while (true)
            {
                Console.Write(input_prefix);
                string input_text = Console.ReadLine();
                string[] param = input_text.Split(' ');
                // Actions...
            }
        }
    }
}
