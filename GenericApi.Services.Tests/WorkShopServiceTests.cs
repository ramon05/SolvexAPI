using AutoMapper;
using GenericApi.Bl.DTOs;
using GenericApi.Bl.Mapper;
using GenericApi.Bl.Validations;
using GenericApi.Core.Settings;
using GenericApi.Model.DataContext;
using GenericApi.Model.Entities;
using GenericApi.Model.Repositories;
using GenericApi.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GenericApi.Services.Tests
{
    public class WorkShopServiceTests
    {
        private readonly IWorkShopService _workShopService;
        private readonly WorkShop _workShop1 = new WorkShop
        {
            Name = "Capacitacion Web 2",
            Description = "La capacitacion es tanto backend como frontend",
            StartDate = new DateTime(1996, 06, 16),
            EndDate = new DateTime(1996, 06, 16),
            ContentSupport = "Solvex Dominicana"
        };
        private readonly WorkShop _workShop2 = new WorkShop
        {
            Name = "Capacitacion En Pyton ",
            Description = "La capacitacion es de 0 a experto",
            StartDate = new DateTime(1996, 06, 16),
            EndDate = new DateTime(1996, 06, 16),
            ContentSupport = "Solvex Dominicana"
        };
        public WorkShopServiceTests()
        {
            #region Autommaper

            var mapper = new MapperConfiguration(x => x.AddProfile<mainProfile>())
                .CreateMapper();

            #endregion

            #region Repository

            var optionsBuilder = new DbContextOptionsBuilder<WorkShopDbContext>();
            optionsBuilder.UseInMemoryDatabase("WorkShop2");

            var context = new WorkShopDbContext(optionsBuilder.Options);
            context.AddRange(_workShop1, _workShop2);
            context.SaveChanges();

            IWorkShopRepository respository = new WorkShopRepository(context);

            #endregion

            #region Validator

            var validator = new WorkShopValidator();

            #endregion

            _workShopService = new WorkShopService(respository, mapper, validator);
        }
        
        [Fact]
        public async Task ShouldSaveWorkShopAsync()
        {
            //Arrange
            var requestDto = new WorkShopDto
            {
                Name = "Capacitacion Web 2",
                Description = "Capacitacion Web 2",
                StartDate = new DateTime(1996, 06, 16),
                EndDate = new DateTime(1996, 06, 16),
                ContentSupport = "sdkhaefkaf"
            };

            //Act
            var result = await _workShopService.AddAsync(requestDto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task ShouldGetAllWorkShopAsync()
        {
            //Act
            var result = await _workShopService.GetAllAsync();

            //Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ShouldGetByIdWorkShopAsync()
        {
            //Arrange
            var id = 2;

            //Act
            var result = await _workShopService.GetByIdAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.Id, id);
        }

        [Fact]
        public async Task ShouldUpdateWorkShopAsync()
        {
            //Arrange
            var id = 2;

            var model = new WorkShopDto
            {
                Id = 2,
                Name = "Capacitacion C#",
                Description = "Capacitacion De a Experto",
                StartDate = new DateTime(1996, 06, 16),
                EndDate = new DateTime(1996, 06, 16),
                ContentSupport = "sdkhaefkaf"
            };

            //Act
            var result = await _workShopService.UpdateAsync(id, model);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Equal(result.Entity.Id, model.Id);
        }

        [Fact]
        public async Task ShouldDeleteWorkShopAsync()
        {
            //Arrange
            var id = 2;

            //Act
            var result = await _workShopService.DeleteByIdAsync(id);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.True(result.Entity.Deleted);
        }
    }
}
