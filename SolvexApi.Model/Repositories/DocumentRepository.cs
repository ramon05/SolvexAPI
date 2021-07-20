using System;
using System.Collections.Generic;
using System.Text;
using SolvexApi.Model.Entities;
using SolvexApi.Model.DataContext;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SolvexApi.Model.Interfaces;
using SolvexApi.Model.Repositories;

namespace SolvexApi.Model.Repositories
{
	public interface IDocumentRepository : IBaseRepository<Document> { }
	public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
	{
		public DocumentRepository(WorkShopDbContext context) : base(context)
		{
		}

	}
}
