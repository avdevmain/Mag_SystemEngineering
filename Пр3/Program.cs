using System;

namespace Пр3
{
 

    enum EnvType
    {
        None,
        Ground,
        Water,
        Air
    }
    class Program //Объединить два паттерна
    { //Стратегия билдер  
    //Для чего: Создание уровней для процедурно-генерируемой игры


        static void Main(string[] args)
        {
            int value = 0;
            bool invalid = false;
            LevelType levelType = null;


            do
            {
            invalid = false;
            Console.WriteLine("Select level type");
            Console.WriteLine("Input '0' for Ground, '1' for Water or '2' for Air.");
            value = Convert.ToInt32(Console.ReadLine());

            if (value == 0)
                {levelType = new GroundType();} // Задать стратегию 0
            else if (value == 1)
                {levelType = new WaterType();} //Задать стратегию 1
            else if (value == 2)
                {levelType = new AirType();} //Задать стратегию 2
            else {invalid = true; Console.WriteLine("Wrong value, select something in range 0-2!");}
            } while (invalid == true);
            
            Builder builder = null;
        
            Random rndValue = new Random();
            value = rndValue.Next(0,3);

            if (value < 3) 
                builder = new NormalBuilder();
            else
                builder = new HardBuilder(); //Выбор строителя при помощи рандомизатора (25% на то, что уровень будет создан "сложным" строителем)

            if (levelType !=null)
                levelType.CreateBasicLevel(builder); //Создание уровня при помощи строителя по стратегии
            else
                Console.WriteLine("Something went wrong....");

            Level createdLevel = builder.GetLevel();
            createdLevel.GetInfo(); //Вывести в консоль информацию о созданном уровне

            Console.ReadLine(); //Чтобы консоль сразу не закрывалась
        }

    }
    

    interface LevelType //Интерфейс Стратегий
    {
        void CreateBasicLevel(Builder builder){}
    }

    class GroundType : LevelType //Стратегия 0 
    {
        void LevelType.CreateBasicLevel(Builder builder)
        {
            builder.Reset(EnvType.Ground);
            builder.SetEnvironment();
            builder.SetPlatform(5);
            builder.SetAdditionalGeometry(2);
            builder.SetTraps(2);
            builder.SetEnemies(4);
        }


    }

    class WaterType : LevelType //Стратегия 1
    {
        void LevelType.CreateBasicLevel(Builder builder)
        {

            builder.Reset(EnvType.Water);
            builder.SetEnvironment();
            builder.SetPlatform(6);
            builder.SetAdditionalGeometry(3);
            builder.SetTraps(3);
            builder.SetEnemies(6);
        }

    }
    class AirType : LevelType //Стратегия 2
    {   
        void LevelType.CreateBasicLevel(Builder builder)
        {

            builder.Reset(EnvType.Air);
            builder.SetEnvironment();
            builder.SetPlatform(8);
            builder.SetAdditionalGeometry(4);
            builder.SetTraps(5);
            builder.SetEnemies(8);
        }

    }


    interface Builder //Интерфейс Строителей
    {
        void Reset(EnvType env){}
        void SetEnvironment(){}
        void SetPlatform(int levelLength){}
        void SetAdditionalGeometry(int additionalPerPlatform){}
        void SetTraps(int trapPerPlatform){}
        void SetEnemies(int enemiesPerPlatform){}
        Level GetLevel(){return null;}
    }



    class NormalBuilder : Builder //Строитель 1
    {                             //Создает всякое по своим алгоритмам для нормальной сложности
        Level newLevel;
        EnvType enviroment;
        void Builder.Reset(EnvType env) {
            newLevel = new Level();
            enviroment = env;
            newLevel.SetDiff(false); //normal builder = normal difficulty
        }
        void Builder.SetEnvironment()
        {newLevel.SetEnv(enviroment);}
        void Builder.SetPlatform(int levelLength)
        {newLevel.SetLength(levelLength);}
        void Builder.SetAdditionalGeometry(int additionalPerPlatform)
        {newLevel.SetAddGeom(additionalPerPlatform);}
        void Builder.SetTraps(int trapPerPlatform) 
        {newLevel.SetTraps(trapPerPlatform);}
        void Builder.SetEnemies(int enemiesPerPlatform) 
        {newLevel.SetEnemies(enemiesPerPlatform);}

        Level Builder.GetLevel()
        {
            return newLevel;
        }
    }

    class HardBuilder : Builder //Строитель 2
    {                           //Создает всякое по своим алгоритмам для увеличенной сложности, на практике алгоритмы должны отличаться. 
                                //Например, среди прочих врагов будет босс.
        Level newLevel;
        EnvType enviroment;
        void Builder.Reset(EnvType env) {
            newLevel = new Level();
            enviroment = env;
            newLevel.SetDiff(true); //hard builder = hard difficulty
        }
        void Builder.SetEnvironment()
        {newLevel.SetEnv(enviroment);}
        void Builder.SetPlatform(int levelLength)
        {newLevel.SetLength(levelLength);}
        void Builder.SetAdditionalGeometry(int additionalPerPlatform)
        {newLevel.SetAddGeom(additionalPerPlatform);}
        void Builder.SetTraps(int trapPerPlatform)
        {newLevel.SetTraps(trapPerPlatform);}
        void Builder.SetEnemies(int enemiesPerPlatform)
        {newLevel.SetEnemies(enemiesPerPlatform);}

        Level Builder.GetLevel()
        {
            return newLevel;
        }
    }

    class Level{
        
        EnvType env;
        bool isHard;
        int length;
        int addGeometry;
        int traps;
        int enemies;

        public void SetEnv(EnvType value){this.env = value;}
        public void SetDiff(bool value){isHard = value;}
        public void SetLength(int value){this.length = value;}
        public void SetAddGeom(int value){this.addGeometry = value;}
        public void SetTraps(int value){this.traps = value;}
        public void SetEnemies(int value){this.enemies = value;}


        public void GetInfo()
        {
            Console.WriteLine("---CREATED LEVEL---");
            Console.WriteLine("Level type: " + env.ToString());
            if (isHard) Console.WriteLine("Difficulty: hard"); else Console.WriteLine("Difficulty: normal");
            Console.WriteLine("Level length: " + length + " platforms");
            Console.WriteLine("Additional geometry: " + addGeometry + " per plaftorm");
            Console.WriteLine("Traps: " + traps + " per platform");
            Console.WriteLine("Enemies: " + enemies + " per platform");
        }
    }



}


