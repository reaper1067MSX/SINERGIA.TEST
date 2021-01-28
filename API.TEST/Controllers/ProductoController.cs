using AutoMapper;
using Common.TEST.SharedViewModels.Producto;
using MainData.TEST;
using MainData.TEST.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.TEST.Controllers
{
    [Produces("application/json")]
    [Route("api/Producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly SINERGIAContext _context;
        private readonly IMapper _mapper;

        public ProductoController(SINERGIAContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetFromStoreProcedureById(string id)
        {
            try
            {
                //var response = _context.Producto.FromSqlRaw("sp_sel_producto_by_Id @p0", id).Single();
                var response = _context.Proveedor.FromSqlInterpolated($"SELECT * FROM PRODUCTO WHERE ID={id}").Single();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertProducts([FromBody] ProductoVM model)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Modelo inválido");
                }

                model.Id = Guid.NewGuid().ToString();

                Producto producto = new Producto();
                producto = _mapper.Map(model, producto);

                _context.Producto.Add(producto);
                _context.SaveChanges();

                transaction.Commit();

                return Ok(producto);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return Conflict(ex.Message);
            }
        }


        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdateProducts(string id, [FromBody] ProductoVM model)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Modelo inválido");
                }

                var dbProducto = _context.Producto.FirstOrDefault(x => x.Id == Guid.Parse(id));

                if(dbProducto != null)
                {
                    dbProducto = _mapper.Map(model, dbProducto);

                    _context.Producto.Update(dbProducto);
                    _context.SaveChanges();

                    transaction.Commit();

                    return Ok(dbProducto);
                }

                return BadRequest("Producto no encontrado");
                
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return Conflict(ex.Message);
            }
        }


    }
}
