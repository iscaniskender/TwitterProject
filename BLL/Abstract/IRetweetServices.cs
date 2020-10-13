using Cammon.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Abstract
{
    public interface IRetweetServices
    {
        DtoRetweet GetById(int id);
        DtoRetweet GetOne(Expression<Func<DtoRetweet, bool>> filter);
        List<DtoRetweet> GetAll();

        void Create(DtoRetweet entity);
        void Update(DtoRetweet entity);
        void Delete(DtoRetweet entity);
    }
}
