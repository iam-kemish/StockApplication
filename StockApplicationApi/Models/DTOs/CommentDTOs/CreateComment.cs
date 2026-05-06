namespace StockApplicationApi.Models.DTOs.CommentDTOs
{
    public class CreateComment
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int StockId { get; set; }
    }
}
