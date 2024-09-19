using Aurum.Domain.Dto;
using Aurum.Domain.Enum;
using Aurum.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Aurum.Domain.Entity.Product {
    public class Product : BaseEntity {

        protected Product() { }

        public Product(string name, string? description, decimal price, EProductCategory category) {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Category = category;
        }

        public string Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public EProductCategory Category { get; private set; }

        public void UpdateProduct(string name, string? description, decimal price, EProductCategory category) {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Category = category;
        }

        public ProductDto ToDto() {
            return new ProductDto {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                Price = this.Price,
                Category = this.Category
            };
        }

    }
}
