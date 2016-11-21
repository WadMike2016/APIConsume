using MarvelApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelApi
{
    public class MarvelRequester: Requester
    {

        /// <summary>
        /// A timespan to compose eventually a hash
        /// </summary>
        private static TimeSpan t = new TimeSpan();
        /// <summary>
        /// The public key if necessary
        /// </summary>
        private static string Key = "xxxxxx";
        /// <summary>
        /// The private key if necessary
        /// </summary>
        private static string pKey = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
        /// <summary>
        /// The hash to compute 
        /// </summary>
        private static string hash;
        /// <summary>
        /// The URL parameters if necessary
        /// </summary>
        private string urlParameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarvelRequester"/> class.
        /// </summary>
        public MarvelRequester():base("https://gateway.marvel.com/")
        {
            
        }

        public List<Characters> GetCharacters(int limit = 1, int offset = 200, string Endpoint = "v1/public/characters")
        {
            //Marvel accept a maximum of 100 character by requests
            if (limit > 100)
            {
                throw new InvalidOperationException("Limit 0 to 100 only");
            }
            //1- Get the time
            t = DateTime.Now.TimeOfDay;
            //2- Calculate hash in accordance with marvel documentation
            hash = Tools.CalculateMD5LikeMarvel(t,pKey).ToLower();
            //3- Prepare the parameters
            urlParameters = "?ts=" + t.ToString().Replace(":", "").Replace(".", "") + "&limit=" + limit + "&offset=" + offset + "&apikey=" + Key + "&hash=" + hash;

            //4- Get the json response from marvel API
            string json = base.Execute(Endpoint, urlParameters);
            if (json != "")
            {
                List<Characters> lc = null;
                CharacterDataWrapper cd = JsonConvert.DeserializeObject<CharacterDataWrapper>(json);

                if(cd.data!=null)
                {
                    CharacterDataContainer CDC = cd.data;
                    if(CDC.results.Count>0)
                    {
                        lc = CDC.results;
                    }
                }

         
                return lc;
            }
            else
            {
                return null;
            }
        }
    }
}
