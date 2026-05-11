namespace StockApplicationApi.Helpers
{
    public class RedisCacheStrings
    {
        public static class CacheKeys
        {


            public const string CommentList = "comments_list:";
            public const string StockList = "stocks_list:";
            public static string CommentDetail(int id) => $"{"comments:"}{id}";
            public static string StockDetail(int id) => $"{"stocks:"}{id}";

            public static string GetStockListKey(StockQuery q) =>
                $"{StockList}p{q.PageNumber}_s{q.PageSize}_{q.Symbol}";
        }
    }
}
