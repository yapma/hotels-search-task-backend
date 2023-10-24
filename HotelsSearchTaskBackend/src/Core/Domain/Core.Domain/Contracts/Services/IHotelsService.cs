using Core.Domain.Dtos.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Contracts.Services
{
    public interface IHotelsService
    {
        Task Register(RegisterHotelRequestDto hotel);
        Task Update(UpdateHotelRequestDto hotel);
        Task Delete(int id);
        Task<List<GetHotelResponseDto>> Get(int id = default, string? title = default);
        Task<GetHotelResponseDto> GetById(int id);
    }
}
