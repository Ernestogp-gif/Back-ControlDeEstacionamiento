using ControlDeEstacionamiento.DataAcces;
using ControlDeEstacionamiento.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ControlDeEstacionamiento.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public VehiculoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            List<VehiculoCliente> oVehiculoClientes = new List<VehiculoCliente>();

            DataVehiculo odataVehiculo = new DataVehiculo(_configuration);

            try
            {
                oVehiculoClientes = odataVehiculo.ListarVehiculos();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oVehiculoClientes });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = oVehiculoClientes });
                throw;
            }
            finally
            {
                Console.WriteLine("Modulo Vehiculo: Se ejecuto el Controlador Listar()");
            }
        }
        

        [HttpPost]
        [Route("Obtener")]
        public IActionResult Obtener(string Placa)
        {
            VehiculoCliente oVehiculoCliente = new VehiculoCliente();

            DataVehiculo odataVehiculo = new DataVehiculo(_configuration);

            try
            {
                oVehiculoCliente = odataVehiculo.Obtener(Placa);

                if (oVehiculoCliente == null) { Console.WriteLine("No se encontro cliente"); }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oVehiculoCliente });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = oVehiculoCliente });

            }
            finally
            {
                Console.WriteLine("Modulo Vehiculo: Se ejecuto el Controlador Obtener()");
            }
        }
        


        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] VehiculoCliente oVehiculoCliente)
        {
            DataVehiculo oDataVehiculo = new DataVehiculo(_configuration);

            int OK;

            string response = "";

            try
            {
                OK = oDataVehiculo.Guardar(oVehiculoCliente);

                response = (OK == 0) ? "No se pudo guardar" : "guardado";

                return StatusCode(StatusCodes.Status200OK, new { mensaje = response });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
            finally
            {
                Console.WriteLine("Modulo Vehiculo: Se ejecuto el Controlador Guardar()");
            }
        }

        
        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] VehiculoCliente oVehiculoCliente)
        {
            DataVehiculo oDataVehiculo = new DataVehiculo(_configuration);

            int OK;

            string response = "";

            try
            {
                OK = oDataVehiculo.Editar(oVehiculoCliente);

                response = (OK == 0) ? "No se pudo editar" : "editado";

                return StatusCode(StatusCodes.Status200OK, new { mensaje = response });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });

            }
            finally
            {
                Console.WriteLine("Modulo Vehiculo: Se ejecuto el Controlador Editar()");
            }
        }
        
        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult Eliminar(VehiculoCliente oVehiculoCliente)
        {
            DataVehiculo oDataVehiculo = new DataVehiculo(_configuration);

            int OK;

            string response = "";

            try
            {
                OK = oDataVehiculo.Eliminar(oVehiculoCliente);

                response = (OK == 0) ? "No se pudo eliminar" : "eliminado";

                return StatusCode(StatusCodes.Status200OK, new { mensaje = response });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });

            }
            finally
            {
                Console.WriteLine("Modulo Vehiculo: Se ejecuto el Controlador Eliminar()");
            }
        }
        
    }
}
