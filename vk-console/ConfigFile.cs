using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

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
            var config_file = JObject.Parse(File.ReadAllText("config.json"));
            return config_file;
        }

        public static void GenerateConfigFile()
        {
            //PiniginFunctions.WriteColorLine("WARNING: config.json not found!", ConsoleColor.Yellow);
            Console.WriteLine("===== WELCOME TO PINIGIN VK CONSOLE =====");
            Console.Write("Please, enter your id: "); string user_id = Console.ReadLine();
            PiniginFunctions.WriteColorLine("TIP: To get token authorize here: https://vk.cc/6n64Jy", ConsoleColor.Cyan);
            Console.Write("Enter your token: "); string access_token = Console.ReadLine();
            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.vk.com");
            var request = new RestRequest();
            request.Resource = $"/method/users.get?&access_token={access_token}&v=5.64&lang=en";
            IRestResponse response = client.Execute(request);
            var user_info = JObject.Parse(response.Content);
            if((string)user_info["response"][0]["id"] == user_id)
            {
                //Console.WriteLine("Hello, " + user["first_name"] + "!");
                string config = "{\"user_id\":" + user_id + ",\"access_token\":\"" + access_token + "\"}";
                File.WriteAllText("config.json", config);
                File.SetAttributes("config.json", FileAttributes.ReadOnly);
                PiniginFunctions.WriteColorLine("config.json created", ConsoleColor.Green);
                Console.WriteLine("Please restart program");
                Environment.Exit(0);
            }
            else
            {
                PiniginFunctions.WriteColorLine("Token or id do not match", ConsoleColor.Red);
            }
        }
    }
}
