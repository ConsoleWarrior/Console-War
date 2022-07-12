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
        public bool Wait = true;
        public int Cdb { get; set; }
        public int Cdh { get; set; }
        public int Heal
        {
            get { return this.heal; }
            set { this.heal = value; }
        }
        public Uter(string name)
        {
            Name = name; Hp = 300; Dmg = 20; Krit = 10; Heal = 50; Speed = 1;
            System.Console.WriteLine(Name+" has been created");
        }
        public override void PrintValues()
        {
            Console.WriteLine($"4 = герой {Name} Hp:{Hp} Dmg:{Dmg} Krit chance:{Krit}% Speed:{Speed} +Бабл на 2 хода(кд-5) +Каждый 3й ход хилит на {Heal}");
        }
        public override void Step(List<Player> Team1, List<Player> Team2, Player F)
        {
            foreach (byte el in F.timeStatus)
            { el--; }
            Cdh++; Cdb++;
            if(Cdb==5 && Wait){
                System.Console.WriteLine("<BUBBLE> на 2 хода? 1 - да 2 - ждать");
                if (Convert.ToInt32(Console.ReadLine()) == 1)
                    {/*F.cond.Add (Condition.Bubble);*/
                    F.timeStatus[0] = 2;
                    Cdb = 0;Wait = false;}
                else {Wait = true;Cdb=4;
                    if (Cdh >= 3) { Healing(Team1,F); Cdh = 0; }
                    else {F.Attack(F, Team2[0],Team2);//if(Team2[0].Hp <=0){Program.Red($"{Team2[0].Name} #DEAD#  /  ");Team2.Remove(Team2[0]);}
                    }}}
            else {Wait = true;
                if (Cdh >= 3) { Healing(Team1,F); Cdh = 0; }
                    else {F.Attack(F, Team2[0],Team2);//if(Team2[0].Hp <=0){ Program.Red($"{Team2[0].Name} #DEAD#  /  "); Team2.Remove(Team2[0]);}
                    }}
            try{
                foreach(Condition.Status aktivstatus in F.cond){ 
                    if (aktivstatus(F)==false) F.cond.Remove(aktivstatus);
                }
            }catch {}
            
        }
        public override void Takedmg(Player A, Player B, List<Player> Team2, int uron)
        {
            Condition.CheckTakedmgStatus(B, uron);
            //if (timeBubble>0) uron = 0;
            B.Hp = B.Hp - uron; System.Console.Write($"{A.Name} нанес {uron} {B.Name}  /  "); if(B.Hp <= 0){Program.Red($"{B.Name} #DEAD# / ");Team2.Remove(B);}
        }
        public void Healing(List<Player> Team1,Player F)
        {
            if(Team1.Count == 1){
                Team1[0].Hp = Team1[0].Hp + Heal; System.Console.Write(F.Name + " похилил " + Team1[0].Name+ " на " + Heal + "  /  ");
            }
            else {
                Program.Blue("<Healing>Выбор цели:");
                int i = Convert.ToInt32(Console.ReadLine());
                Team1[i].Hp = Team1[i].Hp + Heal; System.Console.Write(F.Name + " похилил " + Team1[i].Name+ " на " + Heal + "  /  ");
            }
        }
    }
}
