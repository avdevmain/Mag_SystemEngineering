using System;

namespace Пр2FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = 0;
            Creator maker = null;

            Console.WriteLine("Input '0' for Product A, or '1' for Product B.");
            value = Convert.ToInt32(Console.ReadLine());
        
            if (value == 0)
                maker = new CreatorA();
            else if (value == 1)
                maker = new CreatorB();
            
            if (maker!=null)
                maker.FactoryMethod();
            else
                Console.WriteLine("Something wrong was pressed during input phase");

            Console.ReadLine();
        }
    }


    abstract class Product
    {}

    class ProductA : Product
    {
        public ProductA()
        {
            Console.WriteLine("A product!");
        }
    }

    class ProductB : Product
    {
        public ProductB()
        {
            Console.WriteLine("B product!");
        }
    }

    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    class CreatorA : Creator
    {
        public override Product FactoryMethod() { return new ProductA(); }
    }

    class CreatorB : Creator
    {
        public override Product FactoryMethod() { return new ProductB(); }
    }
}
