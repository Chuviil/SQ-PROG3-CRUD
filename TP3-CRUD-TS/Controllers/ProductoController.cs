using Microsoft.AspNetCore.Mvc;
using TP3_CRUD_TS.Models;
using TP3_CRUD_TS.Util;

namespace TP3_CRUD_TS.Controllers;

public class ProductoController : Controller
{
    public IActionResult Index()
    {
        return View(Utils.ListaProductos);
    }

    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Producto producto)
    {
        Utils.ListaProductos.Add(producto);
        int id = Utils.ListaProductos.Count;
        producto.IdProducto = id;
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var producto = Utils.ListaProductos.Find(producto => producto.IdProducto == id);
        if (producto != null) return View(producto);
        return RedirectToAction("Index"); 
    }

    public IActionResult Edit(int id)
    {
        var producto = Utils.ListaProductos.Find(producto => producto.IdProducto == id);
        if (producto!= null) return View(producto);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Edit(Producto producto)
    {
        var productoEncontrado = Utils.ListaProductos.Find(p => p.IdProducto == producto.IdProducto);
        if (productoEncontrado != null)
        {
            productoEncontrado.Nombre = producto.Nombre;
            productoEncontrado.Descripcion = producto.Descripcion;
            productoEncontrado.Cantidad = producto.Cantidad;
        }
        
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var producto = Utils.ListaProductos.Find(producto => producto.IdProducto == id);
        if (producto != null) Utils.ListaProductos.Remove(producto);

        return RedirectToAction("Index");
    }

}