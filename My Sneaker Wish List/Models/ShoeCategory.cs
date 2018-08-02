using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySneakerWishList.Models
{
    public class ShoeCategory
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public IList<Shoe> Shoes { get; set; }
    }
}
