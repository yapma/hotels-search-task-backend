using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Core.Domain.Contracts.Services;
using Core.Domain.Dtos.Hotel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelsService _hotelsService;

        public HotelsController(IHotelsService hotelsService)
        {
            this._hotelsService = hotelsService;
        }

        [HttpGet("GetHotels")]
        [TranslateResultToActionResult]
        [ExpectedFailures(ResultStatus.NotFound)]
        public async Task<Result<List<GetHotelResponseDto>>> GetHotels([FromQuery] int id = 0, [FromQuery] string? title = null)
        {
            var generalBooks = await _hotelsService.Get(id, title);
            return generalBooks;
        }

        [HttpPost("RegisterHotel")]
        [TranslateResultToActionResult]
        public async Task<Result> RegisterHotel(RegisterHotelRequestDto model)
        {
            return await _hotelsService.Register(model);
        }

        [HttpPost("UpdateHotel")]
        [TranslateResultToActionResult]
        public async Task<Result> UpdateHotel(UpdateHotelRequestDto model)
        {
            return await _hotelsService.Update(model);
        }

        [HttpDelete("DeleteHotel")]
        [TranslateResultToActionResult]
        public async Task<Result> DeleteHotel(int id)
        {
            return await _hotelsService.Delete(id);
        }
    }
}
