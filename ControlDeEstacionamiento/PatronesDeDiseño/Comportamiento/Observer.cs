/*
Observer es un patrón de diseño de comportamiento que te permite definir un mecanismo 
de suscripción para notificar a varios objetos sobre cualquier evento que le suceda al 
objeto que están observando. 
*/

using System;
using System.Collections.Generic;

namespace ControlDeEstacionamiento.PatronesDeDiseño.Comportamiento.Observer
{
    // Sujeto: Vehiculo
    class Vehiculo
    {
        private string estado;

        private List<IObserver> observadores = new List<IObserver>();

        public string Estado
        {
            get { return estado; }
            set
            {
                estado = value;
                NotificarObservadores();
            }
        }

        public void AgregarObservador(IObserver observador)
        {
            observadores.Add(observador);
        }

        public void EliminarObservador(IObserver observador)
        {
            observadores.Remove(observador);
        }

        private void NotificarObservadores()
        {
            foreach (var observador in observadores)
            {
                observador.Actualizar(this);
            }
        }
    }

    // Observador: IObserver
    interface IObserver
    {
        void Actualizar(Vehiculo vehiculo);
    }

    // Observadores concretos: Motor, Frenos, Luces
    class Motor : IObserver
    {
        public void Actualizar(Vehiculo vehiculo)
        {
            Console.WriteLine($"Motor: El vehículo ha cambiado a {vehiculo.Estado}");
        }
    }

    class Frenos : IObserver
    {
        public void Actualizar(Vehiculo vehiculo)
        {
            Console.WriteLine($"Frenos: El vehículo ha cambiado a {vehiculo.Estado}");
        }
    }

    class Luces : IObserver
    {
        public void Actualizar(Vehiculo vehiculo)
        {
            Console.WriteLine($"Luces: El vehículo ha cambiado a {vehiculo.Estado}");
        }
    }

    // Cliente que utiliza el patrón Observer
    class Program
    {
        static void Main()
        {
            // Crear un vehículo
            Vehiculo vehiculo = new Vehiculo();

            // Crear observadores y registrarlos en el vehículo
            IObserver motor = new Motor();
            IObserver frenos = new Frenos();
            IObserver luces = new Luces();

            vehiculo.AgregarObservador(motor);
            vehiculo.AgregarObservador(frenos);
            vehiculo.AgregarObservador(luces);

            // Cambiar el estado del vehículo y notificar a los observadores
            vehiculo.Estado = "En marcha";
            Console.WriteLine();

            vehiculo.Estado = "Detenido";
        }
    }

}