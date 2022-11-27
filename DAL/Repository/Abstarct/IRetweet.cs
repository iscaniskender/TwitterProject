using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Abstarct
{
    public interface IRetweet:IBaseRepository<Retweet>
    {
        List<Retweet> GetLike(int id);
        void updatestate(Retweet like);
    }
}
