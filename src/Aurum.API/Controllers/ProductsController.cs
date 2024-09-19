using Aurum.Application.Commands;
using Aurum.Application.Query;
using Aurum.Application.Util;
using Aurum.Domain.Entity.Product;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Aurum.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) {
            _mediator = mediator;
        }

        /// <summary>
        /// Cria novo produto
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Id do produto criado</returns>
        /// <response code="201">Produto criado</response>
        [HttpPost()]
        [ProducesResponseType(typeof(ApiResponse<Guid>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command) {
            try {
                if (command == null) {
                    return BadRequest("Invalid product data.");
                }

                var response = await _mediator.Send(command);

                if (!response.IsSuccess) {
                    return BadRequest(new { response.Errors });
                }

                return StatusCode((int)HttpStatusCode.Created, response);
            }
            catch (Exception ex) {
                //Log
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{productId:guid}")]
        public async Task<IActionResult> GetProduct(Guid productId) {
            try {
                var result = await _mediator.Send(new GetProductByIdQuery { ProductId = productId });
                if (!result.IsSuccess) {
                    return BadRequest(new { result.Errors });
                }

                return StatusCode((int)HttpStatusCode.OK, result);
            }
            catch (Exception ex) {
                //Log
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductCommand command) {
            try {
                if (id != command.Id) {
                    return BadRequest("O ID do produto não corresponde ao ID fornecido.");
                }

                var response = await _mediator.Send(command);

                if (!response.IsSuccess) {
                    return BadRequest(new { response.Errors });
                }

                return StatusCode((int)HttpStatusCode.OK, response);
            }
            catch (Exception ex) {
                //Log
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{productId:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid productId) {
            try {

                var response = await _mediator.Send(new DeleteProductCommand{ ProductId = productId});

                if (!response.IsSuccess) {
                    return BadRequest(new { response.Errors });
                }

                return StatusCode((int)HttpStatusCode.OK, response);
            }
            catch (Exception ex) {
                //Log
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts() {
            try {
                var result = await _mediator.Send(new GetAllProductsQuery());

                if (!result.IsSuccess) {
                    return BadRequest(new { result.Errors });
                }

                return StatusCode((int)HttpStatusCode.OK, result);
            }
            catch (Exception ex) {
                //Log
                return BadRequest(ex.Message);
            }
        }

    }
}
