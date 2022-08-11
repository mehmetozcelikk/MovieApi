using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel
{
    public class TurkeyMoviesVM
    {
        public int Page { get; set; }
        public int TotalPage { get; set; }
        public int Total_Results { get; set; }
        public string baseimgurl { get; set; }
        public List<GetTurkeyMoviesVM> Results { get; set; }
    }
}
