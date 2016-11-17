using System.Collections.Generic;

namespace MarvelApi.Model
{
    public class CharacterDataContainer
    {
        public int offset;// The requested offset(number of skipped results) of the call.,
        public int limit;//The requested result limit.,
        public int total;// The total number of resources available given the current filter set.,
        public int count;// The total number of results returned by this call.,
        public List<Characters> results;// The list of characters returned by the call.
    }
}