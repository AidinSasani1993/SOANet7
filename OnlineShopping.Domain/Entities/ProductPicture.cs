using OnlineShopping.Domain.Framework.Bases;

namespace OnlineShopping.Domain.Entities
{
    public class ProductPicture : BaseProduct
    {
        public Guid ProductRef { get; private set; }
        public Product Product { get; private set; }

        public ProductPicture(Guid productRef, string picture, string pictureAlt, string pictureTitle)
        {
            ProductRef = productRef;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
        }

        public void Modify(Guid productRef, string picture, string pictureAlt, string pictureTitle)
        {
            ProductRef = productRef;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
        }
    }
}
