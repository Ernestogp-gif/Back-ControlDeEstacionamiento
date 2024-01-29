/*
Strategy es un patrón de diseño de comportamiento que te permite definir una familia 
de algoritmos, colocar cada uno de ellos en una clase separada y hacer sus objetos 
intercambiables 
*/

using System;

namespace ControlDeEstacionamiento.PatronesDeDiseño.Comportamiento.Strategy
{
    // Interfaz de la estrategia: IEstrategiaConduccion
    interface IEstrategiaConduccion
    {
        void Conducir();
    }

    // Estrategias concretas
    class EstrategiaNormal : IEstrategiaConduccion
    {
        public void Conducir()
        {
            Console.WriteLine("Conduciendo de manera normal.");
        }
    }

    class EstrategiaDeportiva : IEstrategiaConduccion
    {
        public void Conducir()
        {
            Console.WriteLine("Conduciendo de manera deportiva.");
        }
    }

    class EstrategiaEconomica : IEstrategiaConduccion
    {
        public void Conducir()
        {
            Console.WriteLine("Conduciendo de manera económica.");
        }
    }

    // Contexto: Vehiculo
    class Vehiculo
    {
        private IEstrategiaConduccion estrategia;

        public Vehiculo(IEstrategiaConduccion estrategia)
        {
            this.estrategia = estrategia;
        }

        public void CambiarEstrategia(IEstrategiaConduccion nuevaEstrategia)
        {
            this.estrategia = nuevaEstrategia;
        }

        public void Conducir()
        {
            estrategia.Conducir();
        }
    }

    // Cliente que utiliza el patrón Strategy
    class Program
    {
        static void Main()
        {
            // Crear un vehículo con una estrategia normal
            Vehiculo vehiculo = new Vehiculo(new EstrategiaNormal());

            // Conducir con la estrategia normal
            vehiculo.Conducir();

            // Cambiar a una estrategia deportiva y conducir
            vehiculo.CambiarEstrategia(new EstrategiaDeportiva());
            vehiculo.Conducir();

            // Cambiar a una estrategia económica y conducir
            vehiculo.CambiarEstrategia(new EstrategiaEconomica());
            vehiculo.Conducir();
        }
    }

}
