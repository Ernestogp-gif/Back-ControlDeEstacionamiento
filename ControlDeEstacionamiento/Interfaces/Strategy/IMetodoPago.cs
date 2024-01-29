namespace ControlDeEstacionamiento.Interfaces.Strategy
{
    public interface IMetodoPago
    {
        void ProcesarPago(double monto);
    }
}
