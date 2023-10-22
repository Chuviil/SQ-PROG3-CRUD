using Microsoft.AspNetCore.Mvc;
using TP3_CRUD_TS.Models;
using TP3_CRUD_TS.Services;

namespace TP3_CRUD_TS.Controllers;

public class ProductoController : Controller
{
    private readonly IApiService _apiService;
    
    public ProductoController(IApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Index()
    {
        var productos = await _apiService.GetProductos();

        return View(productos);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Producto producto)
    {
        await _apiService.PostProducto(producto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
        var producto = await _apiService.GetProducto(id);
        if (producto != null) return View(producto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var producto = await _apiService.GetProducto(id);
        if (producto != null) return View(producto);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Producto producto)
    {
        await _apiService.PutProducto(producto.IdProducto, producto);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _apiService.DeleteProducto(id);

        return RedirectToAction("Index");
    }
}