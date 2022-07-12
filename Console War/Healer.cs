using System;
namespace Console_War
{
    class Healer : Player
    {
        private int heal;
        //private int cdh = 0;
        //public int Cdh { get; set; }
        public int Heal { get; set; }
        public Healer(string name)
        {
            Name = name; Hp = 125; Dmg = 8; Krit = 5; Speed = 4; Heal = 20;
            System.Console.WriteLine(Name+" has been created");
        }
        public override void PrintValues()
        {
            Console.WriteLine($"2 = моб {Name} Hp:{Hp} Dmg:{Dmg} Krit chance:{Krit}% Speed:{Speed} +Шанс 33% может похилить авангарда на {Heal}");
        }
        public override void Step(List<Player> Team1, List<Player> Team2, Player F)
        {
            for(int i=0;i<timeStatus.Length;i++){
                timeStatus[i]--;
            }
            Random rand = new Random();
            if (rand.Next(0, 100) < 33) { Healing(Team1,F);}
            else F.Attack(F, Team2[0], Team2);
            //if(Team2[0].Hp <=0){Program.Red($"{Team2[0].Name} #DEAD#  /  ");Team2.Remove(Team2[0]);}
        }
        // public override void Takedmg(Player A, Player B, int uron)
        // {
        //     B.Hp = B.Hp - uron; System.Console.Write($"{A.Name} нанес {uron} {B.Name}  /  "); if(B.Hp <= 0){Program.Red($"{B.Name} #DEAD# / ");Team2.Remove(B);Team1.Remove(B);}
        // }
        public void Healing(List<Player> Team1,Player F)
        {
            Team1[0].Hp = Team1[0].Hp + Heal; System.Console.Write(F.Name + " похилил " + Team1[0].Name+ " на " + Heal + "  /  ");
        }
    }
}