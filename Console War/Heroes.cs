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
        private int cdh = 0;
        private int cdb = 4;
        //private int cdb2 = 3;
        //private bool aktiv = false;
        //public bool Aktiv { get; set; }
        public bool Wait = true;
        public int Cdb { get; set; }
        //public int Cdb2 { get; set; }
        public int Cdh { get; set; }
        public int Heal
        {
            get { return this.heal; }
            set { this.heal = value; }
        }
        public Uter(string name, int hp, int dmg, int heal)
        {
            Name = name; Hp = hp; Dmg = dmg; Heal = heal; Speed = 1;
            System.Console.WriteLine(Name+" has been created");
        }
        public override void PrintValues()
        {
            Console.WriteLine("4 Герой:" + Name + " Hp:" + Hp + " Dmg:" + Dmg + " Бабл на 2 хода(кд-5) и Хил себя каждый 3й ход:" + Heal);
        }
        public override void Step(List<Player> Team1, List<Player> Team2, Player F)
        {
            Cdh++; Cdb++;
            /*if (Aktiv) Cdb2--;
            if (Cdb2 == 0) { Aktiv = false; Cdb2 = 3; }
            if (Cdb1 == 5 && Cdb2 == 3) Bubble();
            else*/
            if(Cdb==5 && Wait){
                System.Console.WriteLine("<BUBBLE> на 2 хода? 1 - да 2 - ждать");
                if (Convert.ToInt32(Console.ReadLine()) == 1)
                    {F.cond.Add (Condition.Bubble);Cdb = 0;Wait = false;}
                else {Wait = true;Cdb=4;
                    if (Cdh >= 3) { Healing(Team1,F); Cdh = 0; }
                    else {F.Attack(F, Team2[0]);if(Team2[0].Hp <=0){System.Console.Write($"{Team2[0].Name} #DEAD# / ");Team2.Remove(Team2[0]);}}}}
            else {Wait = true;
                if (Cdh >= 3) { Healing(Team1,F); Cdh = 0; }
                    else {F.Attack(F, Team2[0]);if(Team2[0].Hp <=0){ Console.ForegroundColor = ConsoleColor.Red; System.Console.Write($"{Team2[0].Name} #DEAD# / "); Console.ResetColor(); Team2.Remove(Team2[0]);}}}
            /*if (Wait && Cdb == 4)
            {
                if (Cdh >= 3) { Healing(Team1,F); Cdh = 0; }
                else {F.Attack(F, Team2[0]);if(Team2[0].Hp <=0){System.Console.Write($"{Team2[0].Name} сдох / ");Team2.Remove(Team2[0]);}}
            }*/
            try{
                foreach(Condition.Status aktivstatus in F.cond){ 
                    if (aktivstatus(F)==false) F.cond.Remove(aktivstatus);
                }
            }catch {}
            
        }
        public override void Takedmg(Player A, Player B, int uron)
        {
            if (timeBubble>0) uron = 0;
            B.Hp = B.Hp - uron; System.Console.Write(B.Name + " получил:" + uron + " от " + A.Name + " / ");
        }
        public void Healing(List<Player> Team1,Player F)
        {
            if(Team1.Count == 1){
                Team1[0].Hp = Team1[0].Hp + Heal; System.Console.Write(F.Name + " похилил " + Team1[0].Name+ " на " + Heal + " / ");
            }
            else {
                System.Console.Write("<Healing>Выбор цели:");
                int i = Convert.ToInt32(Console.ReadLine());
                Team1[i].Hp = Team1[i].Hp + Heal; System.Console.Write(F.Name + " похилил " + Team1[i].Name+ " на " + Heal + " / ");
            }
        }
        /*public void Healing(Player F)
        {
            F.Hp = F.Hp + Heal; System.Console.Write(F.Name + " похилился на " + Heal + " / ");
        }*/
        /*public void Bubble()
        {
            
            {
                Cdb2--; Cdb1 = 0; Aktiv = true; System.Console.WriteLine("Bubble");
            }
            else
            {
                Cdb1 = 4;
                Wait = true;
            }
        }*/
    }
}
