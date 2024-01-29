using ControlDeEstacionamiento.Interfaces.Strategy;

namespace ControlDeEstacionamiento.Implementacion.Strategy
{
    public class TransferenciaBancaria : IMetodoPago
    {
        public void ProcesarPago(double monto)
        {
            // Lógica para procesar pago con transferencia bancaria
            Console.WriteLine($"Procesando pago de {monto:C} con transferencia bancaria.");
        }
    }
}
