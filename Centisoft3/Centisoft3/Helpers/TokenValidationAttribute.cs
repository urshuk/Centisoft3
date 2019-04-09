using Centisoft3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centisoft3.Helpers
{
	public class TokenValidationAttribute : ActionFilterAttribute
	{
		private readonly DataContext _context;

		public TokenValidationAttribute(DataContext context)
		{
			_context = context;
		}
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var token = context.HttpContext.Request.Headers["Authorization"];
			var client = _context.Clients.FirstOrDefault(m => m.Token == token);
			if (client == null)
			{
				context.Result = new UnauthorizedResult();
			}	
		}
	}
}
