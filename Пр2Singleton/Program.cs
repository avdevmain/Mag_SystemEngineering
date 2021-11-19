using System;

namespace Пр2Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            SomeManager manager = SomeManager.getInstance();
            
            manager.SomeVoidMethod();
        }
    }
}
