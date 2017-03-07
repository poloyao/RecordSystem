using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordSystem.Models
{
	[Table("News")]
	public class News :EntityBase
	{

		public string NewsTitle { get; set; }
	}
}
