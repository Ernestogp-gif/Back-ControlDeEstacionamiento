using ControlDeEstacionamiento.Business.Transporte;
using ControlDeEstacionamiento.Interfaces.FactoryMethod;

namespace ControlDeEstacionamiento.Implementacion.FactoryMethod
{
    public class CreadorBarco : ICreador
    {
        public Transporte FabricarTransporte()
        {
            return new Barco();
        }
    }
}
