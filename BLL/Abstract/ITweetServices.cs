using Cammon.Dto;
using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Abstract
{
    public interface ITweetServices
    {
        DtoTweet GetById(int id);
        DtoRetweet GetOne(Expression<Func<DtoTweet, bool>> filter);
        List<DtoTweet> GetAll();
        List<DtoTweet> GetTweetsById(int id);

        List<DtoTweet> rtgetirici(int id);

        List<DtoTweet> GetListTweetbyUsers(List<DtoUser> entity);
        List<DtoMainTweetsUsers> GetListTweetbyUsersDetails(List<DtoUser> entity,int gelenid);

        void Create(DtoTweet entity);
        void Update(DtoTweet entity);
        void Delete(DtoTweet entity);
    }
}
