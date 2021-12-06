using System;

namespace Практика6
{

    //No IoC
/*
    class Program
    {       
        static void Main(string[] args)
        {
            Player player = new Player();

            player.TriggerAttack();
        }
    }
   class Weapon
   {
       public void Attack()
       {
           Console.WriteLine("Bang!");
       }
   }

   class Player
   {
       private Weapon weapon = new Weapon();

        public void TriggerAttack()
        {
            weapon.Attack();
        }
   }
*/


//With IoC
///*
    class Program
    {       
        static void Main(string[] args)
        {
            Player player = new Player(null);
            player.TriggerAttack();

            player.SetWeapon(new Gun());
            player.TriggerAttack();

            player.SetWeapon(new Shotgun());
            player.TriggerAttack();

        }
    }
    interface IWeapon
    {
        void Attack();
    }

   class Gun : IWeapon
   {
        public void Attack()
        {
           Console.WriteLine("Bang!");
        }
   }

   class Shotgun : IWeapon
   {
       public void Attack()
       {
           Console.WriteLine("Boom!");
       }
   }

   class Player
   {
       IWeapon weapon;
        public Player(IWeapon weaponToSet)
        {
            if (weaponToSet!=null)
                this.weapon = weaponToSet;
        }

        public void SetWeapon(IWeapon weaponToSet)
        {
            this.weapon = weaponToSet;
        }

        public void TriggerAttack()
        {
            if (weapon!=null)
                weapon.Attack();
            else
                Console.WriteLine("Punch!");
        }
   }

//*/
    
}
