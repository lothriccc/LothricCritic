using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPlatformGameService:IGenericService<PlatformGame>
    {
        PlatformGame TGetByTwoID(int id1, int id2);

        List<PlatformGame> TGetListWithInclude();
    }
}
