/*
 Abstract Factory es un patrón de diseño creacional que nos permite 
producir familias de objetos relacionados sin especificar sus clases concretas.
*/

using System;

namespace ControlDeEstacionamiento.PatronesDeDiseño.Creacional.AbstractFactory
{
    // Interfaz de la familia de productos A: IMotor
    interface IMotor
    {
        void Arrancar();
    }

    // Clase concreta de la familia de productos A: MotorAutomovil
    class MotorAutomovil : IMotor
    {
        public void Arrancar()
        {
            Console.WriteLine("Motor de automóvil arrancando");
        }
    }

    // Clase concreta de la familia de productos A: MotorMotocicleta
    class MotorMotocicleta : IMotor
    {
        public void Arrancar()
        {
            Console.WriteLine("Motor de motocicleta arrancando");
        }
    }

    // Interfaz de la familia de productos B: IRuedas
    interface IRuedas
    {
        void Girar();
    }

    // Clase concreta de la familia de productos B: RuedasAutomovil
    class RuedasAutomovil : IRuedas
    {
        public void Girar()
        {
            Console.WriteLine("Ruedas de automóvil girando");
        }
    }

    // Clase concreta de la familia de productos B: RuedasMotocicleta
    class RuedasMotocicleta : IRuedas
    {
        public void Girar()
        {
            Console.WriteLine("Ruedas de motocicleta girando");
        }
    }

    // Interfaz de la Abstract Factory: IFabricaVehiculos
    interface IFabricaVehiculos
    {
        IMotor CrearMotor();
        IRuedas CrearRuedas();
    }

    // Fábrica concreta para automóviles: FabricaAutomovil
    class FabricaAutomovil : IFabricaVehiculos
    {
        public IMotor CrearMotor()
        {
            return new MotorAutomovil();
        }

        public IRuedas CrearRuedas()
        {
            return new RuedasAutomovil();
        }
    }

    // Fábrica concreta para motocicletas: FabricaMotocicleta
    class FabricaMotocicleta : IFabricaVehiculos
    {
        public IMotor CrearMotor()
        {
            return new MotorMotocicleta();
        }

        public IRuedas CrearRuedas()
        {
            return new RuedasMotocicleta();
        }
    }

    // Cliente que utiliza el patrón Abstract Factory
    class Program
    {
        static void Main()
        {
            // Crear una fábrica de automóviles
            IFabricaVehiculos fabricaAutomovil = new FabricaAutomovil();

            // Crear productos de la familia de automóviles
            IMotor motorAutomovil = fabricaAutomovil.CrearMotor();
            IRuedas ruedasAutomovil = fabricaAutomovil.CrearRuedas();

            // Utilizar productos de la familia de automóviles
            motorAutomovil.Arrancar();
            ruedasAutomovil.Girar();

            Console.WriteLine();

            // Crear una fábrica de motocicletas
            IFabricaVehiculos fabricaMotocicleta = new FabricaMotocicleta();

            // Crear productos de la familia de motocicletas
            IMotor motorMotocicleta = fabricaMotocicleta.CrearMotor();
            IRuedas ruedasMotocicleta = fabricaMotocicleta.CrearRuedas();

            // Utilizar productos de la familia de motocicletas
            motorMotocicleta.Arrancar();
            ruedasMotocicleta.Girar();
        }
    }

}