using OnlineShopping.Domain.Framework.Bases;

namespace OnlineShopping.Domain.Entities
{
    public class Slide : BaseProduct
    {
        public string Heading { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public string BtnText { get; private set; }
        public string Link { get; private set; }

        public Slide(string picture,
                    string pictureAlt,
                    string pictureTitle,
                    string heading,
                    string title,
                    string text,
                    string btnText,
                    string link)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;
            Link = link;
        }

        public void Modify(string picture,
                     string pictureAlt,
                     string pictureTitle,
                     string heading,
                     string title,
                     string text,
                     string btnText,
                     string link)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;
            Link = link;
        }
    }
}
