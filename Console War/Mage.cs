using System;
namespace Console_War
{
    class Mage : Player {
        private int krit;
        private int cd = 0;
        public int Cd {get;set;}
        public int Krit {get;set;} 
        public Mage (string name){
            Name = name; Hp = 110; Dmg = 12; Krit = 20; Speed = 6;
            System.Console.WriteLine(Name+" has been created");
        }
        public override void PrintValues()
        {
            Console.WriteLine($"3 = моб {Name} Hp:{Hp} Dmg:{Dmg} Krit chance:{Krit}% Speed:{Speed} +Фаербол в арьергард шанс 25%");
        }
        public override void Step(List<Player> Team1, List<Player> Team2, Player F){
            foreach (byte el in F.timeStatus)
            { F.timeStatus[el]--; }
            Random rand = new Random();
            if(rand.Next(0,100)<25) Fireball(Team2, F);
            else F.Attack(F, Team2[0], Team2);
            //if(Team2[0].Hp <=0){Program.Red($"{Team2[0].Name} #DEAD#  /  ");Team2.Remove(Team2[0]);}
        }
        /*public override void Attack(Player A, Player B, List<Player> Team2){
            Random rand = new Random(); int uron = A.Dmg + rand.Next(-1,2);
            if (rand.Next(0,100)<Krit){
                uron = (A.Dmg+rand.Next(-1, 2))*2; System.Console.Write("KRIT! ");
            }
            B.Takedmg (A, B, Team2, uron);
        }*/
        // public override void Takedmg(Player A, Player B, int uron){
        //     B.Hp = B.Hp - uron; System.Console.Write($"{A.Name} нанес {uron} {B.Name}  /  "); if(B.Hp <= 0){Program.Red($"{B.Name} #DEAD# / ");Team2.Remove(B);}
        // }
        public void Fireball(List<Player> Team2, Player F){
            Program.Blue(F.Name+" <FIREBALL>  /  "); int count = Team2.Count;
            Team2[Team2.Count-1].Takedmg (F, Team2[Team2.Count-1], Team2, 30);
            if (Team2.Count < count) Team2[Team2.Count - 1].Takedmg(F, Team2[Team2.Count - 1], Team2, 20);
            else
            if (Team2.Count >= 2) Team2[Team2.Count-2].Takedmg(F, Team2[Team2.Count-2], Team2, 20);
            if (Team2.Count < count) Team2[Team2.Count - 2].Takedmg(F, Team2[Team2.Count - 2], Team2, 10);
            else
            if (Team2.Count >= 3) Team2[Team2.Count-3].Takedmg(F, Team2[Team2.Count-3], Team2, 10);
           

            /*foreach(Player F in Team2){
                F.Takedmg(A, F, Team2, 15);
            }*/
        }
    }
}        