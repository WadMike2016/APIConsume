using MarvelApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelApi
{
    public class StarWarsRequester:Requester
    {
        public StarWarsRequester():base("http://swapi.co/api/")
        {

        }

        public List<PersoSW> GetPersos(string Endpoint = "people/")
        {
           
            string json = base.Execute(Endpoint,"");
            if (json != "")
            {
                List<PersoSW> lc = null;
                StarwarResult cd = JsonConvert.DeserializeObject<StarwarResult>(json);

                if (cd.results.Count>0)
                {
                    
                        lc = cd.results;
                    
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
