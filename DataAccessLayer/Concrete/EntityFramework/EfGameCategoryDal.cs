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
    public class EfGameCategoryDal : GenericRepository<GameCategory>, IGameCategoryDal
    {
        public List<GameCategory> GetListWithInclude()
        {
            using (var c = new Context())
            {
                return c.GameCategory.Include(x => x.Game).Include(y => y.Category).ToList();
            }
        }
    }
}
