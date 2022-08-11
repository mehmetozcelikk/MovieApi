using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel
{
    public class CustomMovieVM
    {
        public MovieSearchVM movieSearchVMs { get; set; }
        public TurkeyMoviesVM turkeyMoviesVM { get; set; }
        public MovieDetailVM movieDetailVM { get; set; }
        public SimilarMoviesVM similarMoviesVM { get; set; }

        public string baseimgurl = "https://image.tmdb.org/t/p/w500";
    }
}
