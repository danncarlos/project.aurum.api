using Aurum.Application.Commands;
using Aurum.Application.Util;
using Aurum.Domain.Entity.Product;
using Aurum.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurum.Application.Handlers {
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ApiResponse<string>> {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository) {
            this._productRepository = productRepository;
        }

        public async Task<ApiResponse<string>> Handle(DeleteProductCommand command, CancellationToken cancellationToken) {
            var response = new ApiResponse<string>();
            await this._productRepository.DeleteAsync(command.ProductId);

            return response;
        }
    }
}
