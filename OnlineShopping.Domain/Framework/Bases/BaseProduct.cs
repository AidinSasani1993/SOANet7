using OnlineShopping.Domain.Framework.Abstracts;

namespace OnlineShopping.Domain.Framework.Bases
{
    public class BaseProduct : BaseEntity, IProduct
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
    }
}
