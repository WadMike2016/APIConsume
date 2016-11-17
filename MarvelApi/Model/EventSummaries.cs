namespace MarvelApi.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class EventSummaries
    {
        public int id { get; set; }
        public string resourceURI { get; set; }
        public string name { get; set; }
        public int? EventId { get; set; }
    
        public  EventLists EventLists { get; set; }
    }
}
