using CSProjeDemo1.CSProjeDemo1.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Data.Context
{
    public class AppDbContext:DbContext
    {
		public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
		public AppDbContext():base(){}

		public virtual DbSet<Member> Members { get; set; }
		public virtual DbSet<ScienceBook> ScienceBooks { get; set; }
		public virtual DbSet<NovelBook> NovelBooks { get; set; }
		public virtual DbSet<HistoryBook> HistoryBooks { get; set; }

		public override int SaveChanges()
		{
			ChangeTracker.LazyLoadingEnabled = true;
			return base.SaveChanges();
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseInMemoryDatabase("DataBase");
			//optionsBuilder.UseLazyLoadingProxies();
		}
	}
}
