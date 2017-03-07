using RecordSystem.Models;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordSystem.DB
{
	public class NewsDBInitializer : SqliteCreateDatabaseIfNotExists<NewsDBContext>
	{
		public NewsDBInitializer(DbModelBuilder modelBuilder) : base(modelBuilder)
		{

		}

		protected override void Seed(NewsDBContext context)
		{
			base.Seed(context);
			context.Set<User>().Add(new User() { Name = "职员A" });
			context.Set<User>().Add(new User() { Name = "职员B" });
			context.Set<User>().Add(new User() { Name = "职员C" });
			context.Set<User>().Add(new User() { Name = "职员D" });
		}

	}
}
