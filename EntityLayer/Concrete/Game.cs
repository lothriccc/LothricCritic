using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Game
    {
        [Key]
        public int GameID { get; set; }
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImageUrl { get; set; }
        public string BigImageUrl { get; set; }
        public ICollection<Category> Categories { get; set; }
        public Company Company { get; set; }
        public ICollection<Platform> Platforms { get; set; }
        public List<Comment> Comments { get; set; }
    }

}
