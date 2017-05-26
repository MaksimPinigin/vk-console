using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_console.Scripts
{
    class SetOnline
    {
        public static void Execute()
        {
            var config = ConfigFile.Parse();
            Console.Write("Setting online...");
            var response = VkApi.SetOnline((string)config["access_token"]);
            if((string)response["response"] == "1")
            {
                Console.Write("OK\n");
            }
            else
            {
                PiniginFunctions.WriteColorLine("ERROR: " + response.ToString(), ConsoleColor.Red);
            }
        }
    }
}
