using Aurum.Application.Commands;
using Aurum.Application.Handlers;
using Aurum.Domain.Entity.Product;
using Aurum.Domain.Enum;
using Aurum.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aurum.UnitTests {
    public class UpdateProductCommandHandlerTest {
        [Fact]
        public async Task updateProductCommand() {
            var mockRepo = new Mock<IProductRepository>();
            var existingProduct = new Product("Product 1", "Desc", 20, EProductCategory.Parfum);

            mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(existingProduct);

            var command = new UpdateProductCommand {
                Id = existingProduct.Id,
                Name = "Updated Product 1",
                Price = 30,
                Description = "Updated Desc",
                Category = EProductCategory.Clothes
            };

            var handler = new UpdateProductCommandHandler(mockRepo.Object);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            mockRepo.Verify(repo => repo.UpdateAsync(It.IsAny<Product>()), Times.Once);
            Assert.Equal("Updated Product 1", existingProduct.Name); // Verifica se o nome foi atualizado
        }
    }
}
