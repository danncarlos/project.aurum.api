using Aurum.Application.Util;
using Aurum.Domain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurum.Application.Query {
    public class GetAllProductsQuery : IRequest<ApiResponse<IEnumerable<ProductDto>>> { }
}
