using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*git*/

namespace Business.Abstract
{
    public interface IMovieAPIService
    {
        Task<string> SearchMovie(string url, string page = "1", string id = "1", string query = "");
        Task<string> MovieDetails(string url, string page = "1", string id = "1", string query = "");
        Task<string> UpcomingMovie(string url, string page = "1", string id = "1", string query = "");
        Task<string> SimilarMovie(string url, string page = "1", string id = "1", string query = "");
  
    }
}
