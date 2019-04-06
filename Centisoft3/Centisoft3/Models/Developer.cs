using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centisoft3.Models
{
	public class Developer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public List<Task> Tasks { get; set; }
	}
}
