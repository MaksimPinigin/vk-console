using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_console.Scripts
{
    class Post
    {
        public static void Execute(string input_text)
        {
            string[] param = input_text.Split(' ');
            if (param.Length > 1)
            {
                var config = ConfigFile.Parse();
                if (int.TryParse(param[1], out int result))
                {
                    int owner_id = result;
                    string text = input_text.Replace("post " + param[1] + " ", "");
                    var response = VkApi.WallPost((string)config["access_token"], owner_id, text);
                    try
                    {
                        Console.WriteLine("Post created. Id: " + response["response"]["post_id"]);
                    }
                    catch
                    {
                        PiniginFunctions.WriteColorLine(response.ToString(), ConsoleColor.Red);
                    }
                }
                else
                {
                    int owner_id = (int)config["user_id"];
                    string text = input_text.Replace("post ", "");
                    var response = VkApi.WallPost((string)config["access_token"], owner_id, text);
                    try
                    {
                        Console.WriteLine("Post created. Id: " + response["response"]["post_id"]);
                    }
                    catch
                    {
                        PiniginFunctions.WriteColorLine(response.ToString(), ConsoleColor.Red);
                    }
                }
            }
            else
            {
                Console.WriteLine("Usage: post [owner id] <text>");
            }
        }
    }
}
