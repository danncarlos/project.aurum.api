using Aurum.Application.Query;
using Aurum.Application.Util;
using Aurum.Domain.Dto;
using Aurum.Domain.Entity.Product;
using Aurum.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurum.Application.Handlers {
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ApiResponse<IEnumerable<ProductDto>>> {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        public async Task<ApiResponse<IEnumerable<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken) {
            var products = await this._productRepository.GetAllAsync();

            var response = new ApiResponse<IEnumerable<ProductDto>>();
            var productDtos = products.Select(product => product.ToDto());

            return new ApiResponse<IEnumerable<ProductDto>>() { Data = productDtos };
        }
    }
}
