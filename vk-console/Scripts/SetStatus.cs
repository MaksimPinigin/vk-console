using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_console.Scripts
{
    class SetStatus
    {
        public static void Execute(string input_text)
        {
            if(input_text.Split(' ').Length > 1)
            {
                var status = input_text.Replace("setstatus ", "");
                var config = ConfigFile.Parse();
                var response = VkApi.SetStatus((string)config["access_token"], status);
                if((string)response["response"] == "1")
                {
                    Console.WriteLine("Status changed");
                }
                else
                {
                    PiniginFunctions.WriteColorLine("ERROR: " + response.ToString(), ConsoleColor.Red);
                }
            }
            else
            {
                Console.WriteLine("Usage: setstatus <text>");
            }
        }
    }
}
