using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aurum.Infra.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            //Prods
            migrationBuilder.Sql(@"
                INSERT INTO TB_PRODUCT (Id, DtCreation, IsEnable, Name, Description, Price, Category )
                VALUES 
                ('f4b0d071-769c-4f09-b580-08dcd7de0b24', GETDATE(), 1, 'Jeans Jacket', 'Classic denim jacket with a modern fit.', 120, 0),
                ('c7b972be-d3e8-4e24-b681-08dcd7de0b24', GETDATE(), 1, 'Leather Belt', 'High-quality leather belt, perfect for formal wear.', 60, 1),
                ('d3cfc6ac-8156-498a-2983-08dcd7de0b24', GETDATE(), 1, 'Wool Scarf', 'Comfortable and warm wool scarf for the winter.', 45, 1),
                ('e89f8f24-ecff-4d79-88a7-08dcd7de0b24', GETDATE(), 1, 'Running Shoes', 'Lightweight running shoes with excellent grip.', 95, 0),
                ('47fd3297-b00b-4e65-980b-08dcd7de0b24', GETDATE(), 1, 'Leather Wallet', 'Compact leather wallet with multiple card slots.', 40, 1);
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql("DELETE FROM TB_PRODUCT WHERE Id IN ('f4b0d071-769c-4f09-b580-08dcd7de0b24', 'c7b972be-d3e8-4e24-b681-08dcd7de0b24','d3cfc6ac-8156-498a-2983-08dcd7de0b24', 'e89f8f24-ecff-4d79-88a7-08dcd7de0b24', '47fd3297-b00b-4e65-980b-08dcd7de0b24')");
        }
    }
}
