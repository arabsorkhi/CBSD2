using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CBSD.Framwork.Tools
{
    internal class Jtoken
    { 
        static async Task Main(string[] args)
        {
            string url = "http://coderbyte.com/api/challenges/json/json-cleaning";
            string response = await GetJsonDataAsync(url);

            JObject jsonObject = JObject.Parse(response);
            JObject cleanedObject = CleanJson(jsonObject);

            Console.WriteLine(cleanedObject.ToString());
        }

        static async Task<string> GetJsonDataAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        static JObject CleanJson(JObject json)
        {
            // __define-ocg__ This function cleans a JSON object by removing keys with unwanted values
            var propertiesToRemove = json.Properties()
                .Where(p => ShouldRemove(p.Value))
                .ToList();

            foreach (var prop in propertiesToRemove)
            {
                prop.Remove();
            }

            foreach (var prop in json.Properties())
            {
                if (prop.Value is JObject obj)
                {
                    CleanJson(obj);
                }
                else if (prop.Value is JArray array)
                {
                    CleanArray(array);
                }
            }

            return json;
        }

        static void CleanArray(JArray array)
        {
            for (int i = array.Count - 1; i >= 0; i--)
            {
                if (ShouldRemove(array[i]))
                {
                    array.RemoveAt(i);
                }
                else if (array[i] is JObject obj)
                {
                    CleanJson(obj);
                }
                else if (array[i] is JArray arr)
                {
                    CleanArray(arr);
                }
            }
        }

        static bool ShouldRemove(JToken token)
        {
            var varOcg = token.Type;
            return varOcg == JTokenType. String 
                   &&  token == null//"N/A" 
                   ||
                   (string)token == "-" ||
                   (string)token == "";
        }
    }



}
 
