using AutoMapper;
using BLL.Abstract;
using Cammon.Dto;
using DAL.UnitOfWork;
using Entities;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BLL.Concrete
{
    public class RetweetMenager : IRetweetServices

    {
        UnitOfWork unit = new UnitOfWork();
        public void Create(DtoRetweet entity)
        {
            var gelen = Mapper.Map<Retweet>(entity);
            var sorgu = unit.Retweetrepo.GetLike(entity.TweetId).Where(x => x.UserId == entity.UserId).Select(x => x.Isdeleted == true).Any();
            bool gelentivit = unit.Tweetterrepo.GetAll().Any(x => x.Id == entity.TweetId && x.Replyto == entity.UserId);


            var tweet = unit.Tweetterrepo.GetById(entity.TweetId);
            tweet.Replyto = entity.UserId;
            tweet.Isactive = entity.Isactive;
            tweet.Createddate = tweet.Createddate;
            tweet.Isdeleted = tweet.Isdeleted;
            tweet.Text = tweet.Text;
            tweet.UserId = tweet.UserId;

            if (gelentivit == true)
            {
                unit.Tweetterrepo.updatestate(tweet);
                unit.Save();
            }




            if (sorgu == true)
            {


                unit.Retweetrepo.updatestate(gelen);
                unit.Save();


            }
            else
            {

                unit.Retweetrepo.Create(gelen);
                unit.Save();
            }
        }

        public void Delete(DtoRetweet entity)
        {
            throw new NotImplementedException();
        }

        public List<DtoRetweet> GetAll()
        {
            throw new NotImplementedException();
        }

        public DtoRetweet GetById(int id)
        {
            throw new NotImplementedException();
        }

        public DtoRetweet GetOne(Expression<Func<DtoRetweet, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(DtoRetweet entity)
        {
            throw new NotImplementedException();
        }
    }
}
