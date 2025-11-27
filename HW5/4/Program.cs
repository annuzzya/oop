using System;

namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            ChristmasTree c = new ChristmasTree();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            c.Operation();
            d1.Operation();
            d2.Operation();

            Console.Read();
        }
    }

    abstract class Component
    {
        public abstract void Operation();
    }

    class ChristmasTree : Component
    {
        public override void Operation()
        {
            Console.WriteLine("I am Christmas Tree");
        }
    }

    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    class ConcreteDecoratorA : Decorator
    {
        //private string addedState;

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("I am Christmas Tree with tapes");
        }
    }

    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("I am Christmas Tree with top");
        }
    }
}
