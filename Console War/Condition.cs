using System;
namespace Console_War{
    class Condition{
        public delegate bool Status(Player F);
        //Player bot = new Player ("Бот",200,8); 
        public static bool Rage(Player F){
           F.timeRage++;
            switch (F.timeRage){
                    case 1:{F.Dmg = F.Dmg + 10; System.Console.Write($"{F.Name} <RAGE>  /  ");return true ;};
                    case 3:{F.Dmg = F.Dmg - 10;System.Console.Write($"{F.Name} <RAGE> END  /  ");F.timeRage = 0;/*F.cond.Remove(F.cond[0]);*/return false;}; 
            }
            return true ;
        }

        /*public static bool Bubble(Player F){
           F.timeBubble++;
            switch (F.timeBubble){
                    case 1:{ System.Console.Write($"{F.Name} <BUBBLE>  /  ");return true ;};
                    case 3:{ System.Console.Write($"{F.Name} <BUBBLE> END  /  ");F.timeBubble = 0;return false;};
            }
            return true ;
        }*/

        public static int CheckAttackStatus(Player F, int uron) {

            return uron;
        }

        public static int CheckTakedmgStatus(Player F, int uron) {
            if (F.timeStatus[0] > 0) uron = 0;//Bubble
            if (F.timeStatus[1] > 0) uron = uron / 2;//Shield
            return uron;
        
        }
    }
}