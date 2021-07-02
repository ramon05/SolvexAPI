using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SolvexApi.Model.Entities;

namespace SolvexApi.Model.Interfaces
{
	public interface IDocumentService
	{
		IEnumerable<Document> GetAll();
		Task<Document> GetById(int id);
		Task<Document> Create(Document document);
		Task<Document> Update(Document document);
		Task<Document> Delete(int id);

	}
}
