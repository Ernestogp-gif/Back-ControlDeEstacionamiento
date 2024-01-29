/*
Flyweight es un patrón de diseño estructural que te permite mantener más objetos 
dentro de la cantidad disponible de RAM compartiendo las partes comunes del estado 
entre varios objetos en lugar de mantener toda la información en cada objeto.
*/

using System;
using System.Collections.Generic;

namespace ControlDeEstacionamiento.PatronesDeDiseño.Estructurales.Flyweight
{

    // Interfaz común para el Flyweight
    interface ICaracteristicaVehiculo
    {
        void MostrarInformacion(string modelo);
    }

    // Implementación concreta del Flyweight
    class Motor : ICaracteristicaVehiculo
    {
        private string tipo;

        public Motor(string tipo)
        {
            this.tipo = tipo;
        }

        public void MostrarInformacion(string modelo)
        {
            Console.WriteLine($"Motor: {tipo} en el modelo {modelo}");
        }
    }

    // Fábrica de Flyweights
    class FabricaCaracteristicas
    {
        private Dictionary<string, ICaracteristicaVehiculo> caracteristicas = new Dictionary<string, ICaracteristicaVehiculo>();

        public ICaracteristicaVehiculo ObtenerCaracteristica(string tipo)
        {
            if (!caracteristicas.ContainsKey(tipo))
            {
                caracteristicas[tipo] = new Motor(tipo);
            }

            return caracteristicas[tipo];
        }
    }

    // Cliente que utiliza los Flyweights
    class Vehiculo
    {
        public string Modelo { get; }
        private ICaracteristicaVehiculo motor;

        public Vehiculo(string modelo, FabricaCaracteristicas fabricaCaracteristicas)
        {
            Modelo = modelo;
            motor = fabricaCaracteristicas.ObtenerCaracteristica("V6");
        }

        public void MostrarCaracteristicas()
        {
            Console.WriteLine($"Modelo: {Modelo}");
            motor.MostrarInformacion(Modelo);
        }
    }

    class Program
    {
        static void Main()
        {
            FabricaCaracteristicas fabricaCaracteristicas = new FabricaCaracteristicas();

            Vehiculo vehiculo1 = new Vehiculo("Sedan", fabricaCaracteristicas);
            Vehiculo vehiculo2 = new Vehiculo("SUV", fabricaCaracteristicas);

            vehiculo1.MostrarCaracteristicas();
            Console.WriteLine();

            vehiculo2.MostrarCaracteristicas();
        }
    }

}