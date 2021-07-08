using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ubiety.Dns.Core;

namespace OMDBAPI.Models
{
    public class MovieDAL
    {
       public string CallAPI(string searchType, string title)
        {
            string key = "1be3d0ca";
            string url = @$"http://www.omdbapi.com/?{searchType}={title}&apikey={key}";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string JSON = rd.ReadToEnd();
            rd.Close();
            return JSON;
        }

        public Movie GetMovie(string title)
        {
            string json = CallAPI("t", title);
            Console.WriteLine(json);
            Movie m = JsonConvert.DeserializeObject<Movie>(json);
            return m;
        }
    }
    
}
