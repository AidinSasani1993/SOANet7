using OnlineShopping.Domain.Framework.Bases;

namespace OnlineShopping.Domain.Entities
{
    public class Product : BaseProduct
    {
        public Guid CategoryRef { get; private set; }
        public ProductCategory Category { get; private set; }
        public string Code { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public List<ProductPicture> ProductPictures { get; private set; }
        public List<ColleagueDiscount> ColleagueDiscounts { get; private set; }
        public List<Inventory> Inventories { get; private set; }

        public Product(string name, string code, string shortDescription, string description,
            string picture, string pictureAlt, string pictureTitle, Guid categoryRef, string slug,
            string keywords, string metaDescription)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryRef = categoryRef;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            //ProductPictures=new List<ProductPicture>();
        }

        #region [-Modify-]
        public void Modify(string name, string code, string shortDescription, string description,
            string picture, string pictureAlt, string pictureTitle, Guid categoryRef, string slug,
            string keywords, string metaDescription)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryRef = categoryRef;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
        } 
        #endregion

        #region [-ModifyProductCode(string code)-]
        public void ModifyProductCode(string code)
        {
            Code = code;
        } 
        #endregion
    }
}
