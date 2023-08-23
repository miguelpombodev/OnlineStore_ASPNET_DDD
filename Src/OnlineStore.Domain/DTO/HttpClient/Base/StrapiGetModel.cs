namespace OnlineStore.Domain.DTO.HttpClient
{
    public class StrapiGetModel<T> where T : BaseStrapiResponseAttributes
    {
        public IList<BaseStrapiResponse<T>> Data { get; set; }
    }

    public class BaseStrapiResponse<T> where T : BaseStrapiResponseAttributes
    {
        public int Id { get; set; }
        public T Attributes { get; set; }
    }

    public abstract class BaseStrapiResponseAttributes
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
    }

}