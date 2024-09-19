using Aurum.Application.Commands;
using Aurum.Application.Handlers;
using Aurum.Domain.Entity.Product;
using Aurum.Domain.Enum;
using Aurum.Domain.Repositories;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aurum.UnitTests {
    public class CreateProductCommandHandlerTest {
        [Fact(DisplayName = "Deve criar produto se command for válido")]
        public async Task CreateProductValidComand() {
            var mockRepository = new Mock<IProductRepository>();
            var command = new CreateProductCommand {
                Name = "Produto 001 - Test",
                Description = "Description",
                Price = 15,
                Category = Domain.Enum.EProductCategory.Clothes
            };

            var createProduct = new CreateProductCommandHandler(mockRepository.Object);
            var result = await createProduct.Handle(command, CancellationToken.None);

            // Assert
            mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Product>()), Times.Once);
            Assert.IsType<Guid>(result.Data); // Verifica se um Guid foi retornado
        }

        //[Fact]
        //public async Task CreateProductAsync_Should_Throw_Exception_When_Product_Is_Null() {
        //    var mockRepository = new Mock<IProductRepository>();
        //    var createProduct = new CreateProductCommandHandler(mockRepository.Object);

        //    CreateProductCommand nullProduct = null;
        //    var result = await createProduct.Handle(nullProduct, CancellationToken.None);

        //    // Assert
        //    //await act.Should().ThrowAsync<ArgumentNullException>();
        //}

    }
}
