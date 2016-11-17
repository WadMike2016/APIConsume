
namespace MarvelApi.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Urls
    {
        public int id { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public long? idCharacter { get; set; }
    
        public  Characters Characters { get; set; }
    }
}
