/*
Adapter es un patrón de diseño estructural que permite la colaboración entre objetos con interfaces incompatibles.
*/

using System;

namespace ControlDeEstacionamiento.PatronesDeDiseño.Estructurales.Adapter
{

    // Interfaz existente: MotorExistente
    interface IMotorExistente
    {
        void Encender();
        void Apagar();
    }

    // Clase existente: MotorExistenteConcreto
    class MotorExistenteConcreto : IMotorExistente
    {
        public void Encender()
        {
            Console.WriteLine("Motor existente encendido");
        }

        public void Apagar()
        {
            Console.WriteLine("Motor existente apagado");
        }
    }

    // Nueva interfaz requerida: IMotorNuevo
    interface IMotorNuevo
    {
        void Arrancar();
        void Detener();
    }

    // Adaptador: AdaptadorMotorExistente
    class AdaptadorMotorExistente : IMotorNuevo
    {
        private readonly IMotorExistente motorExistente;

        public AdaptadorMotorExistente(IMotorExistente motorExistente)
        {
            this.motorExistente = motorExistente;
        }

        public void Arrancar()
        {
            motorExistente.Encender();
        }

        public void Detener()
        {
            motorExistente.Apagar();
        }
    }

    // Cliente que utiliza la nueva interfaz IMotorNuevo
    class Vehiculo
    {
        private readonly IMotorNuevo motor;

        public Vehiculo(IMotorNuevo motor)
        {
            this.motor = motor;
        }

        public void Iniciar()
        {
            Console.WriteLine("Vehículo arrancando...");
            motor.Arrancar();
        }

        public void Detener()
        {
            Console.WriteLine("Vehículo deteniendo...");
            motor.Detener();
        }
    }

    class Program
    {
        static void Main()
        {
            // Utilizar el adaptador para integrar un motor existente en un vehículo nuevo
            IMotorExistente motorExistente = new MotorExistenteConcreto();
            IMotorNuevo adaptadorMotorExistente = new AdaptadorMotorExistente(motorExistente);

            // Crear un vehículo con el motor adaptado
            Vehiculo vehiculo = new Vehiculo(adaptadorMotorExistente);

            // Utilizar el vehículo
            vehiculo.Iniciar();
            vehiculo.Detener();
        }
    }

}