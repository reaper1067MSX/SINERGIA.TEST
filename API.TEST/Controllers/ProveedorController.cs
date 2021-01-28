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
    [Route("api/Proveedor")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly SINERGIAContext _context;
        private readonly IMapper _mapper;

        public ProveedorController(SINERGIAContext context, IMapper mapper)
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
                //var response = _context.Proveedor.FromSqlRaw<Proveedor>($"sp_sel_Proveedor_by_Id @i_idProveedor={id}").FirstOrDefault();
                var response = _context.Proveedor.FromSqlInterpolated($"SELECT * FROM PROVEEDOR WHERE ID={id}").Single();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertProveedor([FromBody] ProveedorVM model)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Modelo inválido");
                }

                model.Id = Guid.NewGuid().ToString();

                Proveedor proveedor = new Proveedor();
                proveedor = _mapper.Map(model, proveedor);

                _context.Proveedor.Add(proveedor);
                _context.SaveChanges();

                transaction.Commit();

                return Ok(proveedor);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return Conflict(ex.Message);
            }
        }


        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdateProveedor(string id, [FromBody] ProductoVM model)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Modelo inválido");
                }

                var dbProveedor = _context.Proveedor.FirstOrDefault(x => x.Id == Guid.Parse(id));

                if (dbProveedor != null)
                {
                    dbProveedor = _mapper.Map(model, dbProveedor);

                    _context.Proveedor.Update(dbProveedor);
                    _context.SaveChanges();

                    transaction.Commit();

                    return Ok(dbProveedor);
                }

                return BadRequest("Proveedor no encontrado");

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return Conflict(ex.Message);
            }
        }


    }
}
