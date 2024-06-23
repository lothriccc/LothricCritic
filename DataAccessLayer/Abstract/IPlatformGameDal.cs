using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IPlatformGameDal:IGenericDal<PlatformGame>
    {
        PlatformGame GetByTwoID(int id1, int id2);
        List<PlatformGame> GetListWithInclude();
        
    }
}
