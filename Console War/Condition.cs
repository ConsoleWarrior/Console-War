using System;
namespace Console_War{
    class Condition{
        public static int CheckAttackStatus(Player F, int uron) {
            if(F.timeStatus[5] > 0) uron = uron + 10; //Rage

            return uron;
        }

        public static int CheckTakedmgStatus(Player F, int uron) {  //F - тот кто получает урон
            if (F.timeStatus[0] > 0) uron = 0;//Bubble
            if (F.timeStatus[1] > 0) uron = uron / 2;//Shield
            if (F.timeStatus[2] > 0) uron = uron*2;//
            return uron;
        }
        public static bool CheckDotStatus(Player F, List<Player> Team)
        {
            if (F.timeStatus[3] > 0) // Bleed
            {
                F.Hp = F.Hp - 5; System.Console.Write($"{F.Name} is bleeding -5hp  /  ");
                if (F.Hp <= 0) { Program.Red($"{F.Name} #DEAD# / ");  return true; }
            }
            return false;
        }
    }
}