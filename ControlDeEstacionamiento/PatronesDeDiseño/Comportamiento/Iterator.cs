/*
 
Iterator es un patrón de diseño de comportamiento que te permite recorrer elementos de una colección 
sin exponer su representación subyacente (lista, pila, árbol, etc.).

*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace ControlDeEstacionamiento.PatronesDeDiseño.Comportamiento.Iterador
{
    // Interfaz de iterador: IIteradorVehiculo
    interface IIteradorVehiculo
    {   
        Vehiculo Actual();
        bool Siguiente();
    }

    // Interfaz de agregado: IColeccionVehiculos
    interface IColeccionVehiculos
    {
        void AgregarVehiculo(Vehiculo vehiculo);
        IIteradorVehiculo ObtenerIterador();
    }
    // Clase concreta: Vehiculo
    class Vehiculo
    {
        public string Modelo { get; set; }

        public Vehiculo(string modelo)
        {
            Modelo = modelo;
        }
    }

    // Clase concreta que implementa IColeccionVehiculos: ListaVehiculos
    class ListaVehiculos : IColeccionVehiculos
    {
        private List<Vehiculo> vehiculos = new List<Vehiculo>();

        public void AgregarVehiculo(Vehiculo vehiculo)
        {
            vehiculos.Add(vehiculo);
        }

        public IIteradorVehiculo ObtenerIterador()
        {
            return new IteradorListaVehiculos(vehiculos);
        }
    }

    // Clase concreta que implementa IIteradorVehiculo: IteradorListaVehiculos
    class IteradorListaVehiculos : IIteradorVehiculo
    {
        private readonly List<Vehiculo> vehiculos;
        private int indiceActual = 0;

        public IteradorListaVehiculos(List<Vehiculo> vehiculos)
        {
            this.vehiculos = vehiculos;
        }

        public Vehiculo Actual()
        {
            return vehiculos[indiceActual];
        }

        public bool Siguiente()
        {
            indiceActual++;
            return indiceActual < vehiculos.Count;
        }
    }

    // Cliente que utiliza el patrón Iterator
    class ProgramIterador
    {
        static void Main()
        {
            // Crear una colección de vehículos
            IColeccionVehiculos coleccionVehiculos = new ListaVehiculos();
            coleccionVehiculos.AgregarVehiculo(new Vehiculo("Sedan"));
            coleccionVehiculos.AgregarVehiculo(new Vehiculo("SUV"));
            coleccionVehiculos.AgregarVehiculo(new Vehiculo("Camioneta"));

            // Obtener el iterador y recorrer la colección
            IIteradorVehiculo iterador = coleccionVehiculos.ObtenerIterador();

            while (iterador.Siguiente())
            {
                Vehiculo vehiculo = iterador.Actual();
                Console.WriteLine($"Modelo: {vehiculo.Modelo}");
            }
        }
    }
}
