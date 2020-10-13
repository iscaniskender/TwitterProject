using DAL.Context;
using DAL.Repository.Abstarct;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DAL.Repository.Concrete
{
    public class EfConnection : EfRepository<Connection>, IConnection
    {
        public EfConnection(TwetterContext context) : base(context)
        {

        }

        public List<Connection> GetFallowing(int id)
        {
            using (var context = new TwetterContext())
            {
                var takipedilen = context.Connections.Where(x => x.takipci.Id == id).Select(k => new Connection()
                {
                    takipid = k.takipid,
                    Isdeleted = k.Isdeleted,
                    TakipciId = k.TakipciId,
                    Isactive = k.Isactive

                }).ToList();
                return takipedilen;
            };
        }

        public List<Connection> GetFollowers(int id)
        {
            using (var context = new TwetterContext())
            {
                var takipci = context.Connections.Where(x => x.takipid == id ).Select(k => new Connection()
                {
                    takipid = k.takipid,
                    Isdeleted = k.Isdeleted,
                    TakipciId = k.TakipciId,
                    Isactive = k.Isactive
    
                }).ToList();
                return takipci;
            };

        }
        public void updatestate(Connection conn)
        {
            using (var context = new TwetterContext())
            {
                context.Entry(conn).State = EntityState.Modified;
                context.SaveChanges();
            };

        }
    }
}
