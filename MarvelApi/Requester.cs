using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MarvelApi
{
    /// <summary>
    /// Basic Class to request an endpoint like marvel, ...
    /// </summary>
    /// <remarks>No security concepts are implemented</remarks>
    public abstract class Requester
    {
        /// <summary>
        /// The base url of service
        /// </summary>
        private string URL;
        



        public Requester(string baseUrl)
        {
            this.URL = baseUrl;
        }





        


        /// <summary>
        /// Executes the request to the specified end point.
        /// </summary>
        /// <param name="EndPoint">The end point to request.</param>
        /// <returns>A json string with endpoint response</returns>
        protected string Execute(string EndPoint, string urlParameters, bool JsonData=true)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL + EndPoint + urlParameters);

            if(JsonData)
            {
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            }
            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                Task<string> jsonString = response.Content.ReadAsStringAsync();

                jsonString.Wait();
                return jsonString.Result;

            }
            else
            {
                Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return "";
            }

        }
    }
}
