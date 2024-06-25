using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Application.Validations
{
    public class CustomValidatorAttribute : ValidationAttribute
    {
        public Type? DbContextType { get; set; }
        public Type? DataType { get; set; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (DbContextType is not null && DataType is not null)
            {
                DbContext dbContext = validationContext.GetRequiredService(DbContextType) as DbContext;

                if (dbContext is not null && dbContext.Find(DataType, value) is null)
                {
                    return new ValidationResult(ErrorMessage ?? $"There is No object with primary key{value}");
                }

            }

            return ValidationResult.Success;
        }
    }
}
