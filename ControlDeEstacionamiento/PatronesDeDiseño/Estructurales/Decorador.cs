/*

Decorator es un patrón de diseño estructural que te permite añadir funcionalidades a objetos 
colocando estos objetos dentro de objetos encapsuladores especiales que contienen estas funcionalidades.

*/

using System;

namespace ControlDeEstacionamiento.PatronesDeDiseño.Estructurales.Decorador
{

    // Componente base
    interface IComponent
    {
        string Operation();
    }

    // Implementación concreta del componente
    class ConcreteComponent : IComponent
    {
        public string Operation()
        {
            return "Funcionalidad principal del componente.";
        }
    }

    // Decorador base
    abstract class Decorator : IComponent
    {
        protected IComponent component;

        public Decorator(IComponent component)
        {
            this.component = component;
        }

        public virtual string Operation()
        {
            return component.Operation();
        }
    }

    // Decorador concreto
    class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(IComponent component) : base(component)
        {
        }

        public override string Operation()
        {
            return $"DecoratorA: {base.Operation()} Agregando funcionalidad adicional.";
        }
    }

    // Otro decorador concreto
    class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(IComponent component) : base(component)
        {
        }

        public override string Operation()
        {
            return $"DecoratorB: {base.Operation()} Agregando funcionalidad extra.";
        }
    }

    class Program
    {
        static void Main()
        {
            // Crear un componente concreto
            IComponent component = new ConcreteComponent();
            Console.WriteLine("Componente básico: " + component.Operation());

            // Decorar el componente con ConcreteDecoratorA
            IComponent decoratedComponentA = new ConcreteDecoratorA(component);
            Console.WriteLine("Componente decorado A: " + decoratedComponentA.Operation());

            // Decorar el componente con ConcreteDecoratorB
            IComponent decoratedComponentB = new ConcreteDecoratorB(decoratedComponentA);
            Console.WriteLine("Componente decorado B: " + decoratedComponentB.Operation());
        }
    }

}
