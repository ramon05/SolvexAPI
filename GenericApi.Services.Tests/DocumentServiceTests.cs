using AutoMapper;
using GenericApi.Bl.DTOs;
using GenericApi.Bl.Mapper;
using GenericApi.Bl.Validations;
using GenericApi.Model.DataContext;
using GenericApi.Model.Entities;
using GenericApi.Model.Repositories;
using GenericApi.Services.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GenericApi.Services.Tests
{
    public class DocumentServiceTests
    {
        private readonly IDocumentService _documentService;

        private readonly Document _document1 = new Document
        {
            FileName = "Document 1",
            OriginalName = "Documento de Trabajo",
            ContentType = "aienadld"
        };

        private readonly Document _document2 = new Document
        {
            FileName = "Document 2",
            OriginalName = "Documento de Negocio",
            ContentType = "aienadld"
        };

        public DocumentServiceTests()
        {
            #region AutoMapper

             var mapper = new MapperConfiguration(x => x.AddProfile<mainProfile>())
               .CreateMapper();

            #endregion

            #region Repository

            var optionBuilder = new DbContextOptionsBuilder<WorkShopDbContext>();
            optionBuilder.UseInMemoryDatabase("WorkShop2");

            var context = new WorkShopDbContext(optionBuilder.Options);
            context.AddRange(_document1, _document2);
            context.SaveChanges();

            var repository = new DocumentRepository(context);

            #endregion

            #region Validator

            var validator = new DocumentValidator();

            #endregion

            _documentService = new DocumentService(repository, mapper, validator);
        }

        [Fact]
        public async Task ShouldSaveDocumentAsync()
        {
            //Arrange
            var requestDto = new DocumentDto
            {
                FileName = "Document 3",
                OriginalName = "Documento de Trabajo",
                ContentType = "aienadld"
            };

            //Act
            var result = await _documentService.AddAsync(requestDto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task ShouldGetAllDocumetAsync()
        {
            //Act
            var result = await _documentService.GetAllAsync();

            //Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ShouldGetByIdDocumentAsync()
        {
            //Arrange
            var id = 2;

            //Act
            var result = await _documentService.GetByIdAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.Id, id);
        }

        [Fact]
        public async Task ShouldUpdateDocumentAsync()
        {
            //Arrange
            var id = 2;

            var requestModelDto = new DocumentDto
            {
                Id = 2,
                FileName = "Document de Nacimiento",
                OriginalName = "Documento Personales",
                ContentType = "kaadiendo"
            };

            //Act
            var result = await _documentService.UpdateAsync(id, requestModelDto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Equal(result.Entity.Id, requestModelDto.Id);
        }

        [Fact]
        public async Task ShouldDeleteAsync()
        {
            //Arrange 
            var id = 1;

            //Act
            var result = await _documentService.DeleteByIdAsync(id);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.True(result.Entity.Deleted);
        }
    }
}
