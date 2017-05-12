using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace KiteApp.Models
{
    public class Location
    {
        public string Zip { get; set; }
        public string Wind { get; set; }
        public string Speed { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }
        //public string CountryCode { get; set; }

        public Location (string zip)
        {
            Zip = zip;
        }

        public List<Location> GetSpeeds()
        {
            var client = new RestClient("http://api.openweathermap.org/data/2.5/forecast?"); // fill in correct http
            var request = new RestRequest("zip=" + Zip + ",us&APPID=" + EnvironmentVariables.AccountSID, Method.GET);

            //client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.AccountSID); // probably dont need because no auth token - just a weather API
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            //var speedList = JsonConvert.DeserializeObject<List<Location>>(jsonResponse["list"].ToString()); //check if called locations

            var speedList = JsonConvert.DeserializeObject<List<Location>>(jsonResponse["list.wind.speed"].ToString()); //check if called locations   --- extra option just incase the other doesnt work.
            return speedList;
        }

        public void Send()
        {
            var client = new RestClient("http://api.openweathermap.org/data/2.5/forecast?");
            var request = new RestRequest("zip=" + Zip + ",us&APPID=" + EnvironmentVariables.AccountSID, Method.POST); // Fill these in with weather APp info - do we need an Auth Token?????????
            request.AddParameter("zip", Zip); //choose parameter
            //request.AddParameter("speed", Speed); //choose parameter
            //client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.AccountSID); // probably dont need because no auth token - just a weather API
            client.ExecuteAsync(request, response =>
            {
                Console.WriteLine(response.Content);
            });
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
