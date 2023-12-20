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
            List<Cliente> clientes = new List<Cliente>();

            IRepository<Cliente> dataclientes = new DataCliente(_configuration);

            

            try
            {
                var result = await dataclientes.GetAll();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = result });
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = clientes });
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

        
        /*
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Cliente cliente)
        {
            DataCliente odatacliente = new DataCliente(_configuration);

            int OK;

            string response = "";

            try
            {
                OK = odatacliente.Guardar(cliente);

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
        public IActionResult Editar([FromBody] Cliente cliente)
        {
            DataCliente odatacliente = new DataCliente(_configuration);

            int OK;

            string response = "";

            try
            {
                OK = odatacliente.Editar(cliente);

                response = (OK == 0) ? "No se pudo editar" : "editado";

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
        public IActionResult Eliminar(Cliente cliente)
        {
            DataCliente odatacliente = new DataCliente(_configuration);

            IOperaciones operaciones = new DataCliente(_configuration);

            operaciones.Eliminar("");


            int OK;

            string response = "";

            try
            {
                OK = odatacliente.Eliminar(cliente.DNI);

                response = (OK == 0) ? "No se pudo eliminar" : "eliminado";

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

        */
    }
}
