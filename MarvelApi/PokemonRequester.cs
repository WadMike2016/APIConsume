using MarvelApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelApi
{
    public class PokemonRequester:Requester
    {
        public PokemonRequester():base("http://pokeapi.co/api/v2/")
        {

        }

        public List<Pokemon> CatchThemAll(string Endpoint = "pokemon/", int offset=0)
        {
            string urlParameter = "";
            if (offset>0)
            {
                urlParameter = "?offset=" + offset.ToString();
            }

            string json = base.Execute(Endpoint, "");
            if (json != "")
            {
                List<Pokemon> lc = null;
                PokemonResults cd = JsonConvert.DeserializeObject<PokemonResults>(json);

                if (cd.results.Count > 0)
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
