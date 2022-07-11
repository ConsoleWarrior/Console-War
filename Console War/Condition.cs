using System;
namespace Console_War{
    class Condition{
        public delegate bool Status(Player F);
        //Player bot = new Player ("Бот",200,8); 
        /*public bool Rage(Player F){
            if (F.Cond[0]==true) F.Dmg = F.Dmg + 10;
            return true;
        }*/
        //public static int timeRage = 0;
        public static bool Rage(Player F){
           F.timeRage++;
            switch (F.timeRage){
                    case 1:{F.Dmg = F.Dmg + 10; System.Console.Write($"{F.Name} <RAGE>  /  ");return true ;};
                    case 3:{F.Dmg = F.Dmg - 10;System.Console.Write($"{F.Name} RAGE end  /  ");F.timeRage = 0;/*F.cond.Remove(F.cond[0]);*/return false;}; 
            }
            return true ;
        }

        public static bool Bubble(Player F){
           F.timeBubble++;
            switch (F.timeBubble){
                    case 1:{ System.Console.Write($"{F.Name} <BUBBLE>  /  ");return true ;};
                    case 3:{ System.Console.Write($"{F.Name} BUBBLE end  /  ");F.timeBubble = 0;/*F.cond.Remove(F.cond[0]);*/return false;};
            }
            return true ;
        }
        // public Status Rage = Rage2;
        // status per = Rage(bot);
    }
}