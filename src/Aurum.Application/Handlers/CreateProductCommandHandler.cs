using Aurum.Application.Commands;
using Aurum.Application.Util;
using Aurum.Domain.Entity.Product;
using Aurum.Domain.Repositories;
using Aurum.Domain.Validators;
using Azure;
using Azure.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurum.Application.Handlers {
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ApiResponse<Guid>> {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository) {
            this._productRepository = productRepository;
        }

        public async Task<ApiResponse<Guid>> Handle(CreateProductCommand command, CancellationToken cancellationToken) {
            var product = new Product(command.Name, command.Description, command.Price, command.Category);

            var result = new ProductValidator().Validate(product);
            var response = new ApiResponse<Guid>();

            if (!result.IsValid) {
                response.Errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            await _productRepository.AddAsync(product);
            response.Data = product.Id;

            return response;
        }

    }

}
