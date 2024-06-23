using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Comment
	{
        [Key]
        public int CommentID { get; set; }
		public int GameID { get; set; }
		public string UserName { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }
        public Game Game { get; set; }
    }
}
