using System;
namespace Console_War
{
    class Warior : Player {
        int CdR = 0;
        public Warior (string name){
            Name = name; Hp = 140; Dmg = 10; Krit = 30; Speed = 5;
            System.Console.WriteLine(Name+" has been created");
        }
        public override void PrintValues()
        {
            Console.WriteLine($"1 = моб {Name} Hp:{Hp} Dmg:{Dmg} Krit chance:{Krit}% Speed:{Speed} +Каждые 4 хода увеличивает на 2 хода урон на 10");
        }
        public override void Step(List<Player> Team1, List<Player> Team2, Player F){
            for(int i=0;i<timeStatus.Length;i++){
                timeStatus[i]--;
            }
            if (!Condition.CheckDotStatus(F, Team1))
            {
                CdR++;
                if (CdR == 4)
                {
                    F.timeStatus[5] = 2; Program.Blue($"{F.Name} <RAGE> "); CdR = 0;
                }
                F.Attack(F, Team2[0], Team2);
            }
            else Team1.Remove(F);
        }
    }
}        