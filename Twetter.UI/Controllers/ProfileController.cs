using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Concrete;
using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Twetter.UI.Models;

namespace Twetter.UI.Controllers
{
    public class ProfileController : Controller
    {
        UserMenager user = new UserMenager();
        TweetMenager tweet = new TweetMenager();
        ConnectionMenager conn = new ConnectionMenager();
        public IActionResult Index(int id)
        {
            var sorguUser = user.GetById(id);
            var sorguTweet = tweet.rtgetirici(id);
            var twcount= sorguTweet.Count();
            var takip = conn.GetFallowing(id);
            var takipci = conn.GetFollowers(id);

            return View(new DtoUserProfileTweet
            {
                TweetCount = twcount,
                User = sorguUser,
                dtoTweets = sorguTweet,
                takipci=takipci,
                takipedilen=takip
            }); 
        }
    }
}
