using Cammon.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Abstract
{
    public interface IUserServices
    {
        DtoUser GetById(int id);
        List<DtoUser> userListGetById(List<DtoConnection> entity);
        DtoUser Search(string username);
        List<DtoUser> GetAll();
        void Create(DtoUser entity);
        void Update(DtoUser entity);
        void Delete(DtoUser entity);

        DtoUser LoginControl(DtoUser entity);
        DtoUser RegisterControl(DtoUser entity);
    }
}
