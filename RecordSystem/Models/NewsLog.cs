using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordSystem.Models
{
	[Table("NewsLog")]
	public class NewsLog : EntityBase
	{
		public NewsLog()
		{
			//this.News = new List<News>();
		}

		[Column(Order = 3)]
		public DateTime UDP { get; set; }

		[Column(Order = 1)]
		public virtual User UserID { get; set; }

		[Column(Order = 2)]
		public virtual News NewsID { get; set; }
	}
}
