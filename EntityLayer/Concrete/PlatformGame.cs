using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PlatformGame
    {
        public int GameID { get; set; }
        public int PlatformID { get; set; }
        public Game Game { get; set; }
        public Platform Platform { get; set; }
    }

}
