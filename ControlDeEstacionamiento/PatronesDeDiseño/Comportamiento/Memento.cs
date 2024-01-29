/*
Memento es un patrón de diseño de comportamiento que te permite guardar y 
restaurar el estado previo de un objeto sin revelar los detalles de su implementación. 
*/

using System;


namespace ControlDeEstacionamiento.PatronesDeDiseño.Comportamiento.Memento
{
    // Memento: EstadoMemento
    class EstadoMemento
    {
        public string Estado { get; }

        public EstadoMemento(string estado)
        {
            Estado = estado;
        }
    }

    // Originador: Vehiculo
    class Vehiculo
    {
        private string estado;

        public void EstablecerEstado(string estado)
        {
            Console.WriteLine($"Estableciendo estado a: {estado}");
            this.estado = estado;
        }

        public EstadoMemento GuardarEstado()
        {
            Console.WriteLine("Guardando estado...");
            return new EstadoMemento(estado);
        }

        public void RestaurarEstado(EstadoMemento estadoMemento)
        {
            Console.WriteLine($"Restaurando estado a: {estadoMemento.Estado}");
            estado = estadoMemento.Estado;
        }

        public void MostrarEstado()
        {
            Console.WriteLine($"Estado actual: {estado}");
        }
    }

    // Caretaker: GestorMementos
    class GestorMementos
    {
        public EstadoMemento Memento { get; set; }
    }

    // Cliente que utiliza el patrón Memento
    class Program
    {
        static void Main()
        {
            // Crear un vehículo
            Vehiculo vehiculo = new Vehiculo();
            vehiculo.MostrarEstado();

            // Establecer un estado y guardar el memento
            vehiculo.EstablecerEstado("En marcha");
            vehiculo.MostrarEstado();
            GestorMementos gestor = new GestorMementos();
            gestor.Memento = vehiculo.GuardarEstado();

            // Cambiar el estado del vehículo
            vehiculo.EstablecerEstado("Detenido");
            vehiculo.MostrarEstado();

            // Restaurar el estado desde el memento
            vehiculo.RestaurarEstado(gestor.Memento);
            vehiculo.MostrarEstado();
        }
    }

}
