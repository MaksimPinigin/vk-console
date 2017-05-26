using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_console
{
    class CommandHandler
    {
        public static void Handle(string input_text, string[] args)
        {
            if(args[0] == "exit")
            {
                Environment.Exit(0);
            }
            else if(args[0] == "")
            {
                // none
            }
            else if(args[0] == "setstatus")
            {
                Scripts.SetStatus.Execute(input_text);
            }
            else if(args[0] == "setonline")
            {
                Scripts.SetOnline.Execute();
            }
            else
            {
                PiniginFunctions.WriteColorLine("ERROR: Command not found", ConsoleColor.Red);
            }
        }
    }
}
