using ControlDeEstacionamiento.Business.Transporte;
using ControlDeEstacionamiento.Interfaces.FactoryMethod;

namespace ControlDeEstacionamiento.Implementacion.FactoryMethod
{
    public class CreadorCamion : ICreador
    {
        public Transporte FabricarTransporte()
        {
            return new Camion();
        }
    }
}
