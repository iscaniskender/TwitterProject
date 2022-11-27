using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Abstarct
{
    public interface IConnection:IBaseRepository<Connection>
    {
        void updatestate(Connection conn);
        List<Connection> GetFallowing(int id);
        List<Connection> GetFollowers(int id);
    }
}
