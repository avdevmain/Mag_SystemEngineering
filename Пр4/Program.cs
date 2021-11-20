using System;
using System.Collections.Generic;

namespace Пр4
{
    class Program //Фабрика + наблюдатель
    {
        static void Main(string[] args)
        {
            Creator chosenSpawner = null;
            int value = 0;
            bool invalid = false;
            

            //Задание стратегии по выбору пользователя
            do
            {
            invalid = false;
            Console.WriteLine("Select level type");
            Console.WriteLine("Input '0' for Mob or '1' for Boss.");
            value = Convert.ToInt32(Console.ReadLine());

            if (value == 0)
                {chosenSpawner = new MobSpawner();} // Задать  0
            else if (value == 1)
                {chosenSpawner = new BossSpawner();} //Задать стратегию 1
            else {invalid = true; Console.WriteLine("Wrong value, select something in range 0-1!");}
            } while (invalid == true);

            Observable createdEnemy =  chosenSpawner.FactoryMethod();

            createdEnemy.AddObserver(new HealthObserver()); //Подписаться на обновления здоровья


            bool exit = false;
            do{
            Console.WriteLine("------");
            Console.WriteLine("Input '0' to hit it or '1' to exit.");
            value = Convert.ToInt32(Console.ReadLine());
            if (value == 0)
                createdEnemy.Hit();
            else exit = true;
            }while (exit!=true);


        }
    }

    interface Observer
    {public void Update(Observable obj){}}

    class HealthObserver : Observer
    {
        public HealthObserver()
        {
            Console.WriteLine("HealthObserver created");
        }
        public void Update(Observable obj) {
            string objId = obj.GetID();
            Console.WriteLine("*OnHit animation* on object " + objId);
        }
    }

    interface Observable
    {
        void AddObserver(Observer obj){}
        void NotifyObservers(){}
        void RemoveObserver(Observer obj){}
        void Hit();

        string GetID();
    }

    class Mob : Observable
    {
        public string id;
        private List<Observer> observers;
        public Mob()
        {
            id = "mob_001";
            observers = new List<Observer>();
            Console.WriteLine("Mob created!");
        }

        public void AddObserver(Observer obj)
        {observers.Add(obj);
        Console.WriteLine("Observer assigned");
        }

        public void RemoveObserver(Observer obj)
        {observers.Remove(obj);
        Console.WriteLine("Observer removed");
        }

        public void NotifyObservers()
        {
            foreach(Observer observer in observers)
            {observer.Update(this);}
            Console.WriteLine("Observers notified");
        }

        public void Hit()
        {
            NotifyObservers();
        }
        public string GetID()
        {
            return id;
        }
    }

    class Boss : Observable
    {
        public string id;
        private List<Observer> observers;
        public Boss()
        {
            id = "boss_001";
            observers = new List<Observer>();
            Console.WriteLine("Boss created!");
        }

        public void AddObserver(Observer obj)
        {observers.Add(obj);}

        public void RemoveObserver(Observer obj)
        {observers.Remove(obj);}

        public void NotifyObservers()
        {
            foreach(Observer observer in observers)
            {observer.Update(this);}
            Console.WriteLine("Observers notified");
        }

        public void Hit()
        {
            NotifyObservers();
        }

        public string GetID()
        {
            return id;
        }
     
    }

    abstract class Creator //base Creator class
    {
        public abstract Observable FactoryMethod();
    }

    class MobSpawner : Creator //Creator 0 
    {
        public override Mob FactoryMethod() { return new Mob(); } //Creates product 1 - mob
    }

    class BossSpawner : Creator //Creator 1
    {
        public override Boss FactoryMethod() { return new Boss(); } //Creates product 2 - boss
    }
}
