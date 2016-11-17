
namespace MarvelApi.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class StoryLists
    {
        
      
    
        public int id { get; set; }
        public int available { get; set; }
        public int returned { get; set; }
        public string collectionURI { get; set; }
    
        
        public  List<Characters> Characters { get; set; }
    }
}
