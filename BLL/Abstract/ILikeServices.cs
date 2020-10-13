using Cammon.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Abstract
{
    public interface ILikeServices
    {
        DtoLike GetById(int id);
        DtoLike GetOne(Expression<Func<DtoLike, bool>> filter);
        List<DtoRetweet> GetAll();

        void Create(DtoLike entity);
        void Update(DtoLike entity);
        void Delete(DtoLike entity);
    }
}
