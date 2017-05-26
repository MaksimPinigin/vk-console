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
        static int client_id = 5650592;
        static string client_secret = "OmLGswSuYrZJAcxmyVbO";
        static string service_key = "ec33f0bbec33f0bbec6252a1f9ec65c81beec33ec33f0bbb4fbc863b8bdce142e00f92d";
        static string secure_key = "667e154b667e154b662fb7512e66282deb6667e667e154b3eb70c842ef25c92d4712b4a";
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

        public static JObject SetStatus(string access_token, string text)
        {
            var client = new RestClient();
            client.BaseUrl = base_url;
            var request = new RestRequest();
            request.Resource = $"/method/status.set?text={text}&access_token={access_token}&v={api_version}&lang={api_language}";
            IRestResponse response = client.Execute(request);
            JObject api_response = JObject.Parse(response.Content);
            return api_response;
        }

        public static JObject SetOnline(string access_token)
        {
            var client = new RestClient();
            client.BaseUrl = base_url;
            var request = new RestRequest();
            request.Resource = $"/method/account.setOnline?access_token={access_token}&v={api_version}&lang={api_language}";
            IRestResponse response = client.Execute(request);
            JObject api_response = JObject.Parse(response.Content);
            return api_response;
        }
    }
}
