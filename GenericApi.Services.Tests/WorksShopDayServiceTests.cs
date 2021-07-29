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
    public class WorksShopDayServiceTests
    {
        private readonly IWorkShopDayService _workShopDayService;
        private readonly WorkShopDay workShopDay1 = new WorkShopDay
        {
            Day = Core.Enums.WeekDay.MONDAY,
            Mode = Core.Enums.WorkShopDayMode.ON_SITE,
            ModeLocation = "Gps",
            StartHour = new TimeSpan(10, 0, 0)
        };

        private readonly WorkShopDay workShopDay2 = new WorkShopDay
        {
            Day = Core.Enums.WeekDay.FRIDAY,
            Mode = Core.Enums.WorkShopDayMode.VIRTUAL,
            ModeLocation = "Google Map",
            StartHour = new TimeSpan(10, 0, 0)
        };

        public WorksShopDayServiceTests()
        {
            #region AutoMapper

            var mapper = new MapperConfiguration(x => x.AddProfile<mainProfile>())
                .CreateMapper();

            #endregion

            #region Repository

            var optionBuilder = new DbContextOptionsBuilder<WorkShopDbContext>();
            optionBuilder.UseInMemoryDatabase("WorkShop2");

            var context = new WorkShopDbContext(optionBuilder.Options);
            context.AddRange(workShopDay1, workShopDay2);
            context.SaveChanges();

            IWorkShopDayRepository repository = new WorkShopDayRepository(context);

            #endregion

            #region Validation

            var validator = new WorkShopDayValidator();

            #endregion

            _workShopDayService = new WorkShopDayService(repository, mapper, validator);
        }

        [Fact]
        public async Task ShouldSaveWorkShopDayAsync()
        {
            //Arrange
            var resultDto = new WorkShopDayDto
            {
                Day = Core.Enums.WeekDay.FRIDAY,
                Mode = Core.Enums.WorkShopDayMode.VIRTUAL,
                ModeLocation = "Google Map",
                StartHour = new TimeSpan(10, 0, 0)
            };

            //Act
            var result = await _workShopDayService.AddAsync(resultDto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task ShouldGetAllWorkShopDayAsync()
        {
            //Act
            var result = await _workShopDayService.GetAllAsync();

            //Assert
            Assert.NotEmpty(result);

        }

        [Fact]
        public async Task ShouldGetByIdWorkShopDayAsync()
        {
            //Arrange
            var id = 2;

            //Act
            var result = await _workShopDayService.GetByIdAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.Id, id);

        }

        [Fact]
        public async Task ShouldUpdateWorkShopAsync()
        {
            //Arrange
            var id = 2;

            var model = new WorkShopDayDto
            {
                Id = 2,
                Day = Core.Enums.WeekDay.WEDNESDAY,
                Mode = Core.Enums.WorkShopDayMode.VIRTUAL,
                ModeLocation = "Google Map",
                StartHour = new TimeSpan(10, 0, 0)
            };

            //Act
            var result = await _workShopDayService.UpdateAsync(id, model);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Equal(result.Entity.Id, model.Id);
        }

        [Fact]
        public async Task ShouldDeleteWorkShopAsync()
        {
            //Arrange
            var id = 1;

            //Act
            var result = await _workShopDayService.DeleteByIdAsync(id);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.True(result.Entity.Deleted);

        }


    }
}
