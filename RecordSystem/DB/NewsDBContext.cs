using RecordSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordSystem.DB
{
	public class NewsDBContext: DbContext
	{
		public virtual DbSet<User> Users { get; set; }


		public virtual DbSet<NewsLog> NewsLogs { get; set; }

		public NewsDBContext() : base("NewsLogDb")
		{
			Configuration.ProxyCreationEnabled = true;
			Configuration.LazyLoadingEnabled = true;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.Property(e => e.Name)
				.IsUnicode(false);


			var initializer = new NewsDBInitializer(modelBuilder);
			Database.SetInitializer(initializer);
		}
	}
}
