using OnlineShopping.Domain.Enums;

namespace OnlineShopping.Domain.Entities
{
    public class Sms 
    {
        public Guid Id { get; private set; }
        public string Text { get; private set; }
        public DateTime SendDateTime { get; private set; }
        public SmsResult Result { get; private set; }
        public SmsProvider Provider  { get; private set; }

        public Sms(string text, DateTime sendDateTime, SmsResult result, SmsProvider provider)
        {
            Text = text;
            SendDateTime = sendDateTime;
            Result = result;
            Provider = provider;
        }
    }
}
