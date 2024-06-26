using System.Text.RegularExpressions;

namespace Clean.Common.Helper
{
    public static class Validation
    {
        public static async Task<bool> ValidationMobileAsync(string value)
        {
            var mobile = value.ToString();

            if (string.IsNullOrWhiteSpace(mobile))
                return false;

            string pattern = "[0-9]+$";
            bool isMatch = Regex.IsMatch(mobile, pattern);

            if (isMatch && mobile.Length == 11 && mobile.Substring(0, 2) == "09")
                return true;

            return false;
        }

        public static async Task<bool> ValidationTehranPhone(string value)
        {
            var phone = value.ToString();

            if (string.IsNullOrWhiteSpace(phone))
                return false;

            string pattern = "[0-9]+$";
            bool isMatch = Regex.IsMatch(phone, pattern);

            if (isMatch && phone.Length == 12)
                return true;

            return false;
        }

        public static async Task<bool> ValidationPhone(string value)
        {
            var phone = value.ToString();

            if (string.IsNullOrWhiteSpace(phone))
                return false;

            string pattern = "[0-9]+$";
            bool isMatch = Regex.IsMatch(phone, pattern);

            if (isMatch && phone.Length == 11)
                return true;

            return false;
        }

        public static async Task<ValidationPhoneModel> SetMobileAsync(string value)
        {
            var mobile = value.ToString();

            if (value.Length >= 10 && value.Length <= 13)
            {
                if (value.Length == 10 && value.StartsWith("9"))
                {
                    mobile = "0" + value;
                }

                if (value.Length == 13 && value.StartsWith("+98"))
                {
                    mobile = value.Replace("+98", "0");
                }
                var check = await ValidationMobileAsync(mobile);
                return new ValidationPhoneModel() { IsTrue = check, Phone = mobile };
            }

            return new ValidationPhoneModel() { IsTrue = false, Phone = mobile };
        }


        public static async Task<ValidationPhoneModel> SetPhoneAsync(string value)
        {
            var phone = value.ToString();

            if (value.Length >= 11 && value.Length <= 12)
            {

                if (value.StartsWith("0211") && value.Length == 12)
                {
                    phone = value;
                    var check = await ValidationTehranPhone(phone);
                    return new ValidationPhoneModel() { IsTrue = check, Phone = phone };
                }
                if (!value.StartsWith("0211") && value.Length == 11)
                {
                    phone = value;
                    var check = await ValidationPhone(phone);
                    return new ValidationPhoneModel() { IsTrue = check, Phone = phone };
                }
            }

            return new ValidationPhoneModel { IsTrue = false, Phone = phone };
        }

        public static async Task<ValidationNationalModel> CheckNationalCodeAsync(string value, string value1)
        {
            var nationalCode = value.ToString();

            if (!int.TryParse(value, out _))
            {
                return new ValidationNationalModel { IsTrue = false, NationalCode = nationalCode };
            }

            var n2 = value1.ToString();

            if (!int.TryParse(value1, out _))
            {
                return new ValidationNationalModel { IsTrue = false, NationalCode = n2 };
            }

            var pettern = "[0-9]$";
            var isMatch = Regex.IsMatch(nationalCode, pettern);
            var isMatch1 = Regex.IsMatch(n2, pettern);

            if (isMatch && isMatch1 && value.Length == 10)
            {
                return new ValidationNationalModel() { IsTrue = true, NationalCode = nationalCode };
            }
            return new ValidationNationalModel() { IsTrue = false, NationalCode = nationalCode };
        }


        //Regex.IsMatch(input, @"^[a-zA-Z0-9]+$")


        public static async Task<ValidationNationalModel> CheckFarsiAsync(string value)
        {
            var nationalCode = value.ToString();

            var pettern = @"^[\u0600-\u06FF]+$";
            //var pettern = @"^[a-zA-Z, ]+$";
            var isMatch = Regex.IsMatch(nationalCode, pettern);

            if (isMatch)
            {
                return new ValidationNationalModel() { IsTrue = true, NationalCode = nationalCode };
            }
            return new ValidationNationalModel() { IsTrue = false, NationalCode = nationalCode };
        }

        public static async Task<ValidationNationalModel> CheckLatinAsync(string value)
        {
            var nationalCode = value.ToString();

            var pettern = @"^[a-zA-Z, ]+$";

            var isMatch = Regex.IsMatch(nationalCode, pettern);

            if (isMatch)
            {
                return new ValidationNationalModel() { IsTrue = true, NationalCode = nationalCode };
            }

            return new ValidationNationalModel() { IsTrue = false, NationalCode = nationalCode };
        }
    }
}
