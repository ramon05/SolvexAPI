using System;
using System.Collections.Generic;
using System.Text;
using GenericApi.Model.Entities;
using GenericApi.Model.DataContext;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GenericApi.Model.Repositories;
using GenericApi.Model.Interfaces;

namespace GenericApi.Model.Repositories
{
	public interface IDocumentRepository : IBaseRepository<Document> { }
	public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
	{
		public DocumentRepository(WorkShopDbContext context) : base(context)
		{
		}

	}
}
