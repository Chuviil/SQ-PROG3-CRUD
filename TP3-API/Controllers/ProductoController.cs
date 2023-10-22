using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP3_API.Data;
using TP3_API.Models;

namespace TP3_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductoController : ControllerBase
{
    private readonly ApplicationDBContext _db;

    public ProductoController(ApplicationDBContext db)
    {
        _db = db;
    }

    // GET: api/Producto
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _db.Productos.ToListAsync();
        return Ok(products);
    }

    // GET: api/Producto/5
    [HttpGet("{IdProducto}", Name = "Get")]
    public async Task<IActionResult> Get(int IdProducto)
    {
        var producto = await _db.Productos.FirstOrDefaultAsync(p => p.IdProducto == IdProducto);
        if (producto == null)
            return NotFound();

        return Ok(producto);
    }

    // POST: api/Producto
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Producto? producto)
    {
        var productoEncontrado = await _db.Productos.FirstOrDefaultAsync(p => p.IdProducto == producto.IdProducto);
        if (producto == null || productoEncontrado != null) return BadRequest();
        await _db.Productos.AddAsync(producto);
        await _db.SaveChangesAsync();
        return Ok(producto);
    }

    // PUT: api/Producto/5
    [HttpPut("{IdProducto}")]
    public async Task<ActionResult> Put(int IdProducto, [FromBody] Producto producto)
    {
        var productoEncontrado = await _db.Productos.FirstOrDefaultAsync(p => p.IdProducto == IdProducto);
        if (productoEncontrado is null) return NotFound();

        productoEncontrado.Nombre = producto.Nombre ?? productoEncontrado.Nombre;
        productoEncontrado.Descripcion = producto.Descripcion ?? productoEncontrado.Nombre;
        productoEncontrado.Cantidad = producto.Cantidad;
        _db.Productos.Update(productoEncontrado);
        await _db.SaveChangesAsync();
        return Ok();
    }

    // DELETE: api/Producto/5
    [HttpDelete("{IdProducto}")]
    public async Task<IActionResult> Delete(int IdProducto)
    {
        var producto = await _db.Productos.FirstOrDefaultAsync(p => p.IdProducto == IdProducto);
        if (producto is null) return NotFound();
        _db.Productos.Remove(producto);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}