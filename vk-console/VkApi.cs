using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

/*
 * VK API for C#
 * Author: Maksim Pinigin
 * Year(s): 2017
 */

namespace vk_console
{
    class VkApi
    {
        static int client_id = -1;
        static string client_secret = "";
        static string service_key = "";
        static string secure_key = "";
        static string api_version = "5.62";
        static string api_language = "en";
        static Uri base_url = new Uri("https://api.vk.com");

        public static JToken GetUser(string access_token, int user_id, string fields)
        {
            var client = new RestClient();
            client.BaseUrl = base_url;
            var request = new RestRequest();
            request.Resource = $"/method/users.get?user_id={user_id}&fields={fields}&access_token={access_token}&v={api_version}&lang={api_language}";
            IRestResponse response = client.Execute(request);
            JObject user_array = JObject.Parse(response.Content);
            return user_array["response"][0];
        }

        
    }
}
