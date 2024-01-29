/*
Visitor es un patrón de diseño de comportamiento que te permite separar algoritmos de los objetos sobre los que operan.
*/


using System;
using System.Collections.Generic;

namespace ControlDeEstacionamiento.PatronesDeDiseño.Comportamiento.Visitor
{
    // Elemento abstracto: ParteVehiculo
    abstract class ParteVehiculo
    {
        public abstract void Accept(IVisitor visitor);
    }

    // Elementos concretos: Motor, Rueda, Luces
    class Motor : ParteVehiculo
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitMotor(this);
        }
    }

    class Rueda : ParteVehiculo
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitRueda(this);
        }
    }

    class Luces : ParteVehiculo
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitLuces(this);
        }
    }

    // Interfaz de Visitor: IVisitor
    interface IVisitor
    {
        void VisitMotor(Motor motor);
        void VisitRueda(Rueda rueda);
        void VisitLuces(Luces luces);
    }

    // Visitor concreto: ImprimirVisitor
    class ImprimirVisitor : IVisitor
    {
        public void VisitMotor(Motor motor)
        {
            Console.WriteLine("Imprimiendo información sobre el motor");
        }

        public void VisitRueda(Rueda rueda)
        {
            Console.WriteLine("Imprimiendo información sobre una rueda");
        }

        public void VisitLuces(Luces luces)
        {
            Console.WriteLine("Imprimiendo información sobre las luces");
        }
    }

    // Cliente que utiliza el patrón Visitor
    class Program
    {
        static void Main()
        {
            // Crear una lista de partes de un vehículo
            List<ParteVehiculo> partes = new List<ParteVehiculo>
        {
            new Motor(),
            new Rueda(),
            new Luces()
        };

            // Crear un Visitor e imprimir información sobre cada parte
            IVisitor imprimirVisitor = new ImprimirVisitor();

            foreach (var parte in partes)
            {
                parte.Accept(imprimirVisitor);
            }
        }
    }

}



