using Microsoft.EntityFrameworkCore;
using TP3_API.Models;

namespace TP3_API.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    public DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>().HasData(
            new Producto { IdProducto = 1, Nombre = "Producto 1", Descripcion = "Descripcion 1", Cantidad = 10 },
            new Producto { IdProducto = 2, Nombre = "Producto 2", Descripcion = "Descripcion 2", Cantidad = 40 },
            new Producto { IdProducto = 3, Nombre = "Producto 3", Descripcion = "Descripcion 3", Cantidad = 23 }
        );
    }
}