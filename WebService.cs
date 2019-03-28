using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleGithubSearch
{
    public class WebService
    {

        private async Task<List<RootObject>> GetData(string url){
            HttpClient client = new HttpClient();
            List<RootObject> model = null;
            string data = "";
            try
            {
                client.DefaultRequestHeaders.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

                data = await client.GetStringAsync(url);

                model = JsonConvert.DeserializeObject<List<RootObject>>(data);
                
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught");
                data = e.Message;
            }
            return model;
        }

        public List<RootObject> GetService(string url){
            Task<List<RootObject>> callTask = Task.Run(() => GetData(url));
            callTask.Wait();

            List<RootObject> result = callTask.Result;
            return result;
            }
    }
}