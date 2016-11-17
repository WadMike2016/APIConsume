
namespace MarvelApi.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ComicSummaries
    {
        public int id { get; set; }
        public string resourceURI { get; set; }
        public string name { get; set; }
        public int? ComicId { get; set; }
    
        public  ComicLists ComicLists { get; set; }
    }
}
