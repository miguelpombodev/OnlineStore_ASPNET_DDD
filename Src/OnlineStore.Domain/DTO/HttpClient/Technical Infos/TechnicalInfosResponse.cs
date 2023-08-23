namespace OnlineStore.Domain.DTO.HttpClient
{
    public class TechnicalInfosResponse : BaseStrapiResponseAttributes
    {
        public string Slug { get; set; }

        public IList<TechInfos> Infos { get; set; }
    }

    public class TechInfos
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Info_value { get; set; }
    }
}