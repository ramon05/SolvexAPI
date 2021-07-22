using AutoMapper;
using FluentValidation;
using SolvexApi.Bl.DTOs;
using SolvexApi.Model.Entities;
using SolvexApi.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Services.Services
{
    public interface IDocumentService : IBaseService<Document, DocumentDto>
    { 
    }
    public class DocumentService : BaseService<Document, DocumentDto>, IDocumentService
    {
        public DocumentService(
            IDocumentRepository repository, 
            IMapper mapper, IValidator<DocumentDto> validator) 
            : base(repository, mapper, validator)
        {
        }
    }
}
