using DAL.Context;
using DAL.Repository.Abstarct;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DAL.Repository.Concrete
{
    public class EfUser:EfRepository<User>,IUser
    {
        public EfUser(TwetterContext context):base(context)
        {
           
        }
        public List<User> GetSearchvalue(string search)
        {
            using (var context = new TwetterContext())
            {
               List<User> allsearch = context.Users.Where(x => x.Username.Contains(search)).Select(x => new User()
                {
                    Id=x.Id,
                    Name=x.Username,
                    Username=x.Username,
                }).ToList();

                return allsearch.ToList();
            }
        }

        public List<User> userListGetById(List<Connection> entity)
        {
            using ( var context = new TwetterContext())
            {
                List<User> userlist = new List<User>();
                foreach (var item in entity)
                {
                    var getir = context.Users.Where(x=>x.Id==item.takipid) .ToList();
                    userlist.AddRange(getir);
                }
                return userlist ;
            }
        }
    }
}
