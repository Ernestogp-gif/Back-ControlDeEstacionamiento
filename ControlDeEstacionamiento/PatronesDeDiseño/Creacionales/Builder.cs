/*
Builder es un patrón de diseño creacional que nos permite construir objetos complejos paso a paso. 
El patrón nos permite producir distintos tipos y representaciones de un objeto empleando el mismo 
código de construcción. 
*/


using System;


namespace ControlDeEstacionamiento.PatronesDeDiseño.Creacional.Builder
{
    // Producto: Vehiculo
    class Vehiculo
    {
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Potencia { get; set; }
        public bool AireAcondicionado { get; set; }

        public void MostrarDetalles()
        {
            Console.WriteLine($"Tipo: {Tipo}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Potencia: {Potencia} HP");
            Console.WriteLine($"Aire Acondicionado: {(AireAcondicionado ? "Sí" : "No")}");
        }
    }

    // Interfaz del Builder: IConstructorVehiculo
    interface IConstructorVehiculo
    {
        void ConstruirTipo();
        void ConstruirMarca();
        void ConstruirModelo();
        void ConstruirPotencia();
        void ConstruirAireAcondicionado();
        Vehiculo ObtenerVehiculo();
    }

    // Builder concreto: ConstructorAutomovil
    class ConstructorAutomovil : IConstructorVehiculo
    {
        private Vehiculo automovil = new Vehiculo();

        public void ConstruirTipo()
        {
            automovil.Tipo = "Automóvil";
        }

        public void ConstruirMarca()
        {
            automovil.Marca = "Toyota";
        }

        public void ConstruirModelo()
        {
            automovil.Modelo = "Corolla";
        }

        public void ConstruirPotencia()
        {
            automovil.Potencia = 150;
        }

        public void ConstruirAireAcondicionado()
        {
            automovil.AireAcondicionado = true;
        }

        public Vehiculo ObtenerVehiculo()
        {
            return automovil;
        }
    }

    // Director que utiliza el Builder
    class Director
    {
        public void ConstruirVehiculo(IConstructorVehiculo constructor)
        {
            constructor.ConstruirTipo();
            constructor.ConstruirMarca();
            constructor.ConstruirModelo();
            constructor.ConstruirPotencia();
            constructor.ConstruirAireAcondicionado();
        }
    }

    // Cliente que utiliza el patrón Builder
    class Program
    {
        static void Main()
        {
            // Crear un constructor para automóviles
            IConstructorVehiculo constructorAutomovil = new ConstructorAutomovil();

            // Crear un director y construir un automóvil
            Director director = new Director();
            director.ConstruirVehiculo(constructorAutomovil);

            // Obtener el automóvil construido
            Vehiculo automovil = constructorAutomovil.ObtenerVehiculo();

            // Mostrar los detalles del automóvil
            automovil.MostrarDetalles();
        }
    }

}