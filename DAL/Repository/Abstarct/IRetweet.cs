using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Abstarct
{
    public interface IRetweet:IRepository<Retweet>
    {
        List<Retweet> GetLike(int id);
        void updatestate(Retweet like);
    }
}
