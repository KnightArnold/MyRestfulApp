using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRestfulApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Apellido", "Email", "Nombre", "Password" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Gallardo", "mgallardo@gmail.com", "Marcelo", "mgallardo2021" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Armani", "farmani@gmail.com", "Franco", "farmani2021" },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "Rojas", "rrojas@gmail.com", "Robert", "rrojas2021" },
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), "Peña Biafore", "fbiafore@gmail.com", "Felipe", "fbiafore2021" },
                    { new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), "Martinez", "hmartinez@gmail.com", "Hector", "hmartinez2021" },
                    { new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"), "Casco", "mcasco@gmail.com", "Milton", "mcasco2021" },
                    { new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"), "Simon", "ssimon@gmail.com", "Santiago", "ssimon2021" },
                    { new Guid("71838f8b-6ab3-4539-9e67-4e77b8ede1c0"), "Fernandez", "efernandez@gmail.com", "Enzo", "efernandez2021" },
                    { new Guid("119f9ccb-149d-4d3c-ad4f-40100f38e918"), "Perez", "eperez@gmail.com", "Enzo", "eperez2021" },
                    { new Guid("28c1db41-f104-46e6-8943-d31c0291e0e3"), "Palavecino", "apalavecino@gmail.com", "Agustin", "apalavecino2021" },
                    { new Guid("d94a64c2-2e8f-4162-9976-0ffe03d30767"), "Alvarez", "jalvarez@gmail.com", "Julian", "jalvarez2021" },
                    { new Guid("380c2c6b-0d1c-4b82-9d83-3cf635a3e62b"), "Rollheiser", "brollheiser@gmail.com", "Benjamin", "brollheiser2021" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
