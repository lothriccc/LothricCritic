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
    public class GameCategoryManager : IGameCategoryService
    {
        IGameCategoryDal _gameCategoryDal;

        public GameCategoryManager(IGameCategoryDal gameCategoryDal)
        {
            _gameCategoryDal = gameCategoryDal;
        }

        public void TAdd(GameCategory t)
        {
            _gameCategoryDal.Insert(t);
        }

        public void TDelete(GameCategory t)
        {
            _gameCategoryDal.Delete(t);
        }

        public List<GameCategory> TGetAll()
        {
            return _gameCategoryDal.GetListAll();
        }

		public List<GameCategory> TGetAll(int id)
		{
			throw new NotImplementedException();
		}

		public GameCategory TGetByID(int id)
        {
            return _gameCategoryDal.GetByID(id);
        }

        public List<GameCategory> TGetListWithInclude()
        {
            return _gameCategoryDal.GetListWithInclude();
        }

        public void TUpdate(GameCategory t)
        {
            _gameCategoryDal.Update(t);
        }
    }
}
