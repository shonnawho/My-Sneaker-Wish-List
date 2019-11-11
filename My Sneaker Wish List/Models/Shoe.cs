using MySneakerWishList.Models;
using System.Collections.Generic;

namespace MySneakerWishList.Models
{
    public class Shoe
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ShoeCategory Category { get; set; }
        public int ID { get; set; }
        public int CategoryID { get; set; }
		//public int UsersID { get; set;}

        //public List<ShoeMenu> ShoeMenus { get; set; }
    }


}