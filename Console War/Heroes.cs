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
    class Anduin : Heroes
    {
        private int heal;
        private int cdh = 0;
        private int cdb1 = 4;
        private int cdb2 = 3;
        private bool aktiv = false;
        public bool Aktiv { get; set; }
        public bool Wait = false;
        public int Cdb1 { get; set; }
        public int Cdb2 { get; set; }
        public int Cdh { get; set; }
        public int Heal
        {
            get { return this.heal; }
            set { this.heal = value; }
        }
        public Anduin(string name, int hp, int dmg, int heal)
        {
            Name = name; Hp = hp; Dmg = dmg; Heal = heal;
        }
        public override void PrintValues()
        {
            Console.WriteLine("4 Герой:" + Name + " Hp:" + Hp + " Dmg:" + Dmg + " Бабл на 2 хода(кд-5) и Хил себя каждый 3й ход:" + Heal);
        }
        public override void Step(List<Player> Team1, List<Player> Team2, Player F)
        {
            Cdh++; Cdb1++;
            if (Aktiv) Cdb2--;
            if (Cdb2 == 0) { Aktiv = false; Cdb2 = 3; }
            if (Cdb1 == 5 && Cdb2 == 3) Bubble();
            else
            if (Cdh >= 3) { Healing(F); Cdh = 0; }
            else F.Attack(F, Team2[0]);
            if (Wait && Cdb1 == 4)
            {
                if (Cdh >= 3) { Healing(F); Cdh = 0; }
                else F.Attack(F, Team2[0]);
            }
        }
        public override void Takedmg(Player A, Player B, int uron)
        {
            if (Aktiv) uron = 0;
            B.Hp = B.Hp - uron; System.Console.Write(B.Name + " получил:" + uron + " от " + A.Name + " / ");
        }
        public void Healing(Player F)
        {
            F.Hp = F.Hp + Heal; System.Console.Write(F.Name + " похилился на " + Heal + " / ");
        }
        public void Bubble()
        {
            System.Console.WriteLine("Врубить Бабл на 2 хода? 1 - да/ 2 - подождать");
            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                Cdb2--; Cdb1 = 0; Aktiv = true; System.Console.WriteLine("Bubble");
            }
            else
            {
                Cdb1 = 4;
                Wait = true;
            }
        }
    }
}
