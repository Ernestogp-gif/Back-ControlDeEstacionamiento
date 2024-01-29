/*
State es un patrón de diseño de comportamiento que permite a un objeto alterar 
su comportamiento cuando su estado interno cambia. Parece como si el objeto 
cambiara su clase.
*/


using System;

namespace ControlDeEstacionamiento.PatronesDeDiseño.Comportamiento.State
{
    // Contexto: Vehiculo
    class Vehiculo
    {
        private EstadoVehiculo estado;

        public Vehiculo()
        {
            // Inicializar con un estado predeterminado
            estado = new EstadoDetenido();
        }

        public void CambiarEstado(EstadoVehiculo nuevoEstado)
        {
            estado = nuevoEstado;
            Console.WriteLine($"El vehículo ha cambiado a estado: {estado.GetType().Name}");
        }

        public void RealizarAccion()
        {
            estado.RealizarAccion(this);
        }
    }

    // Estado abstracto: EstadoVehiculo
    abstract class EstadoVehiculo
    {
        public abstract void RealizarAccion(Vehiculo vehiculo);
    }

    // Estados concretos
    class EstadoEnMarcha : EstadoVehiculo
    {
        public override void RealizarAccion(Vehiculo vehiculo)
        {
            Console.WriteLine("Realizando acción en estado: En marcha");
            // Lógica específica para el estado "En marcha"
        }
    }

    class EstadoDetenido : EstadoVehiculo
    {
        public override void RealizarAccion(Vehiculo vehiculo)
        {
            Console.WriteLine("Realizando acción en estado: Detenido");
            // Lógica específica para el estado "Detenido"
        }
    }

    class EstadoEnReparacion : EstadoVehiculo
    {
        public override void RealizarAccion(Vehiculo vehiculo)
        {
            Console.WriteLine("Realizando acción en estado: En reparación");
            // Lógica específica para el estado "En reparación"
        }
    }

    // Cliente que utiliza el patrón State
    class Program
    {
        static void Main()
        {
            // Crear un vehículo
            Vehiculo vehiculo = new Vehiculo();

            // Realizar acciones en diferentes estados
            vehiculo.RealizarAccion();

            // Cambiar a un nuevo estado y realizar acciones en el nuevo estado
            vehiculo.CambiarEstado(new EstadoEnMarcha());
            vehiculo.RealizarAccion();

            vehiculo.CambiarEstado(new EstadoEnReparacion());
            vehiculo.RealizarAccion();
        }
    }

}
