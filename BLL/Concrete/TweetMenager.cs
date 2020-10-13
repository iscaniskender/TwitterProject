using BLL.Abstract;
using Cammon.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using System.Text;
using AutoMapper;
using Entities;
using DAL.UnitOfWork;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace BLL.Concrete
{
    public class TweetMenager : ITweetServices
    {
        UnitOfWork unit = new UnitOfWork();
        public void Create(DtoTweet entity)
        {
            var deger = Mapper.Map<Tweet>(entity);
            unit.Tweetterrepo.Create(deger);
            unit.Save();
        }

        public void Delete(DtoTweet entity)
        {
            throw new NotImplementedException();
        }

        public List<DtoTweet> GetAll()
        {
            throw new NotImplementedException();
        }

        public DtoTweet GetById(int id)
        {
            throw new NotImplementedException();
        }
        //Gönderdiğim UserListesinin tweet listesi
        public List<DtoTweet> GetListTweetbyUsers(List<DtoUser> entity)
        {
            List<User> gelen = Mapper.Map<List<User>>(entity);
            var sorgu = unit.Tweetterrepo.GetListTweetbyUsers(gelen);
            return Mapper.Map<List<DtoTweet>>(sorgu);
        }

        public List<DtoMainTweetsUsers> GetListTweetbyUsersDetails(List<DtoUser> entity, int gelenid)
        {
            List<DtoMainTweetsUsers> mtus = new List<DtoMainTweetsUsers>();

            List<User> userlist = Mapper.Map<List<User>>(entity);
            foreach (var item in userlist)
            {
                var gelen = unit.Tweetterrepo.GetJoinList(item);
                foreach (var tweet in gelen)
                {
                    DtoMainTweetsUsers mtu = new DtoMainTweetsUsers();
                    mtu.likeactive = tweet.Likes.Any(x => x.UserId == gelenid && x.TweetId == tweet.Id && x.Isdeleted == false);
                    mtu.Retweetactive = tweet.Retweets.Any(x => x.UserId == gelenid && x.TweetId == tweet.Id && x.Isdeleted == false);
                    mtu.UserId = item.Id;
                    mtu.Name = item.Name;
                    mtu.Surname = item.Surname;
                    mtu.Username = item.Username;
                    mtu.Tweetid = tweet.Id;
                    mtu.Text = tweet.Text;
                    mtu.Createddate = tweet.Createddate;
                    mtu.LikeCount = tweet.Likes.Where(x => x.Isdeleted == false && x.Isactive == true).Count();
                    mtu.RetweetCount = tweet.Retweets.Where(a => a.Isdeleted == false && a.Isactive == true).Count();
                    mtu.ReplyCount = tweet.Reply.Where(a => a.Isdeleted == false && a.Isactive == true).Count();
                    mtus.Add(mtu);
                }
            }
            return mtus;
        }

        public DtoRetweet GetOne(Expression<Func<DtoTweet, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<DtoTweet> GetTweetsById(int id)
        {
            var gelen = unit.Tweetterrepo.GetAll().Where(x => x.UserId == id).OrderByDescending(x => x.Createddate);

            return Mapper.Map<List<DtoTweet>>(gelen);
        }

        public List<DtoTweet> rtgetirici(int id)
        {

            var gelen = unit.Tweetterrepo.GetAll().Where(x => (x.UserId == id) || (x.Replyto == id && x.Isactive == true)).OrderByDescending(x => x.Createddate);

            return Mapper.Map<List<DtoTweet>>(gelen);

        }

        public void Update(DtoTweet entity)
        {
            throw new NotImplementedException();
        }
    }
}
