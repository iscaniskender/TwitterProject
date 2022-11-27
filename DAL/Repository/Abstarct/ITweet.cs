using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Abstarct
{
    public interface ITweet:IBaseRepository<Tweet>
    {
        List<Tweet> GetListTweetbyUsers(List<User> entity);

        List<Tweet> GetJoinList(User id);

        void updatestate(Tweet tw);
    }
}
