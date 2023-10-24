using Ardalis.Result;
using Core.Domain.Common;
using Core.Domain.Contracts.Repositories;
using Core.Domain.Contracts.Services;
using Core.Domain.Dtos.Hotel;
using Core.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Services.Hotels
{
    public class HotelsService : IHotelsService
    {
        private readonly IHotelsRepository _hotelsRepository;

        public HotelsService(IHotelsRepository hotelsRepository)
        {
            _hotelsRepository = hotelsRepository;
        }

        public async Task<Result> Delete(int id)
        {
            var hotel = await _hotelsRepository.GetById(id);
            if (hotel == null)
                return Result.NotFound(Messages.HOTEL_NOT_FOUND);
            await _hotelsRepository.Delete(hotel);
            return Result.Success();
        }

        public async Task<Result<List<GetHotelResponseDto>>> Get(int id = 0, string? title = null)
        {
            var hotels = await _hotelsRepository.Get(id, title);
            if (hotels == null || hotels.Count == 0)
                return Result.NotFound(Messages.HOTEL_NOT_FOUND);

            return Result.Success(
                 hotels.Select(x => x.Adapt<GetHotelResponseDto>())
                    .ToList()
                );
        }

        public async Task<Result<GetHotelResponseDto>> GetById(int id)
        {
            var hotel = await _hotelsRepository.GetById(id);
            if (hotel == null)
                return Result.NotFound(Messages.HOTEL_NOT_FOUND);
            return Result.Success(hotel.Adapt<GetHotelResponseDto>());
        }

        public async Task<Result> Register(RegisterHotelRequestDto hotel)
        {
            await _hotelsRepository.Register(hotel.Adapt<Hotel>());
            return Result.Success();
        }

        public async Task<Result> Update(UpdateHotelRequestDto hotel)
        {
            await _hotelsRepository.Update(hotel.Adapt<Hotel>());
            return Result.Success();
        }
    }
}
