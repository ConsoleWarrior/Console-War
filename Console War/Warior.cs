using System;
namespace Console_War
{
    class Warior : Player {
        private int krit;
        public int Krit {get;set;
            //get{return this.krit;}
            //set{this.krit = value ;}
        } 
        public Warior (string name, int hp, int dmg, int krit){
            Name = name; Hp = hp; Dmg = dmg; Krit = krit;
        }
        public override void PrintValues()
        {
            Console.WriteLine("1 Моб:" + Name + " Hp:" + Hp + " Dmg:" + Dmg+" Krit chance:"+Krit);
        }
        public override void Step(List<Player> Team1, List<Player> Team2, Player F){
            
            F.Attack(F,Team2[0]);
            

        }
        public override void Attack(Player A, Player B){
            Random rand = new Random(); int uron = A.Dmg + rand.Next(-1,2);
            if (rand.Next(0,100)<Krit){
            uron = (A.Dmg+rand.Next(-1, 2))*2; System.Console.Write(A.Name +" критует Dmgх2!"+" / ");
            }
            //B.Hp = B.Hp - uron;
            B.Takedmg (A, B, uron);
            //System.Console.Write(A.Name +" нанес "+B.Name+":"+uron+" / ");
        }
        public override void Takedmg(Player A, Player B, int uron){
            B.Hp = B.Hp - uron;System.Console.Write(B.Name+" получил:"+uron+" от "+A.Name +" / ");
        }




        /*public override int Step(Player F1){
            Random rand = new Random();
            int uron = F1.Dmg + rand.Next(-1, 2); 
            if (rand.Next(0,100)<Krit){
            uron = (F1.Dmg+rand.Next(-1, 2))*2; System.Console.Write(Name +" критует Dmgх2!"+" / ");
            }
            System.Console.Write(Name +" нанес "+uron+" / ");
            return uron; 
        }*/
        
    }
}        