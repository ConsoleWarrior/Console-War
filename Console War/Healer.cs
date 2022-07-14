using System;
namespace Console_War
{
    class Healer : Player
    {
        private int heal;
        public int Heal
        {
            get { return this.heal; }
            set { this.heal = value; }
        }
        public Healer(string name)
        {
            Name = name; Hp = 125; Dmg = 8; Krit = 5; Speed = 4; Heal = 25;
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
            if (!Condition.CheckDotStatus(F, Team1))
            {
                Random rand = new();
                if (rand.Next(0, 100) < 33) { Healing(Team1, F); }
                else F.Attack(F, Team2[0], Team2);
            }
            else Team1.Remove(F);
        }
        
        public void Healing(List<Player> Team1,Player F)
        {
            Team1[0].Hp = Team1[0].Hp + Heal; System.Console.Write(F.Name + " похилил " + Team1[0].Name+ " на " + Heal + "  /  ");
        }
    }
}