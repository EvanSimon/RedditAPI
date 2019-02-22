using Newtonsoft.Json.Linq;
using RedditAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RedditAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Reddit()
        {
            //Make request of the API, get back a response in JSON
            HttpWebRequest request = WebRequest.CreateHttp("http://www.reddit.com/r/aww/.json");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();
            rd.Close();
            JObject redditJson = JObject.Parse(data);
            List<JToken> posts = redditJson["data"]["children"].ToList();
            List<RedditPost> output = new List<RedditPost>();
            for (int i = 0; i < 10; i++)
            {
                RedditPost rp = new RedditPost();
                rp.Title = posts[i]["data"]["title"].ToString();
                rp.ImageURL = posts[i]["data"]["thumbnail"].ToString();
                rp.LinkURL = "http://reddit.com/" + posts[i]["data"]["permalink"].ToString();
                //Add my post to the output list
                output.Add(rp);
            }
            return View(output);

        }

    }
}