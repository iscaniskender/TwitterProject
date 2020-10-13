using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BLL.Concrete;
using Cammon.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Twetter.UI.Models;
using Microsoft.AspNetCore.Http;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Common.Dto;

namespace Twetter.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        TweetMenager tweet = new TweetMenager();
        UserMenager user = new UserMenager();
        ConnectionMenager conn = new ConnectionMenager();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        #region index
        public IActionResult Index()
        {
            var loguser = HttpContext.Session.GetObjectFromJson<Cammon.Dto.DtoUser>("loggerUser");
            var gelenıd = Convert.ToInt32(loguser.Id);
            //Takip ettiğim kişi listesi
            var fallow = conn.GetFallowing(gelenıd);
            //takip ettiğim kişiler
            var gelenuserlar = user.userListGetById(fallow);
            var TweetsAll = tweet.GetListTweetbyUsersDetails(gelenuserlar,gelenıd);
            return View(TweetsAll.OrderByDescending(x => x.Createddate).ToList());
        }
        #endregion
        #region PostTweet
        public IActionResult Posttweet(DtoTweet entity)
        {
            entity.Createddate = DateTime.Now;
            tweet.Create(entity);
            return Json(true);
        }
        #endregion
        #region Kullanıcı arama

        public IActionResult Search(string username, int id)
        {
            if (username != null)
            {
                var deger = user.Search(username);
                if (deger != null && deger.Isdeleted == false)
                {

                    var sorguTweet = tweet.GetTweetsById(deger.Id);
                    var twcount = sorguTweet.Count();
                    var fallows = conn.GetFallowing(id);

                    DtoUserProfileTweet UPT = new DtoUserProfileTweet();
                    UPT.dtoTweets = sorguTweet;
                    UPT.takipedilen = fallows;
                    UPT.TweetCount = twcount;
                    UPT.User = deger;
                    UPT.takipedilen = conn.GetFallowing(deger.Id);
                    UPT.takipci = conn.GetFollowers(deger.Id);


                    return View(UPT);
                }
                else
                {
                    return RedirectToAction("Error");
                }

            }
            else
            {
                return RedirectToAction("Error");
            }

        }
        #endregion
        #region Takip-Takipci pratial

        [HttpPost]
        public IActionResult GetbyFallowsTable(int id)
        {
            ConnectionMenager conn = new ConnectionMenager();
            DtoUserProfileTweet UPT = new DtoUserProfileTweet();
            UPT.takipedilen = conn.GetFallowing(id).ToList();
            UPT.takipci = conn.GetFollowers(id).ToList();
 
            return PartialView("_GetFallowsTable", UPT);
        }
        #endregion
        #region Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
