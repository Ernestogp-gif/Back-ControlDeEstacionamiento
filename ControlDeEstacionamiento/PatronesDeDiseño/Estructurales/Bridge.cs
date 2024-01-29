/*
Bridge es un patrón de diseño estructural que te permite dividir una clase grande, o un grupo 
de clases estrechamente relacionadas, en dos jerarquías separadas (abstracción e implementación) 
que pueden desarrollarse independientemente la una de la otra.
*/
using System;

namespace ControlDeEstacionamiento.PatronesDeDiseño.Estructurales.Bridge
{

    // Implementación: Motor
    interface IMotor
    {
        void Arrancar();
        void Detener();
    }

    // Implementación concreta: MotorCombustionInterna
    class MotorCombustionInterna : IMotor
    {
        public void Arrancar()
        {
            Console.WriteLine("Motor de combustión interna arrancado");
        }

        public void Detener()
        {
            Console.WriteLine("Motor de combustión interna detenido");
        }
    }

    // Implementación concreta: MotorElectrico
    class MotorElectrico : IMotor
    {
        public void Arrancar()
        {
            Console.WriteLine("Motor eléctrico arrancado");
        }

        public void Detener()
        {
            Console.WriteLine("Motor eléctrico detenido");
        }
    }

    // Abstracción: Vehiculo
    abstract class Vehiculo
    {
        protected IMotor motor;

        public Vehiculo(IMotor motor)
        {
            this.motor = motor;
        }

        public abstract void Iniciar();
        public abstract void Detener();
    }

    // Abstracción refinada: Automovil
    class Automovil : Vehiculo
    {
        public Automovil(IMotor motor) : base(motor)
        {
        }

        public override void Iniciar()
        {
            Console.WriteLine("Automóvil arrancando...");
            motor.Arrancar();
        }

        public override void Detener()
        {
            Console.WriteLine("Automóvil deteniendo...");
            motor.Detener();
        }
    }

    // Abstracción refinada: Motocicleta
    class Motocicleta : Vehiculo
    {
        public Motocicleta(IMotor motor) : base(motor)
        {
        }

        public override void Iniciar()
        {
            Console.WriteLine("Motocicleta arrancando...");
            motor.Arrancar();
        }

        public override void Detener()
        {
            Console.WriteLine("Motocicleta deteniendo...");
            motor.Detener();
        }
    }

    class Program
    {
        static void Main()
        {
            // Crear instancias de implementación
            IMotor motorCombustionInterna = new MotorCombustionInterna();
            IMotor motorElectrico = new MotorElectrico();

            // Crear instancias de abstracción refinada y asignar implementación
            Vehiculo automovil = new Automovil(motorCombustionInterna);
            Vehiculo motocicleta = new Motocicleta(motorElectrico);

            // Utilizar las abstracciones refinadas
            automovil.Iniciar();
            automovil.Detener();

            Console.WriteLine();

            motocicleta.Iniciar();
            motocicleta.Detener();
        }
    }

}