using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MySneakerWishList.Controllers
{
	public class UsersShoesController : Controller
	{
		private readonly UsersShoesController _context;

		public UsersShoesController(UsersShoesController context)
		{
			_context = context;
		}
	}

}