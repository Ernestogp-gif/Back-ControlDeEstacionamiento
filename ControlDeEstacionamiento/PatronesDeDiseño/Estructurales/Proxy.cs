/*

Proxy es un patrón de diseño estructural que te permite proporcionar un sustituto o marcador 
de posición para otro objeto. Un proxy controla el acceso al objeto original, permitiéndote 
hacer algo antes o después de que la solicitud llegue al objeto original.
  
*/

using System;

namespace ControlDeEstacionamiento.PatronesDeDiseño.Estructurales.Proxy
{

    // Interfaz común para los vehículos
    interface IVehiculo
    {
        void Arrancar();
        void Detener();
    }

    // Implementación concreta de la interfaz
    class VehiculoReal : IVehiculo
    {
        public void Arrancar()
        {
            Console.WriteLine("Vehículo arrancado");
        }

        public void Detener()
        {
            Console.WriteLine("Vehículo detenido");
        }
    }

    // Proxy para controlar el acceso al vehículo real
    class VehiculoProxy : IVehiculo
    {
        private VehiculoReal vehiculoReal;

        public void Arrancar()
        {
            if (vehiculoReal == null)
            {
                vehiculoReal = new VehiculoReal();
                Console.WriteLine("Creando instancia del vehículo real.");
            }

            Console.WriteLine("Acceso autorizado. Iniciando procedimiento remoto.");
            vehiculoReal.Arrancar();
        }

        public void Detener()
        {
            if (vehiculoReal == null)
            {
                vehiculoReal = new VehiculoReal();
                Console.WriteLine("Creando instancia del vehículo real.");
            }

            Console.WriteLine("Acceso autorizado. Iniciando procedimiento remoto.");
            vehiculoReal.Detener();
        }
    }

    class Program
    {
        static void Main()
        {
            // Utilizar el proxy para arrancar y detener el vehículo
            IVehiculo vehiculo = new VehiculoProxy();

            Console.WriteLine("Intento de arranque:");
            vehiculo.Arrancar();

            Console.WriteLine("\nIntento de detener:");
            vehiculo.Detener();
        }
    }

}