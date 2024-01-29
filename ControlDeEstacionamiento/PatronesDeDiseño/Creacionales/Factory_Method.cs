/*
Factory Method es un patrón de diseño creacional que proporciona una interfaz 
para crear objetos en una superclase, mientras permite a las subclases alterar 
el tipo de objetos que se crearán. 
*/

using System;

namespace ControlDeEstacionamiento.PatronesDeDiseño.Creacional.FactoryMethod
{
    // Interfaz del Producto: IVehiculo
    interface IVehiculo
    {
        void Acelerar();
        void Frenar();
    }

    // Clase concreta del Producto: Automovil
    class Automovil : IVehiculo
    {
        public void Acelerar()
        {
            Console.WriteLine("Automóvil acelerando");
        }

        public void Frenar()
        {
            Console.WriteLine("Automóvil frenando");
        }
    }

    // Clase concreta del Producto: Motocicleta
    class Motocicleta : IVehiculo
    {
        public void Acelerar()
        {
            Console.WriteLine("Motocicleta acelerando");
        }

        public void Frenar()
        {
            Console.WriteLine("Motocicleta frenando");
        }
    }

    // Interfaz de la Fábrica: IFabricaVehiculos
    interface IFabricaVehiculos
    {
        IVehiculo CrearVehiculo();
    }

    // Fábrica concreta: FabricaAutomovil
    class FabricaAutomovil : IFabricaVehiculos
    {
        public IVehiculo CrearVehiculo()
        {
            return new Automovil();
        }
    }

    // Fábrica concreta: FabricaMotocicleta
    class FabricaMotocicleta : IFabricaVehiculos
    {
        public IVehiculo CrearVehiculo()
        {
            return new Motocicleta();
        }
    }

    // Cliente que utiliza el patrón Factory Method
    class Program
    {
        static void Main()
        {
            // Crear una fábrica de automóviles
            IFabricaVehiculos fabricaAutomovil = new FabricaAutomovil();

            // Utilizar la fábrica para crear un automóvil
            IVehiculo automovil = fabricaAutomovil.CrearVehiculo();

            // Realizar acciones con el automóvil
            automovil.Acelerar();
            automovil.Frenar();

            Console.WriteLine();

            // Crear una fábrica de motocicletas
            IFabricaVehiculos fabricaMotocicleta = new FabricaMotocicleta();

            // Utilizar la fábrica para crear una motocicleta
            IVehiculo motocicleta = fabricaMotocicleta.CrearVehiculo();

            // Realizar acciones con la motocicleta
            motocicleta.Acelerar();
            motocicleta.Frenar();
        }
    }

}