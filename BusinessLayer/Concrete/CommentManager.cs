﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class CommentManager : ICommentService
	{
		ICommentDal _commentDal;

		public CommentManager(ICommentDal commentDal)
		{
			_commentDal = commentDal;
		}

		public void TAdd(Comment t)
		{
			_commentDal.Insert(t);
		}

		public void TDelete(Comment t)
		{
			_commentDal.Delete(t);
		}

		public List<Comment> TGetAll()
		{
			return _commentDal.GetListAll();
		}

		public List<Comment> TGetAll(int id)
		{
			return _commentDal.GetListAll(x=>x.GameID == id);
		}

		public Comment TGetByID(int id)
		{
			return _commentDal.GetByID(id);
		}

		public void TUpdate(Comment t)
		{
			_commentDal.Update(t);
		}
	}
}
