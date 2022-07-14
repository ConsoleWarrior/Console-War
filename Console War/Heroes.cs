using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_War 
{
    class Heroes : Player
    {
        
    }
    class Uter : Heroes
    {
        private int heal;
        private int Cdh = 0;
        private int Cdb = 4;
        private bool Wait = true;
        public int Heal
        {
            get { return this.heal; }
            set { this.heal = value; }
        }
        public Uter(string name)
        {
            Name = name; Hp = 350; Dmg = 20; Krit = 10; Heal = 50; Speed = 1;
            System.Console.WriteLine(Name+" has been created");
        }
        public override void PrintValues()
        {
            Console.WriteLine($"4 = герой {Name} Hp:{Hp} Dmg:{Dmg} Krit chance:{Krit}% Speed:{Speed} +Бабл на 2 хода(кд-5) +Каждый 3й ход хилит на {Heal}");
        }
        public override void Step(List<Player> Team1, List<Player> Team2, Player F)
        {
            for(int i=0;i<timeStatus.Length;i++){
                timeStatus[i]--;
            }
            if (!Condition.CheckDotStatus(F, Team1)){
                Cdh++; Cdb++;
                if (Cdb == 5 && Wait) {
                    System.Console.Write("<BUBBLE> на 2 хода? 1 - да 2 - ждать  /  ");
                    if (Convert.ToInt32(Console.ReadLine()) == 1)
                    {
                        F.timeStatus[0] = 2; Program.Blue($"*{F.Name}*<BUBBLE>");
                        Cdb = 0; Wait = false; }
                    else { Wait = true; Cdb = 4;
                        if (Cdh >= 3) { Healing(Team1, F); Cdh = 0; }
                        else { F.Attack(F, Team2[0], Team2);
                        } } }
                else { Wait = true;
                    if (Cdh >= 3) { Healing(Team1, F); Cdh = 0; }
                    else { F.Attack(F, Team2[0], Team2);
                    } }
            } else Team1.Remove(F);
        }
        public override void Takedmg(Player A, Player B, List<Player> Team2, int uron)
        {
            uron = Condition.CheckTakedmgStatus(B, uron);
            B.Hp = B.Hp - uron; System.Console.Write($"{A.Name} нанес {uron} {B.Name}  /  "); if(B.Hp <= 0){Program.Red($"{B.Name} #DEAD# / ");Team2.Remove(B);}
        }
        public void Healing(List<Player> Team1,Player F)
        {
            if(Team1.Count == 1){
                Team1[0].Hp = Team1[0].Hp + Heal; System.Console.Write(F.Name + " похилил " + Team1[0].Name+ " на " + Heal + "  /  ");
            }
            else {
                Program.Blue($"*{F.Name}*<Healing>Выбор цели:");
                int i = Convert.ToInt32(Console.ReadLine());
                Team1[i].Hp = Team1[i].Hp + Heal; System.Console.Write(F.Name + " похилил " + Team1[i].Name+ " на " + Heal + "  /  ");
            }
        }
    }    
    class Silvana : Heroes
    {
        private bool Wait = true;
        public Silvana(string name)
        {
            Name = name; Hp = 300; Dmg = 20; Krit = 30; Speed = 1;
            System.Console.WriteLine(Name+" has been created");
        }
        public override void PrintValues()
        {
            Console.WriteLine($"5 = герой {Name} Hp:{Hp} Dmg:{Dmg} Krit chance:{Krit}% Speed:{Speed} +Шанс 33% пробить 3х передних с кровотечением");
        }
        public override void Step(List<Player> Team1, List<Player> Team2, Player F)
        { 
            for (int i = 0; i < timeStatus.Length; i++)
            {
                timeStatus[i]--;
            }
            if (!Condition.CheckDotStatus(F, Team1)){
                Random rand = new();
                if (rand.Next(0, 100) < 33) Piercing(Team2, F);
                else F.Attack(F, Team2[0], Team2); }
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
            B.Takedmg(A, B, Team2, uron); B.timeStatus[3] = 3;
        }
        public static void Piercing(List<Player> Team2, Player F)
        {
            Program.Blue(F.Name + " <PIERCING>  /  "); int count = Team2.Count;
            Team2[0].Takedmg(F, Team2[0], Team2, 30); Team2[0].timeStatus[3] = 3;
            if (Team2.Count < count && Team2.Count > 0) { Team2[0].Takedmg(F, Team2[0], Team2, 20); Team2[0].timeStatus[3] = 3; }
            else
            if (Team2.Count >= 2) { Team2[1].Takedmg(F, Team2[1], Team2, 20); Team2[1].timeStatus[3] = 3; }
            if (Team2.Count < count && Team2.Count > 1) { Team2[1].Takedmg(F, Team2[1], Team2, 10); Team2[1].timeStatus[3] = 3; }
            else
            if (Team2.Count >= 3) { Team2[2].Takedmg(F, Team2[2], Team2, 10); Team2[2].timeStatus[3] = 3; }
        }
    }
}
