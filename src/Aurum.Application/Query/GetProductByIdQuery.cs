﻿using Aurum.Application.Util;
using Aurum.Domain.Dto;
using Aurum.Domain.Entity.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurum.Application.Query {
    public class GetProductByIdQuery : IRequest<ApiResponse<ProductDto>> {
        public Guid ProductId { get; set; }
    }

}
