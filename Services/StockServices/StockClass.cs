using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using StockApplication.Models;
using StockApplication.Models.DTOs;
using StockApplication.Repositary.StockRepositary;

namespace StockApplication.Services.StockServices
{
    public class StockClass : IStockService
    {
        private readonly IStock _IStock;
        private readonly IMapper _IMapper;
      

        public StockClass(IStock stock, IMapper mapper)
        {
            _IStock = stock;
            _IMapper = mapper;
           
        }

        public async Task<StockDTO> AddStock(StockCreateDTO stock)
        {
            if (string.IsNullOrWhiteSpace(stock.Symbol))
                throw new ArgumentException("Symbol is required.", nameof(stock.Symbol));

            if (string.IsNullOrWhiteSpace(stock.CompanyName))
                throw new ArgumentException("Company name is required.", nameof(stock.CompanyName));

            if (stock.LastDiv<5 || stock.MarketCap < 1000)
            {
                throw new Exception("Invalid divident or market cap value");
            }
            var createdStock = _IMapper.Map<Stock>(stock);

           await  _IStock.AddStock(createdStock);

            return _IMapper.Map<StockDTO>(createdStock);
        }

        public async Task DeleteStock(int id)
        {
            var stock = await _IStock.GetStock(u=>u.Id == id);
            if(stock == null)
            {
                throw new Exception($"Stock {id} not found");
            }
          await _IStock.DeleteStock(stock);
         
        }

        public async Task<IEnumerable<StockDTO>> GetAllStocks()
        {
            var stocks = await _IStock.GetAllStocks();
            if(stocks == null)
            {
                throw new Exception($"{nameof(GetAllStocks)}");
            }
            return  _IMapper.Map<IEnumerable<StockDTO>>(stocks);

        }

        public async Task<StockDTO?> GetStockById(int id)
        {
            var stock = await _IStock.GetStock(u => u.Id == id);
            if(stock == null)
            {
                throw new Exception($"Stock {id} not found");
            }
            return _IMapper.Map<StockDTO?>(stock);
        }

        public async Task<StockDTO> UpdateStock(StockUpdateDTO stock)
        {
            var exisitingStock = await _IStock.GetStock(u=>u.Id ==stock.Id);
            if (exisitingStock == null) {

                throw new Exception("The stock or item couldnt be found");
            }
            exisitingStock.MarketCap = stock.MarketCap;
            exisitingStock.Purchase = stock.Purchase;
            exisitingStock.LastDiv = stock.LastDiv;
            exisitingStock.Industry = stock.Industry;
            exisitingStock.CompanyName = stock.CompanyName;
            await _IStock.UpdateStock(exisitingStock);
            var requiredStock = _IMapper.Map<StockDTO>(exisitingStock);
            return requiredStock;
        }
    }
}
