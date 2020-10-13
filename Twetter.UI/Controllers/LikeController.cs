using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using BLL.Concrete;
using Cammon.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Twetter.UI.Controllers
{
    public class LikeController : Controller
    {
        LikeMenager like = new LikeMenager();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Likeoperation(DtoLike entity)
        {
            like.Create(entity);

            return Json(true);
        }
        public IActionResult Posttweet()
        {
            ConnectionMenager conn = new ConnectionMenager();
            UserMenager user = new UserMenager();
            TweetMenager tweet = new TweetMenager();
            var loguser = HttpContext.Session.GetObjectFromJson<Cammon.Dto.DtoUser>("loggerUser");
            var gelenıd = Convert.ToInt32(loguser.Id);
            //Takip ettiğim kişi listesi
            var fallow = conn.GetFallowing(gelenıd);
            //takip ettiğim kişiler
            var gelenuserlar = user.userListGetById(fallow);
            var TweetsAll = tweet.GetListTweetbyUsersDetails(gelenuserlar, gelenıd);
            var sondurum = TweetsAll.OrderByDescending(x => x.Createddate).ToList();
            return PartialView("_Tweets", sondurum);

        }
    }
}
