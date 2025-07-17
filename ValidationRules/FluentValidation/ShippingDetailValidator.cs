using FluentValidation;
using MvcWebUI.Models;

namespace MvcWebUI.ValidationRules.FluentValidation
{
    public class ShippingDetailValidator : AbstractValidator<ShippingDetail>
    {
        public ShippingDetailValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty().WithMessage("Lütfen ad alanını doldurunuz.");
            RuleFor(s => s.LastName).NotEmpty().WithMessage("Lütfen soyad alanını doldurunuz.");
            RuleFor(s => s.Email).EmailAddress().WithMessage("Lütfen geçerli bir e-mail adresi giriniz.");
            RuleFor(s => s.City).NotEmpty().WithMessage("Lütfen şehir alanını doldurunuz.");
            RuleFor(s => s.Address).NotEmpty().WithMessage("Lütfen adres alanını doldurunuz.");
            RuleFor(s => s.Age).InclusiveBetween(18, 65).WithMessage("Lütfen geçerli bir yaş giriniz.");
        }
    }
}
