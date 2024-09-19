using Aurum.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurum.Application.CommandValidators {
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand> {
        public UpdateProductCommandValidator() {
            RuleFor(p => p.Name).NotEmpty()
                .WithMessage("Nome Obrigatório")
                .Length(1, 50).WithMessage("Nome deve conter entre 1 e 50 caracteres");

            RuleFor(p => p.Description)
                .MaximumLength(300).WithMessage("Descrição deve ser menor que 300 caracteres");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Preço deve ser maior que 0");


            RuleFor(p => p.Category)
                .IsInEnum().WithMessage("Categoria Inválida");
        }
    }
}
