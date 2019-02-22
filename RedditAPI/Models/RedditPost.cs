using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedditAPI.Models
{
    public class RedditPost
    {

        //Model of things I want from the Reddit API
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string LinkURL { get; set; }
        
    }
}