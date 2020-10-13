using AutoMapper;
using BLL.Abstract;
using Cammon.Dto;
using DAL.UnitOfWork;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BLL.Concrete
{
    public class UserMenager : IUserServices
    {
        UnitOfWork unit = new UnitOfWork();
        public void Create(DtoUser entity)
        {
            var user = Mapper.Map<User>(entity);
            unit.Userrepo.Create(user);
            unit.Save();
        }

        public void Delete(DtoUser entity)
        {
            throw new NotImplementedException();
        }

        public List<DtoUser> GetAll()
        {
            throw new NotImplementedException();
            
        }

        public DtoUser GetById(int id)
        {  
            var gelen = (unit.Userrepo.GetById(id));
            return Mapper.Map<DtoUser>(gelen);
        }

   
        public DtoUser LoginControl(DtoUser entity)
        {
            var sorgu = unit.Userrepo.GetAll().Where(x => ( x.Username == entity.Username || x.Email ==entity.Username) && x.Password == entity.Password).FirstOrDefault();
            return Mapper.Map<DtoUser>(sorgu);
        }

        public DtoUser RegisterControl(DtoUser entity)
        {
            var sorgu = unit.Userrepo.GetAll().Where(x => x.Username == entity.Username || x.Email  == entity.Email).FirstOrDefault();
            return Mapper.Map<DtoUser>(sorgu);
        }

        public DtoUser Search(string username)
        {
            var sorgu = unit.Userrepo.GetAll().Where(x => x.Username == username).Select(k => new DtoUser
            {
                Id = k.Id,
                Name = k.Name,
                Surname=k.Surname,
                Username=k.Username,
                Isactive=k.Isactive,
                Isdeleted=k.Isdeleted
                
            }).FirstOrDefault() ;
            return Mapper.Map<DtoUser>(sorgu);
        }
        public void Update(DtoUser entity)
        {
            throw new NotImplementedException();
        }

        public List<DtoUser> userListGetById(List<DtoConnection> entity)
        {
            List<Connection> connlist = Mapper.Map<List<Connection>>(entity);
            var gelen = unit.Userrepo.userListGetById(connlist);
            return Mapper.Map<List<DtoUser>>(gelen);
        }
    }
}
