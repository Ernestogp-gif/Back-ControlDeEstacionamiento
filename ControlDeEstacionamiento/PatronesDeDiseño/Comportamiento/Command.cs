/*

Command es un patrón de diseño de comportamiento que convierte una solicitud en un objeto independiente que contiene toda la información sobre la solicitud. Esta transformación te permite parametrizar los métodos con diferentes solicitudes, retrasar o poner en cola la ejecución de una solicitud y soportar operaciones que no se pueden realizar. 
 
*/


using System;
using System.Collections.Generic;

namespace ControlDeEstacionamiento.PatronesDeDiseño.Comportamiento.Command
{
    // Interfaz de comando: ICommand
    interface ICommand
    {
        void Ejecutar();
    }

    // Receptor: Motor
    class Motor
    {
        public void Encender()
        {
            Console.WriteLine("Motor encendido");
        }

        public void Apagar()
        {
            Console.WriteLine("Motor apagado");
        }
    }

    // Comandos concretos
    class ComandoEncender : ICommand
    {
        private readonly Motor motor;

        public ComandoEncender(Motor motor)
        {
            this.motor = motor;
        }

        public void Ejecutar()
        {
            motor.Encender();
        }
    }

    class ComandoApagar : ICommand
    {
        private readonly Motor motor;

        public ComandoApagar(Motor motor)
        {
            this.motor = motor;
        }

        public void Ejecutar()
        {
            motor.Apagar();
        }
    }

    // Invocador: ControlRemoto
    class ControlRemoto
    {
        private readonly List<ICommand> comandos = new List<ICommand>();

        public void AgregarComando(ICommand comando)
        {
            comandos.Add(comando);
        }

        public void EjecutarComandos()
        {
            foreach (var comando in comandos)
            {
                comando.Ejecutar();
            }

            comandos.Clear();
        }
    }

    // Cliente que utiliza el patrón Command
    class Program
    {
        static void Main()
        {
            // Crear instancias de receptor y comandos
            Motor motor = new Motor();
            ICommand comandoEncender = new ComandoEncender(motor);
            ICommand comandoApagar = new ComandoApagar(motor);

            // Crear instancia de invocador y asignar comandos
            ControlRemoto controlRemoto = new ControlRemoto();
            controlRemoto.AgregarComando(comandoEncender);
            controlRemoto.AgregarComando(comandoApagar);

            // Ejecutar los comandos
            controlRemoto.EjecutarComandos();
        }
    }

}
