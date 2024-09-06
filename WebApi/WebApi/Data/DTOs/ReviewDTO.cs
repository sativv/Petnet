namespace WebApi.Data.DTOs
{
    public class ReviewDTO
    {

        public string Content { get; set; } = null!;
        public int Rating { get; set; }
        public string ReviewerId { get; set; }
        public string ReviewedSellerId { get; set; }

    }

}
