using Aurum.Application.Util;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurum.Application.Commands {
    public class DeleteProductCommand : IRequest<ApiResponse<string>> {
        public Guid ProductId { get; set; }
    }

}
