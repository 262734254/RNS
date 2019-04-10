using FluentValidation;
using JNKJ.Domain.Customers;

namespace JNKJ.Validators.Customers
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Username)
                .NotNull()
                .WithMessage("Admin.ContentManagement.Blog.BlogPosts.Fields.Title.Required");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Admin.ContentManagement.Blog.BlogPosts.Fields.Body.Required").EmailAddress()
                .WithMessage("Admin.Email.FormartError");

            RuleFor(x => x.Mobile)
                .NotEmpty().WithMessage("Admin.Mobile.Required")
                .Matches("^0*(13|15)\\d{9}$").WithMessage("Admin.Mobile.FormartError");
        }
    }
}
