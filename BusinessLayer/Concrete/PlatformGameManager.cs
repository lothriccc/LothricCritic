using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PlatformGameManager : IPlatformGameService
    {
        IPlatformGameDal _platformGameDal;

        public PlatformGameManager(IPlatformGameDal platformGameDal)
        {
            _platformGameDal = platformGameDal;
        }

        public void TAdd(PlatformGame t)
        {
            _platformGameDal.Insert(t);
        }

        public void TDelete(PlatformGame t)
        {
            _platformGameDal.Delete(t);
        }

        public List<PlatformGame> TGetAll()
        {
            return _platformGameDal.GetListAll();
        }

		public List<PlatformGame> TGetAll(int id)
		{
			throw new NotImplementedException();
		}

		public PlatformGame TGetByID(int id)
        {
            return _platformGameDal.GetByID(id);
        }

        public PlatformGame TGetByTwoID(int id1, int id2)
        {
           return _platformGameDal.GetByTwoID(id1, id2);
        }

        public List<PlatformGame> TGetListWithInclude()
        {
            return _platformGameDal.GetListWithInclude();
        }

        public void TUpdate(PlatformGame t)
        {
            _platformGameDal.Update(t);
        }
    }
}
