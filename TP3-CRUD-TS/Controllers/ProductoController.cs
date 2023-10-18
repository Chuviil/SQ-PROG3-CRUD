using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using TP3_CRUD_TS.Models;
using TP3_CRUD_TS.Util;

namespace TP3_CRUD_TS.Controllers;

public class ProductoController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl = "http://localhost:5285";

    public ProductoController()
    {
        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri(_apiBaseUrl)
        };
    }

    public async Task<IActionResult> Index()
    {
        var productos = await _httpClient.GetFromJsonAsync<List<Producto>>("api/Producto");
        
        return View(productos);
    }

    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Producto producto)
    {
        await _httpClient.PostAsJsonAsync("api/Producto", producto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
        var producto = await _httpClient.GetFromJsonAsync<Producto>($"api/Producto/{id}");
        if (producto != null) return View(producto);
        return RedirectToAction("Index"); 
    }

    public async Task<IActionResult> Edit(int id)
    {
        var producto = await _httpClient.GetFromJsonAsync<Producto>($"api/Producto/{id}");
        if (producto!= null) return View(producto);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Producto producto)
    {
        await _httpClient.PutAsJsonAsync($"api/Producto/{producto.IdProducto}", producto);
        
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _httpClient.DeleteAsync($"api/Producto/{id}");
        
        return RedirectToAction("Index");
    }

}