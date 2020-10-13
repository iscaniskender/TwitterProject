using DAL.Repository.Abstarct;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
   
   public  interface IUnitOfWork:IDisposable
    {
        IUser Userrepo { get; }
        ITweet Tweetterrepo { get; }
        ILike Likerepo { get; }
        IReply Replyrepo { get; }
        IRetweet Retweetrepo { get; }
        IConnection Connectionrepo { get; }
        void Save();
    }
}
