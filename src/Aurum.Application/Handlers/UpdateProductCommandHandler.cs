using Aurum.Application.Commands;
using Aurum.Application.CommandValidators;
using Aurum.Application.Util;
using Aurum.Domain.Repositories;
using Aurum.Infra.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Aurum.Application.Handlers {
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ApiResponse<Unit>> {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository) {
            this._productRepository = productRepository;
        }

        public async Task<ApiResponse<Unit>> Handle(UpdateProductCommand command, CancellationToken cancellationToken) {
            // Buscar o produto existente
            var product = await _productRepository.GetByIdAsync(command.Id);
            if (product == null) {
                return new ApiResponse<Unit> {
                    Errors = ["Produto não encontrado"],
                };
            }

            var response = new ApiResponse<Unit>();
            var result = new UpdateProductCommandValidator().Validate(command);

            if (!result.IsValid) {
                return new ApiResponse<Unit> {
                    Errors = result.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            product.UpdateProduct(command.Name, command.Description, command.Price, command.Category);
            await this._productRepository.UpdateAsync(product);

            return response;
        }

    }
}
