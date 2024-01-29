
using System;


namespace ControlDeEstacionamiento.PatronesDeDiseño.Creacional.Singleton
{
    sealed class ConfiguracionVehiculo
    {
        private static ConfiguracionVehiculo instancia;
        private static readonly object bloqueo = new object();

        public string Color { get; set; }
        public int Potencia { get; set; }

        private ConfiguracionVehiculo()
        {
            Color = "Negro";
            Potencia = 150;
        }

        public static ConfiguracionVehiculo ObtenerInstancia()
        {
            // Utilizar el objeto de bloqueo para garantizar la exclusión mutua
            lock (bloqueo)
            {
                // Si la instancia aún no existe, crearla
                if (instancia == null)
                {
                    instancia = new ConfiguracionVehiculo();
                }

                // Devolver la instancia existente
                return instancia;
            }
        }
    }

    class ProgramSingleton
    {
        static void Main()
        {
            // Obtener la instancia única de ConfiguracionVehiculo
            ConfiguracionVehiculo configuracion = ConfiguracionVehiculo.ObtenerInstancia();

            // Acceder y modificar propiedades de configuración
            Console.WriteLine($"Color del vehículo: {configuracion.Color}");
            Console.WriteLine($"Potencia del vehículo: {configuracion.Potencia}");

            // Modificar la configuración
            configuracion.Color = "Rojo";
            configuracion.Potencia = 200;

            // Acceder nuevamente a las propiedades y verificar que se han modificado
            Console.WriteLine($"Nuevo color del vehículo: {configuracion.Color}");
            Console.WriteLine($"Nueva potencia del vehículo: {configuracion.Potencia}");
        }
    }

}
