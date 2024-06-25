namespace OnlineShopping.Domain.Framework.Abstracts
{
    public interface IProduct
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
    }
}
