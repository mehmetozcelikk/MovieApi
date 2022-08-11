using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel
{
    public class MovieSearchVM
    {
        public string query { get; set; }
        public int Page { get; set; }
        public int Total_Pages { get; set; }
        public int Total_Results { get; set; }
        public string baseimgurl { get; set; }
        public List<MovieVM> Results { get; set; }

    }
}
