using Core.Application.Services.AppLog;
using Core.Application.Services.Hotels;
using Core.Domain.Contracts.Services;
using Core.Domain.Dtos.Hotel;
using Core.Domain.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Extentions
{
    public static class ApplicationServicesConfig
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // add services
            services.AddScoped<ILogsService, LogsService>();
            services.AddScoped<IHotelsService, HotelsService>();

            MapperConfig();
        }

        public static void MapperConfig()
        {
            TypeAdapterConfig.GlobalSettings.NewConfig<Hotel, GetHotelResponseDto>()
                .Map(dest => dest.Country, src => src.Address.Country)
                .Map(dest => dest.State, src => src.Address.State)
                .Map(dest => dest.City, src => src.Address.City);

            TypeAdapterConfig.GlobalSettings.NewConfig<RegisterHotelRequestDto, Hotel>()
                .Map(dest => dest.Address.Country, src => src.Country)
                .Map(dest => dest.Address.State, src => src.State)
                .Map(dest => dest.Address.City, src => src.City);

            TypeAdapterConfig.GlobalSettings.NewConfig<UpdateHotelRequestDto, Hotel>()
                .Map(dest => dest.Address.Country, src => src.Country)
                .Map(dest => dest.Address.State, src => src.State)
                .Map(dest => dest.Address.City, src => src.City);
        }
    }
}
