using Aurum.Application.Commands;
using Aurum.Application.Handlers;
using Aurum.Domain.Dto;
using Aurum.Domain.Entity.Product;
using Aurum.Domain.Enum;
using Aurum.Domain.Repositories;
using Aurum.Domain.Validators;
using FluentAssertions;
using FluentValidation.TestHelper;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Aurum.UnitTests {
    public class ProductTests {

        [Fact(DisplayName = "Deve Converter Product para ProductDto")]
        public void ConvertProductToDto() {
            var product = new Product("Produto TESTE", "Descrição do produto", 0, Domain.Enum.EProductCategory.Clothes);
            var result = product.ToDto();

            Assert.IsType<ProductDto>(result);
        }

    }
}
