using Aurum.Domain.Entity.Product;
using Aurum.Domain.Enum;
using FluentValidation;
using System.Runtime;

namespace Aurum.Domain.Validators {
    public class ProductValidator : AbstractValidator<Product> {
        public ProductValidator() {
            RuleFor(p => p.Name).NotNull()
                .WithMessage("Nome Obrigatório")
                .Length(1, 50).WithMessage("Nome deve conter entre 1 e 50 caracteres");

            RuleFor(p => p.Description)
                .MaximumLength(300).WithMessage("Descrição deve ser menor que 300 caracteres");

            RuleFor(p => p.Price)
                .NotNull()
                .GreaterThan(0).WithMessage("Preço deve ser maior que 0");

            RuleFor(p => p.Category)
                .NotNull()
                .IsInEnum().WithMessage("Categoria Inválida");

            //RuleFor(p => p.Sizes)
            //    .NotEmpty().WithMessage("Adicione ao menos um tamanho para o produto.")
            //    .ForEach(size => size.SetValidator(new SizeValidator()));
        }
    }
}
