using Aurum.Application.Query;
using Aurum.Application.Util;
using Aurum.Domain.Dto;
using Aurum.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurum.Application.Handlers {
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ApiResponse<ProductDto>> {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        public async Task<ApiResponse<ProductDto>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken) {
            var product = await _productRepository.GetByIdAsync(query.ProductId);

            if (product == null) {
                return new ApiResponse<ProductDto> {
                    Errors = ["Produto não encontrado"],
                };
            }

            var response = new ApiResponse<ProductDto> {
                Data = product.ToDto()
            };

            return response;

        }
    }
}
