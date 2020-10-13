using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Abstarct
{
    public interface ITweet:IRepository<Tweet>
    {
        List<Tweet> GetListTweetbyUsers(List<User> entity);

        List<Tweet> GetJoinList(User id);

        void updatestate(Tweet tw);
    }
}
