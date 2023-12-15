using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ControlDeEstacionamiento.DataAcces;
using System.Data.SqlClient;
using System.Data;
using ControlDeEstacionamiento.Model;

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
        public IActionResult Listar()
        {
            List<Cliente> clientes = new List<Cliente>();

            DataCliente dataclientes = new DataCliente(_configuration);

            try
            {
                clientes = dataclientes.ListarClientes();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = clientes });
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
        public IActionResult Obtener(string DNI)
        {
            Cliente cliente = new Cliente();

            DataCliente datacliente = new DataCliente(_configuration);

            try
            {
                cliente = datacliente.Obtener(DNI);

                if (cliente == null) { Console.WriteLine("No se encontro cliente"); }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = cliente });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = cliente });
                throw;
            }
            finally
            {
                Console.WriteLine("Modulo Cliente: Se ejecuto el Controlador Obtener()");
            }
        }

        

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

        
    }
}
