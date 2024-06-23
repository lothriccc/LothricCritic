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
    public class EfGameDal : GenericRepository<Game>, IGameDal
    {

		public List<Game> GetGameListWithCompany()
        {
            using (var context = new Context())
            {
                return context.Games.Include(x=>x.Company).ToList();
            }
        }
    }
}
