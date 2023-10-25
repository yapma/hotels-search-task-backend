using Core.Application.Services.AppLog;
using Core.Application.Services.Hotels;
using Core.Domain.Contracts.Services;
using Core.Domain.Dtos.Hotel;
using Core.Domain.Entities;
using Core.Domain.Entities.ValueObjects;
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
                .AfterMapping((src, dest) =>
                {
                    dest.Address = new Address(src.Country, src.State, src.City);
                });

            TypeAdapterConfig.GlobalSettings.NewConfig<UpdateHotelRequestDto, Hotel>()
               .AfterMapping((src, dest) =>
               {
                   dest.Address = new Address(src.Country, src.State, src.City);
               });
        }
    }
}
