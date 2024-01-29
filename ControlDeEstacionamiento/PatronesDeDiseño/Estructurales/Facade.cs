/*
 
Facade es un patrón de diseño estructural que proporciona una interfaz simplificada 
a una biblioteca, un framework o cualquier otro grupo complejo de clases. 
 
*/


using System;

namespace ControlDeEstacionamiento.PatronesDeDiseño.Estructurales.Facade
{

    // Subsistema 1: Motor
    class Motor
    {
        public void Arrancar()
        {
            Console.WriteLine("Motor arrancado");
        }

        public void Detener()
        {
            Console.WriteLine("Motor detenido");
        }
    }

    // Subsistema 2: Carrocería
    class Carroceria
    {
        public void InstalarCarroceria()
        {
            Console.WriteLine("Carrocería instalada");
        }
    }

    // Subsistema 3: Sistema de Entretenimiento
    class SistemaEntretenimiento
    {
        public void InstalarSistemaEntretenimiento()
        {
            Console.WriteLine("Sistema de entretenimiento instalado");
        }
    }

    // Subsistema 4: Luces
    class Luces
    {
        public void EncenderLuces()
        {
            Console.WriteLine("Luces encendidas");
        }

        public void ApagarLuces()
        {
            Console.WriteLine("Luces apagadas");
        }
    }

    // Fachada: VehiculoFacade
    class VehiculoFacade
    {
        private Motor motor;
        private Carroceria carroceria;
        private SistemaEntretenimiento sistemaEntretenimiento;
        private Luces luces;

        public VehiculoFacade()
        {
            this.motor = new Motor();
            this.carroceria = new Carroceria();
            this.sistemaEntretenimiento = new SistemaEntretenimiento();
            this.luces = new Luces();
        }

        public void ConstruirVehiculo()
        {
            Console.WriteLine("Construyendo vehículo...");

            // Pasos complejos simplificados a través de la fachada
            motor.Arrancar();
            carroceria.InstalarCarroceria();
            sistemaEntretenimiento.InstalarSistemaEntretenimiento();
            luces.EncenderLuces();

            Console.WriteLine("Vehículo construido con éxito.");
        }

        public void DetenerVehiculo()
        {
            Console.WriteLine("Deteniendo vehículo...");

            // Pasos para detener el vehículo
            motor.Detener();
            luces.ApagarLuces();

            Console.WriteLine("Vehículo detenido.");
        }
    }

    class Program
    {
        static void Main()
        {
            // Utilizar la fachada para construir y detener un vehículo
            VehiculoFacade vehiculoFacade = new VehiculoFacade();
            vehiculoFacade.ConstruirVehiculo();

            Console.WriteLine("\nRealizando otras operaciones...\n");

            vehiculoFacade.DetenerVehiculo();
        }
    }

}