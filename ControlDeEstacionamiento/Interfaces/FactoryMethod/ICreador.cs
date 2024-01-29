using ControlDeEstacionamiento.Business.Transporte;

namespace ControlDeEstacionamiento.Interfaces.FactoryMethod
{
    public interface ICreador
    {
        Transporte FabricarTransporte();
    }
}
