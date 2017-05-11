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
        public int Zip { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }

        public static List<Location> GetLocations()
        {
            var client = new RestClient("httttpp"); // fill in correct http
            var request = new RestRequest("request of site and how it works", Method.GET);
            client.Authenticator = new HttpBasicAuthenticator("{{Account SID}}", "{{Auth Token}}"); //Fill these in with weather APp info
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<Object>(response.Content);
            var messageList = JsonConvert.DeserializeObject<List<Location>>(jsonResponse["locations"].ToString()); //check if called locations
            return locationList;
        }

        public void Send()
        {
            var client = new RestClient("hhhttttppp");
            var request = new RestRequest("Account//{{Account SSID}}/Locations", Method.POST); // Fill these in with weather APp info
            request.AddParameter(); //choose parameter
            request.AddParameter(); //choose parameter
            request.AddParameter(); //choose parameter
            client.Authenticator = new HttpBasicAuthenticator("{{Account SSID}}", "{{Auth Token}}");
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
