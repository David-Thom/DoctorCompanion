using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5b
{
        
    class Doctor
    {
        public string id { get; set; }
        public string actor { get; set; }
        public string series { get; set; }
        public string age { get; set; }
        public byte[] picture { get; set; }
        public string debut { get; set; }
        public Doctor(string ID, string ACTOR, string SERIES, string AGE, string DEBUT, byte[] PICTURE)
        {
            id = ID;
            actor = ACTOR;
            series = SERIES;
            age = AGE;
            picture = PICTURE;
            debut = DEBUT;
        }
        public Doctor()
        {

        }
    }
}
