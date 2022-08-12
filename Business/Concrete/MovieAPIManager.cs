using Business.Abstract;
using Entities.ViewModel;
using Newtonsoft.Json;

namespace Business.Concrete
{
    public class MovieAPIManager : IMovieAPIService
    {
        public async Task<string> MovieDetails(string url, string page = "1", string id = "1", string query = "")
        {
            HttpClient client = new HttpClient();

            var GetMoviesVM = client.GetAsync("https://api.themoviedb.org/3/movie/" + id + "?api_key=ec80cb6f4cc9c116212c2f138b6e7824&language=en-US").Result;
            var data = GetMoviesVM.Content.ReadAsStringAsync().Result;
            return data;
        }

        public async Task<string> SearchMovie(string url, string page = "1", string id = "1", string query = "")
        {
            HttpClient client = new HttpClient();

            var searchMoviesVM = client.GetAsync("https://api.themoviedb.org/3/" + url + "/movie" + "?api_key=ec80cb6f4cc9c116212c2f138b6e7824&language=en-US&query=" + query + "&page=" + page + "&include_adult=false/").Result;
            var searchvalue = searchMoviesVM.Content.ReadAsStringAsync().Result;
            return searchvalue;
        }

        public async Task<string> SimilarMovie(string url, string page = "1", string id = "1", string query = "")
        {
            HttpClient client = new HttpClient();

            var similarMoviesVM = client.GetAsync("https://api.themoviedb.org/3/movie/" + id + "/" + url + "?api_key=ec80cb6f4cc9c116212c2f138b6e7824&language=en-US&page=" + page).Result;
            var value = similarMoviesVM.Content.ReadAsStringAsync().Result;
            return value;
        }

        public async Task<string> UpcomingMovie(string url, string page = "1", string id = "1", string query = "")
        {
            HttpClient client = new HttpClient();

            var GetMoviesVM = client.GetAsync("https://api.themoviedb.org/3/movie/" + url + "?api_key=ec80cb6f4cc9c116212c2f138b6e7824&language=tr-tr&page=" + page).Result;
            var data = GetMoviesVM.Content.ReadAsStringAsync().Result;
            return data;
        }
    }
}
