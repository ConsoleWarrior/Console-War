using System;
namespace Console_War
{
    class Warior : Player {
        public Condition.Status Rage = Condition.Rage;
        int CdR = 0;
        public Warior (string name){
            Name = name; Hp = 140; Dmg = 10; Krit = 50; Speed = 5;
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
            CdR++;
            if (CdR == 4) {
                //F.cond.Add(Rage);
                F.timeStatus[5] = 2; Program.Blue($"{F.Name} <RAGE> ");CdR = 0;
            }
            // try{
            //     foreach(Condition.Status aktivstatus in F.cond){ 
            //         if (aktivstatus(F)==false) F.cond.Remove(aktivstatus);
            //     }
            // }
            // catch {}
            
            F.Attack(F,Team2[0], Team2);
            //if(Team2[0].Hp <=0){Program.Red($"{Team2[0].Name} #DEAD#  /  ");Team2.Remove(Team2[0]);}
        }
        public override void Attack(Player A, Player B, List<Player> Team2){
            Random rand = new Random(); int uron = A.Dmg + rand.Next(-1,2);
            uron = Condition.CheckAttackStatus(A,uron);
            if (rand.Next(0, 100) < Krit)
            {
                uron = uron * 2; System.Console.Write("KRIT! ");
            }
            B.Takedmg (A, B, Team2, uron);
        }
        /*public override void Attack(Player A, Player B, List<Player> Team2){
            
            
            
            Random rand = new Random(); int uron = A.Dmg + rand.Next(-1,2);
            if (rand.Next(0,100)<Krit){
            uron = (A.Dmg+rand.Next(-1, 2))*2; System.Console.Write("KRIT! ");
            }
            
            B.Takedmg (A, B, Team2, uron);
            
        }*/
        // public override void Takedmg(Player A, Player B, int uron){
        //     B.Hp = B.Hp - uron;System.Console.Write($"{A.Name} нанес {uron} {B.Name}  /  "); if(B.Hp <= 0){Program.Red($"{B.Name} #DEAD# / ");Team2.Remove(B);}
        // }
    }
}        