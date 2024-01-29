using ControlDeEstacionamiento.Interfaces.Strategy;

namespace ControlDeEstacionamiento.Implementacion.Strategy
{
    public class PayPal : IMetodoPago
    {
        public void ProcesarPago(double monto)
        {
            // Lógica para procesar pago con PayPal
            Console.WriteLine($"Procesando pago de {monto:C} con PayPal.");
        }
    }
}
