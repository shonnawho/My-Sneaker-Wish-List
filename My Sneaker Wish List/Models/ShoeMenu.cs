using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySneakerWishList.Models
{
    public class ShoeMenu
    {
        public int MenuID { get; set; }
        public Menu Menu { get; set; }
        public int ShoeID { get; set; }
        public Shoe Shoe { get; set; }

        public IList<ShoeMenu> ShoeMenus { get; set; }
    }
}

