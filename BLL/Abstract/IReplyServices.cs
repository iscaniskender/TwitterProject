using Cammon.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Abstract
{
    public interface IReplyServices
    {

        DtoReply GetById(int id);
        DtoReply GetOne(Expression<Func<DtoReply, bool>> filter);
        List<DtoReply> GetAll();

        void Create(DtoReply entity);
        void Update(DtoReply entity);
        void Delete(DtoReply entity);
    }
}
