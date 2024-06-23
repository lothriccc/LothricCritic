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
	public class CompanyManager : ICompanyService
	{
		ICompanyDal _companyDal;

		public CompanyManager(ICompanyDal companyDal)
		{
			_companyDal = companyDal;
		}

		public void TAdd(Company t)
		{
			_companyDal.Insert(t);
		}

		public void TDelete(Company t)
		{
			_companyDal.Delete(t);

		}

		public List<Company> TGetAll()
		{
			return _companyDal.GetListAll();
		}

		public List<Company> TGetAll(int id)
		{
			throw new NotImplementedException();
		}

		public Company TGetByID(int id)
		{
			return _companyDal.GetByID(id);
		}

		public void TUpdate(Company t)
		{
			_companyDal.Update(t);
		}
	}
}
