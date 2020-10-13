using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Abstarct
{
    public interface IUser:IRepository<User>
    {
        List<User> GetSearchvalue(string search);
        List<User> userListGetById(List<Connection> entity);

    }
}
