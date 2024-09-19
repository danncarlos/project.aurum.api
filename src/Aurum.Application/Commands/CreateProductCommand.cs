using Aurum.Application.Util;
using Aurum.Domain.Entity.Product;
using Aurum.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurum.Application.Commands {
    public class CreateProductCommand : IRequest<ApiResponse<Guid>> {
        /// <summary>
        /// Nome do Produto
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição do Produto
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Preço do Produto
        /// </summary>
        /// <example>100</example>
        public decimal Price { get; set; }

        /// <summary>
        /// Tipo de Produto
        /// Sendo:
        /// 0: Clothes
        /// 1: Accessories
        /// 2: Parfum
        /// 3: Others
        /// </summary>
        public EProductCategory Category { get; set; }
    }
}