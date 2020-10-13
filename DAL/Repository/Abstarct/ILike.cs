using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Abstarct
{
    public interface ILike:IRepository<Like>
    {
        List<Like> GetLike(int id);
        void updatestate(Like like);
            
    }

}
