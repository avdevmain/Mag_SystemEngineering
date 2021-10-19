using System;
public class SomeManager
{
    public static SomeManager instance;

    private void Awake() {
        getInstance();
    }
   
    SomeManager getInstance() {
        if (instance == null) 
            {instance  = this;}
        
        return instance; //else Destroy(this);

        
    }

    public static void SomeVoidMethod() {
        Console.WriteLine("Mr. Salieri sends his regards");
        Console.ReadLine();
    }

}
 