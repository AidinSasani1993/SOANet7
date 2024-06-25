using OnlineShopping.Domain.Framework.Bases;

namespace OnlineShopping.Domain.Entities
{
    public class ProductCategory : BaseProduct
    {
        public string Description { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public List<Product> Products { get; private set; }

        public ProductCategory(string name,
                               string description,
                               string picture,
                               string pictureAlt,
                               string pictureTitle,
                               string keywords,
                               string metaDescription,
                               string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
        }

        public ProductCategory(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Modify(string name,
                           string description,
                           string picture,
                           string pictureAlt,
                           string pictureTitle,
                           string keywords,
                           string metaDescription,
                           string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            Modify();
        }

        public void ModifyMetaDescription(string metaDescription)
        {
            MetaDescription = metaDescription;
        }
    }
}
