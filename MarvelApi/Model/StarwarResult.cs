using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelApi.Model
{
    public class StarwarResult
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<PersoSW> results { get; set; }
    }
}
