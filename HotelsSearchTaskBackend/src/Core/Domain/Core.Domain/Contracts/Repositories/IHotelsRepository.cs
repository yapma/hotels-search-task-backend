using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Contracts.Repositories
{
    public interface IHotelsRepository
    {
        Task Register(Hotel hotel);
        Task Update(Hotel hotel);
        Task Delete(Hotel hotel);
        Task<List<Hotel>> Get(int id = default, string? name = default);
        Task<Hotel> GetById(int id);
    }
}
