using ControlDeEstacionamiento.Interfaces.Builder.ISuperClienteConstructor;
using ControlDeEstacionamiento.Model.Builder;

namespace ControlDeEstacionamiento.Implementacion.Builder
{
    public class SuperClienteConstructor : ISuperClienteConstructor
    {
        private SuperCliente superCliente = new SuperCliente();
        public void ConstructCliente()
        {
            superCliente.Nombre = "";
            superCliente.Apellido = "0";
            superCliente.DNI = "0";
            superCliente.Telefono = "0";

        }

        public void ConstructClientePlaza()
        {
            superCliente.CodPlaza = "0";
            superCliente.estado = "0";

        }

        public void ConstructClienteVehiculo()
        {
            superCliente.Placa = "0";
            superCliente.Modelo = "0";
            superCliente.Color = "";
            superCliente.Marca = "0";

            throw new NotImplementedException();
        }

        public SuperCliente ObtenerSuperCliente()
        {
            return this.superCliente;
        }
    }
}
