using System;
using System.Collections.Generic;
using System.Text;
using SolvexApi.Model.Entities;
using SolvexApi.Model.DataContext;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SolvexApi.Model.Interfaces;

namespace SolvexApi.Services
{
	public class DocumentService : IDocumentService
	{
		private readonly IRepository<Document> _documentRepository;

		public DocumentService(IRepository<Document> documentRepository)
		{
			_documentRepository = documentRepository;
		}

		public IEnumerable<Document> GetAll()
		{
			return  _documentRepository.GetAll().Where(x => x.Deleted == false);
		}

		public async Task<Document> GetById(int id) => await _documentRepository.GetById(id);

		public async Task<Document> Create(Document document)
		{
			await _documentRepository.Create(document);
			
			return document;
		}
		
		public async Task<Document> Update(Document document)
		{
			document.UpdatedDate = DateTime.Now;
			await _documentRepository.Update(document);
			return document;
		}

		public async Task<Document> Delete(int id)
		{
			var documentToDelete = await GetById(id);
			documentToDelete.Deleted = true;
			documentToDelete.DeletedDate = DateTime.Now;
			return documentToDelete;
		}
	}
}
