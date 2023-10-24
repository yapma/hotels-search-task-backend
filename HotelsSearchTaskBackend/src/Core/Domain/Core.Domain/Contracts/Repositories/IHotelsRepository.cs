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
        Task Delete(int id);
        Task<List<Hotel>> Get(int id = default, string? title = default);
        Task<Hotel> GetById(int id);
    }
}
