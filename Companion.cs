using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5b
{
    class Companion
    {
        public string name { get; set; }

        public string actor { get; set; }
        public string doctorid { get; set; }
        public string storyid { get; set; }
        public Companion(string NAME, string ACTOR, string DOCTORID, string STORYID)
        {
            name = NAME;
            actor = ACTOR;
            storyid = STORYID;
            doctorid = DOCTORID;

        }
        public Companion()
        {
            
        }
    }
}
