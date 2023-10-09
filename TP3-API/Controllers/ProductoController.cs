using Microsoft.AspNetCore.Mvc;
using TP2_CRUD.Models;

namespace TP3_API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    [HttpGet(Name = "GetProductos")]
    public Producto GetAll()
    {
        return new Producto();
    }
}