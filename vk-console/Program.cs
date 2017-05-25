using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pinigin VK Console (c) 2017, Maksim Pinigin");
            ConfigFile.CheckConfigFile();
            Scripts.WelcomeMessage.Execute();
            Console.WriteLine("Starting Pinigin Shell...");
            PiniginShell.Shell("VK> ");
        }
    }
}
