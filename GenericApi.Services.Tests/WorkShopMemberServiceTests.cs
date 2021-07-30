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
    public class WorkShopMemberServiceTests
    {
        private readonly IWorkShopMemberService _workShopMemberService;
        private readonly WorkShopMember _workShopMember1 = new WorkShopMember
        {
            Role = Core.Enums.WorkShopMemberRole.STUDENT,
            WorkShopId = 1,
            UserId = 1
        };

        private readonly WorkShopMember _workShopMember2 = new WorkShopMember
        {
            Role = Core.Enums.WorkShopMemberRole.TEACHER,
            WorkShopId = 1,
            UserId = 1
        };

        public WorkShopMemberServiceTests()
        {
            #region AutoMapper

            var mapper = new MapperConfiguration(x => x.AddProfile<mainProfile>())
                .CreateMapper();

            #endregion

            #region Repository
            var optionBuilder = new DbContextOptionsBuilder<WorkShopDbContext>();
            optionBuilder.UseInMemoryDatabase("WorkShop2");

            var context = new WorkShopDbContext(optionBuilder.Options);
            context.AddRange(_workShopMember1, _workShopMember2);
            context.SaveChanges();
;
            var repository = new WorkShopMemberRepository(context);

            #endregion

            #region Validator

            var validator = new WorkShopMemberValidator();

            #endregion

            _workShopMemberService = new WorkShopMemberService(repository, mapper, validator);
        }

        [Fact]
        public async Task ShouldSaveWorkShopMemberAsync()
        {
            //Arrange
            var requestModelDto = new WorkShopMemberDto
            {
                Role = Core.Enums.WorkShopMemberRole.STUDENT,
                WorkShopId = 1,
                UserId = 1
            };

            //Act
            var result = await _workShopMemberService.AddAsync(requestModelDto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Empty(result.Errors);

        }

        [Fact]
        public async Task ShouldGetAllWorkShopMemberAsync()
        {
            //Act
            var result = await _workShopMemberService.GetAllAsync();

            //Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ShouldGetByIdWorkShopMemberAsync()
        {
            //Arrange
            var id = 2;

            //Act
            var result = await _workShopMemberService.GetByIdAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.Id, id);
        }

        [Fact]
        public async Task ShouldUpdateWorkShopMemberAsync()
        {
            //Arrange
            var id = 2;

            var model = new WorkShopMemberDto
            {
                Id = 2,
                Role = Core.Enums.WorkShopMemberRole.STUDENT,
                WorkShopId = 1,
                UserId = 1
            };

            //Act
            var result = await _workShopMemberService.UpdateAsync(id, model);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Equal(result.Entity.Id, model.Id);
        }

        [Fact]
        public async Task ShouldDeleteWorkShopMemberAsync()
        {
            //Arrange
            var id = 1;

            //Act
            var result = await _workShopMemberService.DeleteByIdAsync(id);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Equal(result.Entity.Id, id);
            Assert.True(result.Entity.Deleted);
        }
    }
}
