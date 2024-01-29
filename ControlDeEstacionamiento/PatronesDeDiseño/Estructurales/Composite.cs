/*
Composite es un patrón de diseño estructural que te permite componer objetos en estructuras de árbol 
y trabajar con esas estructuras como si fueran objetos individuales. 
*/

using System;
using System.Collections.Generic;

namespace ControlDeEstacionamiento.PatronesDeDiseño.Estructurales.Composite
{
    // Componente base: ComponenteVehiculo
    interface IComponenteVehiculo
    {
        void MostrarInformacion();
    }

    // Hoja: Motor
    class Motor : IComponenteVehiculo
    {
        private string tipo;

        public Motor(string tipo)
        {
            this.tipo = tipo;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Motor: {tipo}");
        }
    }

    // Hoja: Rueda
    class Rueda : IComponenteVehiculo
    {
        private string tipo;

        public Rueda(string tipo)
        {
            this.tipo = tipo;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Rueda: {tipo}");
        }
    }

    // Hoja: Carroceria
    class Carroceria : IComponenteVehiculo
    {
        private string tipo;

        public Carroceria(string tipo)
        {
            this.tipo = tipo;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Carrocería: {tipo}");
        }
    }

    // Composite: VehiculoCompuesto
    class VehiculoCompuesto : IComponenteVehiculo
    {
        private List<IComponenteVehiculo> componentes = new List<IComponenteVehiculo>();

        public void AgregarComponente(IComponenteVehiculo componente)
        {
            componentes.Add(componente);
        }

        public void MostrarInformacion()
        {
            foreach (var componente in componentes)
            {
                componente.MostrarInformacion();
            }
        }
    }

    // Cliente que utiliza el Composite
    class Program
    {
        static void Main()
        {
            // Crear componentes individuales
            IComponenteVehiculo motor = new Motor("V8");
            IComponenteVehiculo ruedaDelantera = new Rueda("Delantera");
            IComponenteVehiculo ruedaTrasera = new Rueda("Trasera");
            IComponenteVehiculo carroceria = new Carroceria("Sedan");

            // Crear un vehículo compuesto y agregar componentes
            VehiculoCompuesto vehiculo = new VehiculoCompuesto();
            vehiculo.AgregarComponente(motor);
            vehiculo.AgregarComponente(ruedaDelantera);
            vehiculo.AgregarComponente(ruedaTrasera);
            vehiculo.AgregarComponente(carroceria);

            // Mostrar información del vehículo (incluye componentes individuales y compuestos)
            vehiculo.MostrarInformacion();
        }
    }

}
