using TP3_CRUD_TS.Models;

namespace TP3_CRUD_TS.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(IConfiguration configuration)
    {
        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri(configuration["Api:Url"])
        };
    }

    public async Task<List<Producto>?> GetProductos()
    {
        var productos = await _httpClient.GetFromJsonAsync<List<Producto>>("api/Producto");

        return productos;
    }

    public async Task<Producto?> GetProducto(int id)
    {
        var producto = await _httpClient.GetFromJsonAsync<Producto>($"api/Producto/{id}");

        return producto;
    }

    public async Task<Producto?> PostProducto(Producto producto)
    {
        await _httpClient.PostAsJsonAsync("api/Producto", producto);

        return producto;
    }

    public async Task<Producto?> PutProducto(int id, Producto producto)
    {
        await _httpClient.PutAsJsonAsync($"api/Producto/{id}", producto);
        
        return producto;
    }

    public async Task DeleteProducto(int id)
    {
        await _httpClient.DeleteAsync($"api/Producto/{id}");
    }
}