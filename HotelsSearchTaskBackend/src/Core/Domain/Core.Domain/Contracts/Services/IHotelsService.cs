using Ardalis.Result;
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
        Task<Result> Register(RegisterHotelRequestDto hotel);
        Task<Result> Update(UpdateHotelRequestDto hotel);
        Task<Result> Delete(int id);
        Task<Result<List<GetHotelResponseDto>>> Get(int id = default, string? title = default);
        Task<Result<GetHotelResponseDto>> GetById(int id);
    }
}
