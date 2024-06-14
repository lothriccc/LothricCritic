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
	public class GameManager : IGameService
	{
		IGameDal _gameDal;

		public GameManager(IGameDal gameDal)
		{
			_gameDal = gameDal;
		}

		public void TAdd(Game t)
		{
			_gameDal.Insert(t);
		}

		public void TDelete(Game t)
		{
			_gameDal.Delete(t);
		}

		public List<Game> TGetAll()
		{
			return _gameDal.GetListAll();
		}

		public Game TGetByID(int id)
		{
			return _gameDal.GetByID(id);
		}

        public List<Game> TGetGameListWithCompany()
        {
			return _gameDal.GetGameListWithCompany();
        }

        public void TUpdate(Game t)
		{
			_gameDal.Update(t);
		}
	}
}
