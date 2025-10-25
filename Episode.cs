using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5b
{
    class Episode
    {
        public string season { get; set; }
        public string seasonyear { get; set; }
        public string title { get; set; }
        public string storyid { get; set; }
        public Episode(string STORYID, string SEASON, string SEASONYEAR, string TITLE)
        {
            season = SEASON;
            seasonyear = SEASONYEAR;
            title = TITLE;
            storyid = STORYID;

        }
        public Episode()
        {

        }
    }
}
