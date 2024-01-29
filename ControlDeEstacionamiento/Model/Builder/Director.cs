using ControlDeEstacionamiento.Interfaces.Builder.ISuperClienteConstructor;

namespace ControlDeEstacionamiento.Model.Builder
{
    public class Director
    {
        private ISuperClienteConstructor constructor;

        public Director(ISuperClienteConstructor constructor) 
        {
            this.constructor = constructor;
        }

        public void ConstruirCliente()
        {
            constructor.ConstructCliente();
        }
        public void ConstruirClientePlaza()
        {
            constructor.ConstructCliente();
            constructor.ConstructClientePlaza();
        }
        public void ConstruirClienteVehiculo()
        {
            constructor.ConstructCliente();
            constructor.ConstructClienteVehiculo();
        }
        public void ConstruirSuperClienteCompleto()
        {
            constructor.ConstructCliente();
            constructor.ConstructClientePlaza();
            constructor.ConstructClienteVehiculo();
        }

    }
}
