using Aurum.Domain.Entity.Product;
using Aurum.Domain.Enum;
using Aurum.Domain.Validators;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aurum.UnitTests {
    public class ProductValidatorsTest {
        private readonly ProductValidator _validator;

        public ProductValidatorsTest() {
            _validator = new ProductValidator();
        }

        [Fact(DisplayName = "Nome Vazio")]
        public void EmptyProductName() {
            var product = new Product("", null, 0, Domain.Enum.EProductCategory.Clothes);
            var result = _validator.TestValidate(product);
            result.ShouldHaveValidationErrorFor(p => p.Name);
        }

        [Fact(DisplayName = "Preço < 0")]
        public void PriceLessThanZero() {
            var product = new Product("Produto 001", null, 0, Domain.Enum.EProductCategory.Clothes);
            var result = _validator.TestValidate(product);
            result.ShouldHaveValidationErrorFor(p => p.Price);
        }

        [Fact(DisplayName = "Categoria Inválida")]
        public void InvalidCategory() {
            var product = new Product("Produto 001", null, 15, (EProductCategory)15);
            var result = _validator.TestValidate(product);
            result.ShouldHaveValidationErrorFor(p => p.Category);
        }
    }
}
