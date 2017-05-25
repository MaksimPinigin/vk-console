using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_console
{
    class CommandHandler
    {
        public static void Handle(string[] args)
        {
            if(args[0] == "exit")
            {
                Environment.Exit(0);
            }
            else if(args[0] == "")
            {
                // none
            }
            else
            {
                PiniginFunctions.WriteColorLine("ERROR: Command not found", ConsoleColor.Red);
            }
        }
    }
}
