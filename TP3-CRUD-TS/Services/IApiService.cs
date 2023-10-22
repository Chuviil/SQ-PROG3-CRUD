using TP3_CRUD_TS.Models;

namespace TP3_CRUD_TS.Services;

public interface IApiService
{
    Task<List<Producto>?> GetProductos();
    
    Task<Producto?> GetProducto(int id);

    Task<Producto?> PostProducto(Producto producto);

    Task<Producto?> PutProducto(int id, Producto producto);

    Task DeleteProducto(int id);
}