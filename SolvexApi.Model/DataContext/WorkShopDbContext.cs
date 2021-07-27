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
		public virtual DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasData(
			 new User
			 {
				 CreatedDate = DateTimeOffset.UtcNow,
				 Dob = DateTime.Now,
				 Gender = Core.Enums.Gender.MALE,
				 LastName = "Admin",
				 MiddleName = "Admin",
				 Name = "Admin",
				 Password = "Hola123,",
				 SecondLastName = "Admin",
				 UserName = "Admin",
				 DocumentType = Core.Enums.DocumentType.ID,
				 DocumentTypeValue = "00000000000",
				 Id = 1
			 });

			base.OnModelCreating(modelBuilder);
		}
	}
}
