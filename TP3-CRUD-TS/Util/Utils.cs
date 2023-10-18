using TP3_CRUD_TS.Models;

namespace TP3_CRUD_TS.Util;

public class Utils
{
    public static List<Producto> ListaProductos = new List<Producto>()
    {
        new Producto(){IdProducto = 0, Nombre = "Producto 1", Descripcion = "Descripcion 1", Cantidad = 10},
        new Producto(){IdProducto = 1, Nombre = "Producto 2", Descripcion = "Descripcion 2", Cantidad = 20},
        new Producto(){IdProducto = 2, Nombre = "Producto 3", Descripcion = "Descripcion 3", Cantidad = 3}
    };
}