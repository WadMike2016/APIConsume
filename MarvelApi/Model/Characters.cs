namespace MarvelApi.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Characters
    {
               
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime modified { get; set; }
        public string resourceURI { get; set; }
        public int? comics_id { get; set; }
        public int? events_id { get; set; }
        public int? series_id { get; set; }
        public int? stories_id { get; set; }
    
        public  ComicLists ComicLists { get; set; }
        public  EventLists EventLists { get; set; }
        public  Images thumbnail { get; set; }
        public  SeriesLists SeriesLists { get; set; }
        public  StoryLists StoryLists { get; set; }
        
        public  List<Urls> Urls { get; set; }

        public string Avatar
        {
            get
            {
                if (thumbnail != null)
                {
                    return thumbnail.path + @"/portrait_xlarge." + thumbnail.extension;
                }
                else
                    return "";
            }
        }
    }
}
