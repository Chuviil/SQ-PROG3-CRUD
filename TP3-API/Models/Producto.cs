using System.ComponentModel.DataAnnotations;

namespace TP3_API.Models;

public class Producto
{
    [Key] public int IdProducto { get; set; }

    [Required] public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    [Required] public int Cantidad { get; set; }
}