using System;
using System.ComponentModel.DataAnnotations;

namespace ExampleSolution.MVC.CustomValidation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MinValueAttribute : ValidationAttribute
    {
        public double MinValue { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var typedValue = value as decimal?;

            if (typedValue.HasValue)
            {
                return (double)typedValue >= this.MinValue ? ValidationResult.Success : new ValidationResult($"Value should be greater or equal than {this.MinValue}");
            }

            throw new ArgumentException("Value of wrong type");
        }
    }
}
