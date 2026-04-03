using AutoMapper;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.StockDTOs;

namespace StockApplicationApi.Mapper
{
    public class MapConfig: Profile
    {
        public MapConfig() { 
          CreateMap<Stock,StockDTO>().ReverseMap();
            CreateMap<Stock, StockCreateDTO>().ReverseMap();
        }
    }
}
