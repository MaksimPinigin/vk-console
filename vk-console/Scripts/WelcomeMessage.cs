using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_console.Scripts
{
    class WelcomeMessage
    {
        public static void Execute()
        {
            var config = ConfigFile.Parse();
            var user = VkApi.GetUser((string)config["access_token"], (int)config["user_id"], "first_name,last_name");
            Console.WriteLine("Hello, " + user["first_name"] + "!");
        }
    }
}
