using DAL.Context;
using DAL.Repository.Abstarct;
using DAL.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        TwetterContext twcontext = new TwetterContext();
        private bool _disposed = false;
        public UnitOfWork()
        {
            Userrepo = new EfUser(twcontext);
            Tweetterrepo = new EfTweet(twcontext);
            Likerepo = new EfLike(twcontext);
            Replyrepo = new EfReply(twcontext);
            Retweetrepo = new EfRetweet(twcontext);
            Connectionrepo = new EfConnection(twcontext);

        }
        public IUser Userrepo { get; private set; }

        public ITweet Tweetterrepo { get; private set; }

        public ILike Likerepo { get; private set; }

        public IReply Replyrepo { get; private set; }

        public IRetweet Retweetrepo { get; private set; }

        public IConnection Connectionrepo { get; private set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    twcontext.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            using (TransactionScope tScope = new TransactionScope())
            {
                twcontext.SaveChanges();
                tScope.Complete();
            }
        }

    }
}
