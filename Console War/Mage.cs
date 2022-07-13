using System;
namespace Console_War
{
    class Mage : Player {
        
        private int cd = 0;
        public int Cd
        {
            get { return this.cd; }
            set { this.cd = value; }
        }

        public Mage (string name){
            Name = name; Hp = 110; Dmg = 12; Krit = 20; Speed = 6;
            System.Console.WriteLine(Name+" has been created");
        }
        public override void PrintValues()
        {
            Console.WriteLine($"3 = моб {Name} Hp:{Hp} Dmg:{Dmg} Krit chance:{Krit}% Speed:{Speed} +Фаербол в арьергард шанс 25%");
        }
        public override void Step(List<Player> Team1, List<Player> Team2, Player F){
            for(int i=0;i<timeStatus.Length;i++){
                timeStatus[i]--;
            }
            Condition.CheckDotStatus(F, Team1);
            Random rand = new();
            if(rand.Next(0,100)<25) Fireball(Team2, F);
            else F.Attack(F, Team2[0], Team2);
        }

        public static void Fireball(List<Player> Team2, Player F){
            Program.Blue(F.Name+" <FIREBALL>  /  "); int count = Team2.Count;
            Team2[^1].Takedmg (F, Team2[^1], Team2, 30);
            if (Team2.Count < count) Team2[^1].Takedmg(F, Team2[^1], Team2, 20);
            else
            if (Team2.Count >= 2) Team2[^2].Takedmg(F, Team2[^2], Team2, 20);
            if (Team2.Count < count) Team2[^2].Takedmg(F, Team2[^2], Team2, 10);
            else
            if (Team2.Count >= 3) Team2[^3].Takedmg(F, Team2[^3], Team2, 10);
        }
    }
}        