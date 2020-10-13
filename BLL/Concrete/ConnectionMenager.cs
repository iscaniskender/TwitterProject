using AutoMapper;
using BLL.Abstract;
using Cammon.Dto;
using DAL.UnitOfWork;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Concrete
{
    public class ConnectionMenager : IConnectionServices
    {
        UnitOfWork unit = new UnitOfWork();
        public void Create(DtoConnection entity)
        {
            var gelen = Mapper.Map<Connection>(entity);
            var sorgu =unit.Connectionrepo.GetFallowing(entity.TakipciId).Where(x => x.takipid == entity.takipid).Select(x => x.Isdeleted==true).Any();
            if (sorgu == true)
            {
                unit.Connectionrepo.updatestate(gelen);
                unit.Save();
            }
            else
            {
                unit.Connectionrepo.Create(gelen);
                unit.Save();
            }
        }
        public void Delete(DtoConnection entity)
        {
            throw new NotImplementedException();
        }

        public List<DtoConnection> GetAll()
        {
            throw new NotImplementedException();
        }

        public DtoConnection GetById(int id)
        {
            var gelen = Mapper.Map<Connection>(id);

           
            throw new NotImplementedException();
        }

        public List<DtoConnection> GetFallowing(int id)
        {
            var takipedilen = unit.Connectionrepo.GetFallowing(id).Where(x=>x.Isdeleted==false);
            return Mapper.Map<List<DtoConnection>>(takipedilen);
        }

        public List<DtoConnection> GetFollowers(int id)
        {
            var takipci= unit.Connectionrepo.GetFollowers(id);
            return Mapper.Map<List<DtoConnection>>(takipci);
        }

        public DtoLike GetOne(Expression<Func<DtoConnection, bool>> filter)
        {
            throw new NotImplementedException();
        }


        public void Update(DtoConnection entity)
        {
            throw new NotImplementedException();
        }

    }
}
