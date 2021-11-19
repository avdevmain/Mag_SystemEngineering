using System;
public class SomeManager
{
    private static SomeManager instance;
   
    public static SomeManager getInstance() {
        if (SomeManager.instance == null) 
            {SomeManager.instance  = new SomeManager();}
        
        return SomeManager.instance; 

        
    }

    public void SomeVoidMethod() {
        Console.WriteLine("Mr. Salieri sends his regards");
        Console.ReadLine();
    }

}
 
