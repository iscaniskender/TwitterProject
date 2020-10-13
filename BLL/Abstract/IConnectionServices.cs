using Cammon.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Abstract
{
    public interface IConnectionServices
    {
        DtoConnection GetById(int id);
        DtoLike GetOne(Expression<Func<DtoConnection, bool>> filter);
        List<DtoConnection> GetAll();

        void Create(DtoConnection entity);
        void Update(DtoConnection entity);
        void Delete(DtoConnection entity);
        List<DtoConnection> GetFallowing(int id);
        List<DtoConnection> GetFollowers(int id);
    }
}
