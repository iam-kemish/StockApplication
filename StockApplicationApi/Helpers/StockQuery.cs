namespace StockApplicationApi.Helpers
{
    public class StockQuery
    {
        public string? symbol { get; set; } = string.Empty;
        public string? companyName { get; set; } = string.Empty;
        public string? sortBy {  get; set; } = string.Empty;

        public bool isDescending { get; set; } = false;

        public int pageNumber { get; set; } = 1;

        public int pageSize { get; set; } = 20;

      
    }

}
