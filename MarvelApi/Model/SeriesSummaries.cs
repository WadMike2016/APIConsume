namespace MarvelApi.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SeriesSummaries
    {
        public int id { get; set; }
        public string resourceURI { get; set; }
        public string name { get; set; }
        public int? SerieId { get; set; }
    
        public  SeriesLists SeriesLists { get; set; }
    }
}
