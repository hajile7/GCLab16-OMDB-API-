using Newtonsoft.Json;
using System.Net;
using static System.Net.WebRequestMethods;

namespace GCLab16_OMDB_API_.Models
{
    public class MovieDAL
    {
        public static MovieModel GetMovie(string Title) //Adjust here
        {
            //adjust 
            //setup
            string key = Secret.Key;
            string url = $"http://www.omdbapi.com/?i=tt3896198&apikey={key}&t={Title}"; //this is the API's url

            //request (almost always stays same)
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //convert to JSON (almost always stays the same)
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            //Adjust
            //Convert to C#
            //install nuget Newtonsoft.json
            MovieModel result = JsonConvert.DeserializeObject<MovieModel>(JSON);
            return result;
        }
    }
}
