using Core.Domain.Contracts.Repositories;
using Core.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Infrastructure.Persistence.Mocks;

namespace UnitTests.Infrastructure.Persistence
{
    public class HotelsRepositoryUnitTests
    {
        private readonly Mock<IHotelsRepository> _repository;

        public HotelsRepositoryUnitTests()
        {
            _repository = MockHotelsRepository.GetMock();
        }

        [Fact]
        public async Task Get_NonParameter_ReturnsAllOfHotels()
        {
            // Act
            var result = await _repository.Object.Get();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Get_WithValidId_ReturnsOneHotel()
        {
            // Arrange
            int id = 2;

            // Act
            var result = await _repository.Object.Get(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result[0].Id);
        }

        [Fact]
        public async Task Get_WithValidName_ReturnsFilteredHotels()
        {
            // Arrange
            string name = "Far";

            // Act
            var result = await _repository.Object.Get(name: name);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetById_WithValidId_ReturnsOneHotel()
        {
            // Arrange
            int id = 2;

            // Act
            var result = await _repository.Object.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task Register_WithValidModel_AddHotelToContext()
        {
            // Arrange
            int id = 5;
            var model = new Hotel()
            {
                Id = id,
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                Name = "Test",
                Address = new Core.Domain.Entities.ValueObjects.Address("Iran", "Mazandaran", "Babolsar"),
                Description = "Description 5",
                StarsCount = 4
            };

            // Act
            await _repository.Object.Register(model);
            var bookObj = await _repository.Object.GetById(id);

            // Assert
            Assert.Equal(id, bookObj.Id);
        }

        [Fact]
        public async Task Update_WithValidModel_UpdateHotelInContext()
        {
            // Arrange
            int id = 1;
            var newName = "Test";
            var model = new Hotel()
            {
                Id = id,
                Name = newName,
            };

            // Act
            await _repository.Object.Update(model);
            var hotelObj = await _repository.Object.GetById(id);

            // Assert
            Assert.Equal(newName, hotelObj.Name);
        }

        [Fact]
        public async Task Delete_WithValidId_DeteteHotelFromContext()
        {
            // Arrange
            int id = 4;

            // Act
            await _repository.Object.Delete(new Hotel() { Id=id});
            var hotelObj = await _repository.Object.GetById(id);

            // Assert
            Assert.Null(hotelObj);
        }
    }
}
