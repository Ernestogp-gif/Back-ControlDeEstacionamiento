using ControlDeEstacionamiento.DataAcces;
using ControlDeEstacionamiento.Model;
using Microsoft.AspNetCore.Mvc;

namespace ControlDeEstacionamiento.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlazaController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PlazaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            List<PlazaCliente> oPlazaClientes = new List<PlazaCliente>();

            DataPlaza oDataPlaza = new DataPlaza(_configuration);

            try
            {
                oPlazaClientes = oDataPlaza.ListarPlazas();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oPlazaClientes });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = oPlazaClientes });
                throw;
            }
            finally
            {
                Console.WriteLine("Modulo Plaza: Se ejecuto el Controlador Listar()");
            }
        }        

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] PlazaCliente oPlazaCliente)
        {
            DataPlaza oDataPlaza = new DataPlaza(_configuration);

            int OK;

            string response = "";

            try
            {
                OK = oDataPlaza.Guardar(oPlazaCliente);

                response = (OK == 0) ? "No se pudo guardar" : "guardado";

                return StatusCode(StatusCodes.Status200OK, new { mensaje = response });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
            finally
            {
                Console.WriteLine("Modulo Plaza: Se ejecuto el Controlador Guardar()");
            }
        }


        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] PlazaCliente oPlazaCliente)
        {
            DataPlaza oDataPlaza = new DataPlaza(_configuration);

            int OK;

            string response = "";

            try
            {
                OK = oDataPlaza.Editar(oPlazaCliente);

                response = (OK == 0) ? "No se pudo editar" : "editado";

                return StatusCode(StatusCodes.Status200OK, new { mensaje = response });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });

            }
            finally
            {
                Console.WriteLine("Modulo Plaza: Se ejecuto el Controlador Editar()");
            }
        }

        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult Eliminar(PlazaCliente oPlazaCliente)
        {
            DataPlaza oDataPlaza = new DataPlaza(_configuration);

            int OK;

            string response = "";

            try
            {
                OK = oDataPlaza.Revocar(oPlazaCliente);

                response = (OK == 0) ? "No se pudo eliminar" : "revocado";

                return StatusCode(StatusCodes.Status200OK, new { mensaje = response });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });

            }
            finally
            {
                Console.WriteLine("Modulo Plaza: Se ejecuto el Controlador Eliminar()");
            }
        }
        
    }
}
