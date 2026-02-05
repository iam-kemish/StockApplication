using AutoMapper;
using StockApplication.Models;
using StockApplication.Models.DTOs;

namespace StockApplication.Mapper
{
    public class MapConfig: Profile
    {
        public MapConfig() { 
          CreateMap<Stock,StockDTO>().ReverseMap();
        }
    }
}
