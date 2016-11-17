using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelApi.Model
{
    public class CharacterDataWrapper
    {
        public int code;// The HTTP status code of the returned result.,
        public string status;// A string description of the call status.,
        public string copyright;// The copyright notice for the returned result.,
        public string attributionText;// The attribution notice for this result.Please display either this notice or the contents of the attributionHTML field on all screens which contain data from the Marvel Comics API.,
        public string attributionHTML; // An HTML representation of the attribution notice for this result. Please display either this notice or the contents of the attributionText field on all screens which contain data from the Marvel Comics API.,
        public CharacterDataContainer data;// The results returned by the call.,
        public string etag;// A digest value of the content returned by the call
    }
}
