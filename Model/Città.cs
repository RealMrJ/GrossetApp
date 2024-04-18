using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrossetApp.Model
{
    public class Città
    {
        public class Coordinate
        {
            public string lat { get; set; }
            public string lng { get; set; }
        }

        public class Metadata
        {
            public string id { get; set; }
            public bool @private { get; set; }
            public DateTime createdAt { get; set; }
            public string name { get; set; }
        }

        public class Record
        {
            public string Stato { get; set; }
            public string Regione { get; set; }
            public string Provincia { get; set; }
            public string Sindaco { get; set; }
            public Coordinate Coordinate { get; set; }
            public int Altitudine { get; set; }
            public string Superficie { get; set; }
            public string Abitanti { get; set; }
            public string Densità { get; set; }
            public string Stemma { get; set; }
        }

        public class CityRoot
        {
            public Record record { get; set; }
            public Metadata metadata { get; set; }
        }

    }
}
