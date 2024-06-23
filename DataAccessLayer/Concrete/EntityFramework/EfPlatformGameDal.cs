using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfPlatformGameDal : GenericRepository<PlatformGame>, IPlatformGameDal
    {
        public PlatformGame GetByTwoID(int id1, int id2)
        {
            using var c = new Context();
            return c.Set<PlatformGame>().Find(id1,id2);
        }

        public List<PlatformGame> GetListWithInclude()
        {
           using (var c = new Context())
            {
                return c.PlatformGame.Include(x=> x.Platform).Include(y=>y.Game).ToList();
            }
        }
    }
}
