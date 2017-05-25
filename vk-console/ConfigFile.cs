using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace vk_console
{
    class ConfigFile
    {
        public static void CheckConfigFile()
        {
            if (System.IO.File.Exists("config.json") != true)
            {
                GenerateConfigFile();
            }
        }

        public static JObject Parse()
        {
            CheckConfigFile();
            return JObject.Parse(File.ReadAllText("config.json"));
        }

        public static void GenerateConfigFile()
        {
            PiniginFunctions.WriteColorLine("WARNING: config.json not found!", ConsoleColor.Yellow);
            Console.WriteLine("===== WELCOME TO PINIGIN VK CONSOLE =====");
            Console.Write("Please, enter your id: "); string user_id = Console.ReadLine();
            PiniginFunctions.WriteColorLine("TIP: To get token authorize here: https://vk.cc/6n64Jy", ConsoleColor.Cyan);
            Console.Write("Enter your token: "); string access_token = Console.ReadLine();
            var user = VkApi.GetUser(access_token, Int32.Parse(user_id), "id,first_name,last_name,deactivated,hidden");
            //Console.WriteLine("Hello, " + user["first_name"] + "!");
            string config = "{\"user_id\":"+ user_id + ",\"access_token\":\"" + access_token + "\"}";
            File.WriteAllText("config.json",config);
            PiniginFunctions.WriteColorLine("config.json created", ConsoleColor.Green);
            Console.WriteLine("Please restart program");
            Environment.Exit(0);
        }
    }
}
