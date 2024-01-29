using ControlDeEstacionamiento.Interfaces.Strategy;

namespace ControlDeEstacionamiento.Business.ProcesarPagos
{
    public class ProcesadorPagos
    {
        private IMetodoPago metodoPago;

        public ProcesadorPagos(IMetodoPago metodoPago)
        {
            this.metodoPago = metodoPago;
        }

        public void RealizarPago(double monto)
        {
            // Utilizar la estrategia actual para procesar el pago
            metodoPago.ProcesarPago(monto);
        }

        public void CambiarMetodoPago(IMetodoPago nuevoMetodoPago)
        {
            // Cambiar la estrategia en tiempo de ejecución
            this.metodoPago = nuevoMetodoPago;
        }
    }
}
