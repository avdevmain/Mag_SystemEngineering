using System;
public class ProgressManager
{
    private static ProgressManager instance;
    private int achievmentsCount = 4;

    public static ProgressManager getInstance() {
        if (ProgressManager.instance == null) 
            {ProgressManager.instance  = new ProgressManager();}
        
        return ProgressManager.instance; 

        
    }

    public int GetAchievementsCount() {
        return achievmentsCount;
    }

}
 
