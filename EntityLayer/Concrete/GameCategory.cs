using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class GameCategory
    {
        public int GameID { get; set; }
        public int CategoryID { get; set; }
        public Game Game { get; set; }
        public Category Category { get; set; }
    }

}
