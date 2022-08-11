using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel
{
    public class MoviesSimilarVM
    {
        public int Id { get; set; }
        public bool Adult { get; set; }
        public string backdrop_path { get; set; }
        public int Budget { get; set; }
        public string homepage { get; set; }
        public string imdb_id { get; set; }

        public string Original_language { get; set; }
        public string Original_Title { get; set; }
        public string Minions { get; set; }
        public string Overview { get; set; }
        public string Media_Type { get; set; }
        public double Popularity { get; set; }
        public string poster_path { get; set; }


        public string Title { get; set; }
        public bool Video { get; set; }
        public double Vote_Average { get; set; }
        public int Vote_Count { get; set; }
    }
}
