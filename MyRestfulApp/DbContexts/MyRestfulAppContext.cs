using Microsoft.EntityFrameworkCore;
using MyRestfulApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestfulApp.DbContexts
{
    public class MyRestfulAppContext : DbContext
    {
        public MyRestfulAppContext(DbContextOptions<MyRestfulAppContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Nombre = "Marcelo",
                    Apellido = "Gallardo",
                    Email = "mgallardo@gmail.com",
                    Password = "mgallardo2021"
                },
                new User()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Nombre = "Franco",
                    Apellido = "Armani",
                    Email = "farmani@gmail.com",
                    Password = "farmani2021"
                },
                new User()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Nombre = "Robert",
                    Apellido = "Rojas",
                    Email = "rrojas@gmail.com",
                    Password = "rrojas2021"
                },
                new User()
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    Nombre = "Felipe",
                    Apellido = "Peña Biafore",
                    Email = "fbiafore@gmail.com",
                    Password = "fbiafore2021"
                },
                new User()
                {
                    Id = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    Nombre = "Hector",
                    Apellido = "Martinez",
                    Email = "hmartinez@gmail.com",
                    Password = "hmartinez2021"
                },
                new User()
                {
                    Id = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                    Nombre = "Milton",
                    Apellido = "Casco",
                    Email = "mcasco@gmail.com",
                    Password = "mcasco2021"
                },
                new User()
                {
                    Id = Guid.Parse("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                    Nombre = "Santiago",
                    Apellido = "Simon",
                    Email = "ssimon@gmail.com",
                    Password = "ssimon2021"
                },
                new User()
                {
                    Id = Guid.Parse("71838f8b-6ab3-4539-9e67-4e77b8ede1c0"),
                    Nombre = "Enzo",
                    Apellido = "Fernandez",
                    Email = "efernandez@gmail.com",
                    Password = "efernandez2021"
                },
                new User()
                {
                    Id = Guid.Parse("119f9ccb-149d-4d3c-ad4f-40100f38e918"),
                    Nombre = "Enzo",
                    Apellido = "Perez",
                    Email = "eperez@gmail.com",
                    Password = "eperez2021"
                },
                new User()
                {
                    Id = Guid.Parse("28c1db41-f104-46e6-8943-d31c0291e0e3"),
                    Nombre = "Agustin",
                    Apellido = "Palavecino",
                    Email = "apalavecino@gmail.com",
                    Password = "apalavecino2021"
                },
                new User()
                {
                    Id = Guid.Parse("d94a64c2-2e8f-4162-9976-0ffe03d30767"),
                    Nombre = "Julian",
                    Apellido = "Alvarez",
                    Email = "jalvarez@gmail.com",
                    Password = "jalvarez2021"
                },
                new User()
                {
                    Id = Guid.Parse("380c2c6b-0d1c-4b82-9d83-3cf635a3e62b"),
                    Nombre = "Benjamin",
                    Apellido = "Rollheiser",
                    Email = "brollheiser@gmail.com",
                    Password = "brollheiser2021"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
