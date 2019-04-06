using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centisoft3.Models
{
	public class Project
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime DueDate { get; set; }
		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
		public List<Task> Tasks { get; set; }
	}
}
