using System;
namespace Console_War
{
    class Boss : Player
    {
        private bool Wait = true;
        private int turn = 0;
        public Boss(string name)
        {
            Name = name; Hp = 1000; Dmg = 20; Krit = 30; Speed = 9;
            System.Console.WriteLine(Name + " has been created");
        }
        public override void PrintValues()
        {
            Console.WriteLine($"9 = БОСС {Name} Hp:{Hp} Dmg:{Dmg} Krit chance:{Krit}% Speed:{Speed} +1атака каждый ход, бьет случайного врага.");
        }
        public override void Step(List<Player> Team1, List<Player> Team2, Player F)
        {
            turn++; Random rand = new();
            for (int i = 0; i < timeStatus.Length; i++)
            {
                timeStatus[i]--;
            }
            if (!Condition.CheckDotStatus(F, Team1))
            {
                for(int i = 0; i < turn; i++)              
                F.Attack(F, Team2[rand.Next(0,Team2.Count)], Team2);
                

            }
            else Team1.Remove(F);

        }
        public override void Attack(Player A, Player B, List<Player> Team2)
        {
            Random rand = new(); int uron = A.Dmg + rand.Next(-1, 2);
            uron = Condition.CheckAttackStatus(A, uron);
            if (rand.Next(0, 100) < Krit)
            {
                uron = (A.Dmg + rand.Next(-1, 2)) * 2; System.Console.Write(Krit + "KRIT! ");
            }
            B.Takedmg(A, B, Team2, uron);
        }
        public static void Piercing(List<Player> Team2, Player F)
        {
            Program.Blue(F.Name + " <WEAKNESS>  /  "); int count = Team2.Count;
            
        }


    }
}
