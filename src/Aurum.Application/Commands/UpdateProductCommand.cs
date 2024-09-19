using Aurum.Application.Util;
using Aurum.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurum.Application.Commands {
    public class UpdateProductCommand : IRequest<ApiResponse<Unit>> {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public required EProductCategory Category { get; set; }
    }
}
