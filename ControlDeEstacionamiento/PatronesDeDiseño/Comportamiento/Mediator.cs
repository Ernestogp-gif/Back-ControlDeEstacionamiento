/*
Mediator es un patrón de diseño de comportamiento que te permite reducir las 
dependencias caóticas entre objetos. El patrón restringe las comunicaciones 
directas entre los objetos, forzándolos a colaborar únicamente a través de un objeto mediador. 
*/

using System;

namespace ControlDeEstacionamiento.PatronesDeDiseño.Comportamiento.Mediator
{
    // Interfaz de Mediator: IMediator
    interface IMediator
    {
        void Enviar(string mensaje, Componente componente);
    }

    // Componente abstracto: Componente
    abstract class Componente
    {
        protected IMediator mediator;

        public Componente(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public abstract void EnviarMensaje(string mensaje);
        public abstract void RecibirMensaje(string mensaje);
    }

    // Implementación concreta de Mediator: MediatorVehiculo
    class MediatorVehiculo : IMediator
    {
        private Motor motor;
        private Frenos frenos;
        private Luces luces;

        public void EstablecerMotor(Motor motor)
        {
            this.motor = motor;
        }

        public void EstablecerFrenos(Frenos frenos)
        {
            this.frenos = frenos;
        }

        public void EstablecerLuces(Luces luces)
        {
            this.luces = luces;
        }

        public void Enviar(string mensaje, Componente componente)
        {
            if (componente is Motor)
            {
                frenos.RecibirMensaje(mensaje);
                luces.RecibirMensaje(mensaje);
            }
            else if (componente is Frenos)
            {
                motor.RecibirMensaje(mensaje);
            }
            else if (componente is Luces)
            {
                motor.RecibirMensaje(mensaje);
            }
        }
    }

    // Componente concreto: Motor
    class Motor : Componente
    {
        public Motor(IMediator mediator) : base(mediator)
        {
        }

        public override void EnviarMensaje(string mensaje)
        {
            Console.WriteLine($"Mensaje desde el motor: {mensaje}");
            mediator.Enviar(mensaje, this);
        }

        public override void RecibirMensaje(string mensaje)
        {
            Console.WriteLine($"Mensaje recibido en el motor: {mensaje}");
        }
    }

    // Componente concreto: Frenos
    class Frenos : Componente
    {
        public Frenos(IMediator mediator) : base(mediator)
        {
        }

        public override void EnviarMensaje(string mensaje)
        {
            Console.WriteLine($"Mensaje desde los frenos: {mensaje}");
            mediator.Enviar(mensaje, this);
        }

        public override void RecibirMensaje(string mensaje)
        {
            Console.WriteLine($"Mensaje recibido en los frenos: {mensaje}");
        }
    }

    // Componente concreto: Luces
    class Luces : Componente
    {
        public Luces(IMediator mediator) : base(mediator)
        {
        }

        public override void EnviarMensaje(string mensaje)
        {
            Console.WriteLine($"Mensaje desde las luces: {mensaje}");
            mediator.Enviar(mensaje, this);
        }

        public override void RecibirMensaje(string mensaje)
        {
            Console.WriteLine($"Mensaje recibido en las luces: {mensaje}");
        }
    }

    // Cliente que utiliza el patrón Mediator
    class Program
    {
        static void Main()
        {
            // Crear instancia de Mediator
            MediatorVehiculo mediator = new MediatorVehiculo();

            // Crear instancias de componentes y asignar el Mediator
            Motor motor = new Motor(mediator);
            Frenos frenos = new Frenos(mediator);
            Luces luces = new Luces(mediator);

            // Establecer los componentes en el Mediator
            mediator.EstablecerMotor(motor);
            mediator.EstablecerFrenos(frenos);
            mediator.EstablecerLuces(luces);

            // Enviar mensajes desde los componentes
            motor.EnviarMensaje("Encender motor");
            frenos.EnviarMensaje("Frenar");
            luces.EnviarMensaje("Encender luces");
        }
    }

}
