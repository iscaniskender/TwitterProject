using DAL.Context;
using DAL.Repository.Abstarct;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository.Concrete
{
    public class EfTweet:EfRepository<Tweet>,ITweet
    {
        public EfTweet(TwetterContext context):base(context)
        {
            

        }

        public List<Tweet> GetJoinList(User entity)
        {
            using (var context = new TwetterContext())
            {
                var detaits = context.Tweets.Where(a=>a.UserId==entity.Id).Include(x => x.Likes).Include("Retweets").Include("Reply").ToList();
                return detaits;
            }
        }

        public List<Tweet> GetListTweetbyUsers(List<User> entity)
        {
            using(var context = new TwetterContext())
            {
                List<Tweet> tweets = new List<Tweet>();
                foreach (var item in entity)
                {
                    var gelen = context.Tweets.Where(x => x.UserId == item.Id).ToList();
                    tweets.AddRange(gelen);
                } 
                return tweets;
            }
        }

        public void updatestate(Tweet tw)
        {
                using (var context = new TwetterContext())
                {
                    context.Entry(tw).State = EntityState.Modified;
                    context.SaveChanges();
                };

            
        }
    }
}
