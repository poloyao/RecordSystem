using RecordSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

		public virtual DbSet<News> News { get; set; }

		public NewsDBContext() : base("NewsLogDb")
		{
			Configuar();
		}

		public NewsDBContext(DbConnection connection, bool contextOwnsConnection)
			: base(connection, contextOwnsConnection)
		{
			Configuar();
		}

		private void Configuar()
		{
			Configuration.ProxyCreationEnabled = true;
			Configuration.LazyLoadingEnabled = true;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.Property(e => e.Name)
				.IsUnicode(false);
			modelBuilder.Entity<News>()
				.Property(e => e.NewsTitle)
				.IsUnicode(false);
			modelBuilder.Entity<NewsLog>();


			var initializer = new NewsDBInitializer(modelBuilder);
			Database.SetInitializer(initializer);
		}
	}
}
