using ControlDeEstacionamiento.Interfaces.Strategy;

namespace ControlDeEstacionamiento.Implementacion.Strategy
{
    public class TarjetaCredito : IMetodoPago
    {
        public void ProcesarPago(double monto)
        {
            // Lógica para procesar pago con tarjeta de crédito
            Console.WriteLine($"Procesando pago de {monto:C} con tarjeta de crédito.");
        }   
    }
}
