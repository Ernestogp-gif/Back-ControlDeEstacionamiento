/*
Prototype es un patrón de diseño creacional que nos permite copiar objetos existentes 
sin que el código dependa de sus clases.
*/
using System;
using System.Collections.Generic;
namespace ControlDeEstacionamiento.PatronesDeDiseño.Creacional.Prototype
{
    // Interfaz del Prototipo: IClonableVehiculo
    interface IClonableVehiculo
    {
        string Tipo { get; set; }
        string Marca { get; set; }
        string Modelo { get; set; }
        int Potencia { get; set; }
        bool AireAcondicionado { get; set; }

        IClonableVehiculo Clonar();
    }

    // Clase concreta del Prototipo: Vehiculo
    class Vehiculo : IClonableVehiculo
    {
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Potencia { get; set; }
        public bool AireAcondicionado { get; set; }

        public IClonableVehiculo Clonar()
        {
            // Crear una copia superficial del vehículo
            return MemberwiseClone() as IClonableVehiculo;
        }
    }

    // Cliente que utiliza el patrón Prototype
    class Program
    {
        static void Main()
        {
            // Crear un prototipo de vehículo
            IClonableVehiculo prototipo = new Vehiculo
            {
                Tipo = "Automóvil",
                Marca = "Toyota",
                Modelo = "Corolla",
                Potencia = 150,
                AireAcondicionado = true
            };

            // Crear instancias nuevas copiando el prototipo
            IClonableVehiculo vehiculo1 = prototipo.Clonar();
            IClonableVehiculo vehiculo2 = prototipo.Clonar();

            // Modificar algunas propiedades de las instancias
            vehiculo1.Marca = "Honda";
            vehiculo2.Potencia = 200;

            // Mostrar detalles de los vehículos
            Console.WriteLine("Detalles del prototipo:");
            MostrarDetalles(prototipo);

            Console.WriteLine("\nDetalles del vehículo 1:");
            MostrarDetalles(vehiculo1);

            Console.WriteLine("\nDetalles del vehículo 2:");
            MostrarDetalles(vehiculo2);
        }

        static void MostrarDetalles(IClonableVehiculo vehiculo)
        {
            Console.WriteLine($"Tipo: {vehiculo.Tipo}");
            Console.WriteLine($"Marca: {vehiculo.Marca}");
            Console.WriteLine($"Modelo: {vehiculo.Modelo}");
            Console.WriteLine($"Potencia: {vehiculo.Potencia} HP");
            Console.WriteLine($"Aire Acondicionado: {(vehiculo.AireAcondicionado ? "Sí" : "No")}");
        }
    }

}

