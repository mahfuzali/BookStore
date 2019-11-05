using BookStore.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.ValidationAttributes
{
    public class BookTitleMustBeDifferentFromDescriptionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var course = (BookForManipulationDto)validationContext.ObjectInstance;

            if (course.Title == course.Description)
            {
                return new ValidationResult(ErrorMessage,
                    new[] { nameof(BookForManipulationDto) });
            }

            return ValidationResult.Success;
        }
    }
}
