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
   public class EfRetweet:EfRepository<Retweet>,IRetweet
    {
        public EfRetweet(TwetterContext context):base(context)
        {

        }
        public List<Retweet> GetLike(int id)
        {
            using (var context = new TwetterContext())
            {
                var retwetlenen = context.Retweets.Where(x => x.TweetId == id).ToList();

                return retwetlenen;
            };
        }

        public void updatestate(Retweet entity)
        {
            using (var context = new TwetterContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            };

        }
    }
}
