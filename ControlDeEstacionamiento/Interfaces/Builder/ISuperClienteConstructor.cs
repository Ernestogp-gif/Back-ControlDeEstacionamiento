using ControlDeEstacionamiento.Model.Builder;

namespace ControlDeEstacionamiento.Interfaces.Builder.ISuperClienteConstructor
{
    public interface ISuperClienteConstructor
    {
        void ConstructCliente();
        void ConstructClientePlaza();
        void ConstructClienteVehiculo();
        SuperCliente ObtenerSuperCliente();

    }
}
