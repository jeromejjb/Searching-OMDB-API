using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OMDBAPI.Models
{
    public class SearchbyKeywordDAL
    {

        public string CallAPI(string searchType, string title)
        {

            string key = "1be3d0ca";
            string url = @$"http://www.omdbapi.com/?{searchType}={title}&apikey={key}";
            //This allows us to do either kind of search by choosing via the front end of the program.

            HttpWebRequest request = WebRequest.CreateHttp(url);
            //300 generally mean the server has moved or there has been a redirect
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string json = rd.ReadToEnd();
            rd.Close();
            return json;

        }

        public SearchResults GetSearchResults(string title)
        {
            string json = CallAPI("s", title);
            SearchResults m = JsonConvert.DeserializeObject<SearchResults>(json);
            return m;
        }
    }
}
