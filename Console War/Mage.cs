using System;
namespace Console_War
{
    class Mage : Player {
        private int krit;
        private int cd = 0;
        public int Cd {get;set;}
        public int Krit {get;set;} 
        public Mage (string name, int hp, int dmg, int krit){
            Name = name; Hp = hp; Dmg = dmg; Krit = krit; Speed = 6;
            System.Console.WriteLine(Name+" has been created");
        }
        public override void PrintValues()
        {
            Console.WriteLine("3 Моб:" + Name + " Hp:" + Hp + " Dmg:" + Dmg+" Krit chance:"+Krit+". Каждый третий ход AOE Fireball");
        }
        public override void Step(List<Player> Team1, List<Player> Team2, Player F){
            Cd++;
            if(Cd == 3) {Aoe(Team2, F); Cd = 0;}
            else F.Attack(F,Team2[0]);
            if(Team2[0].Hp <=0){System.Console.Write($"{Team2[0].Name} #DEAD# / ");Team2.Remove(Team2[0]);}
            

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
        public void Aoe(List<Player> Team,Player A){
            System.Console.WriteLine(A.Name+" AOE Fireball!!!");
            foreach(Player F in Team){
                F.Takedmg(A, F, 15);
            }
            
        }

        /*public override int Step(Player F1){
            
            if(cd==3){

            }
            
            
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