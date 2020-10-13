using AutoMapper;
using BLL.Abstract;
using Cammon.Dto;
using DAL.UnitOfWork;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Concrete
{
    public class LikeMenager : ILikeServices
    {
        UnitOfWork unit = new UnitOfWork();
        public void Create(DtoLike entity)
        {
            var gelen = Mapper.Map<Like>(entity);
            var sorgu = unit.Likerepo.GetLike(entity.TweetId).Where(x => x.UserId == entity.UserId).Select(x => x.Isdeleted == true).Any();
            if (sorgu == true)
            {
                unit.Likerepo.updatestate(gelen);
                unit.Save();
            }
            else
            {
                unit.Likerepo.Create(gelen);
                unit.Save();
            }
        }

        public void Delete(DtoLike entity)
        {
            throw new NotImplementedException();
        }

        public List<DtoRetweet> GetAll()
        {
            throw new NotImplementedException();
        }

        public DtoLike GetById(int id)
        {
            throw new NotImplementedException();
        }

        public DtoLike GetOne(Expression<Func<DtoLike, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(DtoLike entity)
        {
            throw new NotImplementedException();
        }
    }
}
