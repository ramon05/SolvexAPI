using Microsoft.EntityFrameworkCore;
using SolvexApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Model.DataContext
{
	public partial class WorkShopDbContext : DbContext
	{
		public WorkShopDbContext(DbContextOptions<WorkShopDbContext> options) 
			: base(options)
		{

		}

		public virtual DbSet<Document> Document { get; set; }
		public virtual DbSet<WorkShop> WorkShop { get; set; }
		public virtual DbSet<WorkShopDay> WorkShopDay { get; set; }
		public virtual DbSet<WorkShopMember> WorkShopMembers { get; set; }
	}
}
