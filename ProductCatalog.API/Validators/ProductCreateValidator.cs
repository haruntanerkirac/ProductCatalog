using FluentValidation;
using ProductCatalog.Entities.DTOs;

namespace ProductCatalog.API.Validators
{
    public class ProductCreateValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ürün adı boş olamaz !")
                .MaximumLength(100).WithMessage("En fazla 100 karakter olabilir !");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Fiyat negatif olamaz !");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Stok negatif olamaz !");
        }
    }
}
