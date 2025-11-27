using System;

namespace FactoryMethodAndFacadeExample
{
    public abstract class Creator
    {
        public abstract Product FactoryMethod(int type);
    }

    public class ConcreteCreator : Creator
    {
        public override Product FactoryMethod(int type)
        {
            switch (type)
            {
                case 1: return new ConcreteProductA();
                case 2: return new ConcreteProductB();
                default: throw new ArgumentException("Invalid type.", "type");
            }
        }
    }

    public abstract class Product { }

    public class ConcreteProductA : Product { }

    public class ConcreteProductB : Product { }

    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

    class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine(" SubSystemOne Method");
        }
    }

    class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine(" SubSystemTwo Method");
        }
    }

    class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine(" SubSystemThree Method");
        }
    }

    class SubSystemFour
    {
        public void MethodFour()
        {
            Console.WriteLine(" SubSystemFour Method");
        }
    }

    class Facade
    {
        SubSystemOne one;
        SubSystemTwo two;
        SubSystemThree three;
        SubSystemFour four;

        public Facade()
        {
            one = new SubSystemOne();
            two = new SubSystemTwo();
            three = new SubSystemThree();
            four = new SubSystemFour();
        }

        public void MethodA()
        {
            Console.WriteLine("\nMethodA() ---- ");
            one.MethodOne();
            two.MethodTwo();
            four.MethodFour();
        }

        public void MethodB()
        {
            Console.WriteLine("\nMethodB() ---- ");
            two.MethodTwo();
            three.MethodThree();
        }
    }
    class MainApp
    {
        static void Main()
        {
            Console.WriteLine("FactoryMethod pattern");
            Creator creator = new ConcreteCreator();
            for (int i = 1; i <= 2; i++)
            {
                var product = creator.FactoryMethod(i);
                Console.WriteLine("Where id = {0}, Created {1} ", i, product.GetType());
            }
            Console.WriteLine("Facade pattern");
            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();

            Console.ReadKey();
        }
    }
}

