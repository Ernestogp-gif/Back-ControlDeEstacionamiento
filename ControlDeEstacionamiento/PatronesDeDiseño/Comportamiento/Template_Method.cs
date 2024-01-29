/*
 
Template Method es un patrón de diseño de comportamiento que define el esqueleto 
de un algoritmo en la superclase pero permite que las subclases sobrescriban pasos 
del algoritmo sin cambiar su estructura.

*/


using System;

namespace ControlDeEstacionamiento.PatronesDeDiseño.Comportamiento.Template_Method
{
    // Clase base abstracta: FabricaVehiculo
    abstract class FabricaVehiculo
    {
        // Template Method
        public void FabricarVehiculo()
        {
            EnsamblarChasis();
            AgregarMotor();
            InstalarRuedas();
            Pintar();
            Console.WriteLine("Vehículo fabricado con éxito.");
        }

        // Pasos comunes
        private void EnsamblarChasis()
        {
            Console.WriteLine("Ensamblaje del chasis");
        }

        private void Pintar()
        {
            Console.WriteLine("Pintura del vehículo");
        }

        // Pasos abstractos que deben ser implementados por las subclases
        protected abstract void AgregarMotor();
        protected abstract void InstalarRuedas();
    }

    // Subclases concretas
    class FabricaSedan : FabricaVehiculo
    {
        protected override void AgregarMotor()
        {
            Console.WriteLine("Agregando motor para Sedan");
        }

        protected override void InstalarRuedas()
        {
            Console.WriteLine("Instalando ruedas para Sedan");
        }
    }

    class FabricaCamioneta : FabricaVehiculo
    {
        protected override void AgregarMotor()
        {
            Console.WriteLine("Agregando motor para Camioneta");
        }

        protected override void InstalarRuedas()
        {
            Console.WriteLine("Instalando ruedas para Camioneta");
        }
    }

    // Cliente que utiliza el patrón Template Method
    class Program
    {
        static void Main()
        {
            // Fabricar un Sedan
            FabricaVehiculo fabricaSedan = new FabricaSedan();
            fabricaSedan.FabricarVehiculo();

            Console.WriteLine();

            // Fabricar una Camioneta
            FabricaVehiculo fabricaCamioneta = new FabricaCamioneta();
            fabricaCamioneta.FabricarVehiculo();
        }
    }

}
