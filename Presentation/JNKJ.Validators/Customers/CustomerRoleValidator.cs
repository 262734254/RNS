using FluentValidation;
using JNKJ.Domain.Customers;

namespace JNKJ.Validators.Customers
{
    public class CustomerRoleValidator : AbstractValidator<CustomerRole>
    {
        public CustomerRoleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Admin.ContentManagement.Blog.BlogPosts.Fields.Title.Required");

            RuleFor(x => x.RoleType)
                .NotEmpty().WithMessage("Admin.ContentManagement.Blog.BlogPosts.Fields.Body.Required");

        }
    }
}
