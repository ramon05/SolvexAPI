using GenericApi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Model.DataContext
{
	public partial class WorkShopDbContext : BaseDbContext
	{
		public WorkShopDbContext(DbContextOptions<WorkShopDbContext> options) 
			: base(options)
		{
		}

		public virtual DbSet<Document> Documents { get; set; }
		public virtual DbSet<WorkShop> WorkShops { get; set; }
		public virtual DbSet<WorkShopDay> WorkShopDays { get; set; }
		public DbSet<WorkShopMember> WorkShopMembers { get; set; }
		public virtual DbSet<Member> Members { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
