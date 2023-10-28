using Core.Domain.Contracts.Repositories;
using Core.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Infrastructure.Persistence.Mocks
{
    internal class MockHotelsRepository
    {
        public static Mock<IHotelsRepository> GetMock()
        {
            var mock = new Mock<IHotelsRepository>();
            var hotels = new List<Hotel>()
            {
                new Hotel()
                {
                    Id = 1,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    Name = "Tehran Star",
                    Address = new Core.Domain.Entities.ValueObjects.Address("Iran", "Tehran", "Tehran"),
                    Description = "Description 1",
                    StarsCount = 3
                },
                new Hotel()
                {
                    Id = 2,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    Name = "Fardis",
                    Address = new Core.Domain.Entities.ValueObjects.Address("Iran", "Mazandaran", "Babolsar"),
                    Description = "Description 2",
                    StarsCount = 4
                },
                new Hotel()
                {
                    Id = 3,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    Name = "Fariz",
                    Address = new Core.Domain.Entities.ValueObjects.Address("Iran", "Mazandaran", "Babolsar"),
                    Description = "Description 2",
                    StarsCount = 4
                },
                new Hotel()
                {
                    Id = 4,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    Name = "Test",
                    Address = new Core.Domain.Entities.ValueObjects.Address("Iran", "Mazandaran", "Babolsar"),
                    Description = "Description 2",
                    StarsCount = 4
                }
            };

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .ReturnsAsync((int id) => hotels.SingleOrDefault(x => x.Id == id));

            mock.Setup(m => m.Get(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync((int id, string name) =>
                {
                    if (id == 0 && string.IsNullOrEmpty(name))
                    {
                        return hotels;
                    }
                    return hotels.Where(x => (id == 0 || x.Id == id)
                        && (string.IsNullOrEmpty(name) || x.Name.Contains(name)))
                        .Select(x => x)
                        .ToList();
                });

            mock.Setup(m => m.Register(It.IsAny<Hotel>()))
                .Callback((Hotel model) => { hotels.Add(model); });

            mock.Setup(m => m.Delete(It.IsAny<Hotel>()))
                .Callback((Hotel model) => {
                    var hotel = hotels.Find(x => x.Id == model.Id);
                    if(hotel != null)
                        hotels.Remove(hotel);
                });

            mock.Setup(m => m.Update(It.IsAny<Hotel>()))
                .Callback((Hotel model) => {
                    var hotel = hotels.Find(x => x.Id == model.Id);
                    if(hotel != null)
                        hotel.Name = model.Name;
                });

            return mock;
        }
    }
}
