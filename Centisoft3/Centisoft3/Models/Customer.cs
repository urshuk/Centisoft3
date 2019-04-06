using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centisoft3.Models
{
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Address2 { get; set; }
		public string Zip { get; set; }
		public string Country { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public int ClientId { get; set; }
		public List<Project> Projects { get; set; }
	}
}
