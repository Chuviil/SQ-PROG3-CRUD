using System.ComponentModel.DataAnnotations;

namespace TP2_CRUD.Models;

public class Producto
{
    public int IdProducto { get; set; }
    [Required]
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    [Required]
    public int Cantidad { get; set; }
}