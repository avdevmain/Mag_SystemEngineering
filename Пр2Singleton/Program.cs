using System;

namespace Пр2Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgressManager manager = ProgressManager.getInstance();
            
            int achievementsCount = manager.GetAchievementsCount();
        
            Console.WriteLine("Total achievements: " + achievementsCount);
            Console.ReadLine();
        }
    }
}
