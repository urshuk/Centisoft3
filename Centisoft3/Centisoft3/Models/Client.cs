using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centisoft3.Models
{
	public class Client
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Token { get; set; }
		public List<Customer> Customers { get; set; }
	}
}
