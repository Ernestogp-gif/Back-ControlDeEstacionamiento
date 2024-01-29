using Microsoft.AspNetCore.Mvc;
using ControlDeEstacionamiento.DataAcces;
using ControlDeEstacionamiento.Model;
using ControlDeEstacionamiento.Interfaces;
using ControlDeEstacionamiento.Model.Builder;


using ControlDeEstacionamiento.Interfaces.Builder.ISuperClienteConstructor;
using ControlDeEstacionamiento.Implementacion.Builder;
using ControlDeEstacionamiento.Interfaces.FactoryMethod;
using ControlDeEstacionamiento.Business.Transporte;
using ControlDeEstacionamiento.Implementacion.FactoryMethod;
using ControlDeEstacionamiento.Implementacion.Prototype;
using ControlDeEstacionamiento.Business.ProcesarPagos;
using ControlDeEstacionamiento.Implementacion.Strategy;
using ControlDeEstacionamiento.Interfaces.Strategy;



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




        public void UsoDePatron() 
        {
            // ***********************   Builder   *****************************************
            // Crear un constructor concreto
            ISuperClienteConstructor constructor = new SuperClienteConstructor();
            constructor.ConstructClientePlaza();
            constructor.ConstructCliente();
            constructor.ConstructClienteVehiculo();
            // Crear un director
            Director director = new Director(constructor);

            // Construir el producto paso a paso
            director.ConstruirSuperClienteCompleto();

            // Obtener el resultado final
            SuperCliente superCliente = constructor.ObtenerSuperCliente();

            // Mostrar el producto final
            Console.WriteLine(superCliente);

            //**********************************   Factory Method   ********************************

            // Crear creadores concretos
            ICreador creadorA = new CreadorCamion();
            ICreador creadorB = new CreadorBarco();

            // Utilizar los creadores para fabricar productos
            Transporte productoA = creadorA.FabricarTransporte();
            Transporte productoB = creadorB.FabricarTransporte();

            // Mostrar los productos creados
            //productoA.Mostrar();
            //productoB.Mostrar();


            //********************************   Prototype   ***********************************

            // Crear un prototipo
            UsuarioConcreto prototipo = new UsuarioConcreto(1, "PrototipoOriginal");

            // Clonar el prototipo para obtener nuevas instancias
            UsuarioConcreto copia1 = (UsuarioConcreto)prototipo.ClonePrototype();
            copia1.Id = 2;

            UsuarioConcreto copia2 = (UsuarioConcreto)prototipo.ClonePrototype();
            copia2.Nombre = "PrototipoModificado";

            // Mostrar los resultados
            Console.WriteLine("Prototipo Original: Id={0}, Nombre={1}", prototipo.Id, prototipo.Nombre);
            Console.WriteLine("Copia 1: Id={0}, Nombre={1}", copia1.Id, copia1.Nombre);
            Console.WriteLine("Copia 2: Id={0}, Nombre={1}", copia2.Id, copia2.Nombre);

            Console.ReadLine();

            //**************************   Strategy   ***********************************

            // Crear instancias de estrategias concretas
            IMetodoPago tarjetaCredito = new TarjetaCredito();
            IMetodoPago payPal = new PayPal();
            IMetodoPago transferenciaBancaria = new TransferenciaBancaria();

            // Crear un procesador de pagos con una estrategia inicial
            ProcesadorPagos procesador = new ProcesadorPagos(tarjetaCredito);

            // Realizar un pago utilizando la estrategia actual
            procesador.RealizarPago(100.0);

            // Cambiar la estrategia en tiempo de ejecución
            procesador.CambiarMetodoPago(payPal);

            // Realizar otro pago con la nueva estrategia
            procesador.RealizarPago(50.0);

            Console.ReadLine();




        }
        
    }
}
