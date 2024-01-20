using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ControlDeEstacionamiento.DataAcces;
using System.Data.SqlClient;
using System.Data;
using ControlDeEstacionamiento.Model;
using ControlDeEstacionamiento.Interfaces;

namespace ControlDeEstacionamiento.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ClienteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            IRepository<Cliente> dataclientes = new DataCliente(_configuration);

            var result = default(object);

            try
            {
                result = await dataclientes.GetAll();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = result });
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = result });
                throw;
            }
            finally
            {
                Console.WriteLine("Modulo Cliente: Se ejecuto el Controlador Listar()");
            }
        }
        
        
        [HttpPost]
        [Route("Obtener")]
        public async Task<IActionResult> Obtener(string DNI)
        {
            IRepository<Cliente> datacliente = new DataCliente(_configuration);

            var result = default(object);

            try
            {
                result = await datacliente.GetById(DNI);

                if (result == null) { Console.WriteLine("No se encontro cliente"); }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = result });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = result });
                throw;
            }
            finally
            {
                Console.WriteLine("Modulo Cliente: Se ejecuto el Controlador Obtener()");
            }
        }

        
        
        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Cliente cliente)
        {
            IRepository<Cliente> odatacliente = new DataCliente(_configuration);

            int OK = 0;

            string response = "";

            try
            {
                OK = await odatacliente.Create(cliente);  

                //Console.WriteLine($"OK {OK.}");

                response = (OK == 0) ? "No se pudo guardar" : "guardado";

                return StatusCode(StatusCodes.Status200OK, new { mensaje = response });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
            finally
            {
                Console.WriteLine("Modulo Cliente: Se ejecuto el Controlador Guardar()");
            }
        }
        
        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Cliente cliente)
        {
            DataCliente odatacliente = new DataCliente(_configuration);

            string response = "";

            try
            {
                cliente = await odatacliente.Update(cliente.DNI,cliente);

                response = (cliente == null) ? "No se pudo editar" : "editado";

                return StatusCode(StatusCodes.Status200OK, new { mensaje = response });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });

            }
            finally
            {
                Console.WriteLine("Modulo Cliente: Se ejecuto el Controlador Guardar()");
            }
        }
        
        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> Eliminar(Cliente cliente)
        {
            IRepository<Cliente> odatacliente = new DataCliente(_configuration);

            bool OK = false;

            string response = "";

            try
            {
                OK = await odatacliente.Delete(cliente.DNI);

                response = (OK == false) ? "No se pudo eliminar" : "eliminado";

                return StatusCode(StatusCodes.Status200OK, new { mensaje = response.ToString() });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });

            }
            finally
            {
                Console.WriteLine("Modulo Cliente: Se ejecuto el Controlador Guardar()");
            }
        }

        
    }
}
