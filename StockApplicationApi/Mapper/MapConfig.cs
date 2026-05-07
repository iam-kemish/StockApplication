using AutoMapper;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.CommentDTOs;
using StockApplicationApi.Models.DTOs.StockDTOs;

namespace StockApplicationApi.Mapper
{
    public class MapConfig: Profile
    {
        public MapConfig() { 
            CreateMap<Stock, StockUpdateDTO>().ReverseMap();
            CreateMap<Stock,StockDTO>().ReverseMap();
            CreateMap<Stock, StockCreateDTO>().ReverseMap();
            CreateMap<Comment,CommentDto>().ReverseMap();
            CreateMap<Comment, CreateComment>().ReverseMap();
        }
    }
}
