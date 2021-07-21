﻿using AutoMapper;
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
    public class DocumentService : BaseService<Document, DocumentDto>
    {
        public DocumentService(IDocumentRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
