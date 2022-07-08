using System;
namespace Console_War
{
    class Player{
        
        private string name;
        private int hp;
        private int dmg;
        private int statichp;
        public Player(){
            System.Console.WriteLine("player has been created");
        }
        public Player(string name, int hp,int dmg){
            System.Console.WriteLine("player has been created");
            Name = name; Hp = hp; Dmg = dmg;
        }
        public int Dmg{
            get{return this.dmg;}
            set{this.dmg = value;}
        }
        public int Hp {
            get{return this.hp;}
            set{this.hp = value ;}
        } 
        public string Name{
            get{return this.name;}
            set{this.name = value;}
        }      
        public int Statichp {
            get{return this.hp;}
            set{this.hp = value ;}
        } 
        public void SetValues(string name, int hp, int dmg){
            System.Console.WriteLine("Введите  name, hp, dmg ");
            this.name = System.Console.ReadLine();
            this.hp = Convert.ToInt32(System.Console.ReadLine());
            this.dmg = Convert.ToInt32(System.Console.ReadLine());
        }
        public virtual void PrintValues()
        {
            Console.WriteLine("0 Моб:" + Name + " Hp:" + Hp + " Dmg:" + Dmg);
        }
        public virtual void Step(List<Player> Team1, List<Player> Team2, Player F){
            F.Attack(F,Team2[0]);
        }
        public virtual void Attack(Player A, Player B){
            Random rand = new Random(); int uron = A.Dmg + rand.Next(-1,2);
            //B.Hp = B.Hp - uron;
            B.Takedmg (A, B, uron);
            //System.Console.Write(A.Name +" нанес "+B.Name+":"+uron+" / ");
        }
        public virtual void Takedmg(Player A, Player B, int uron){
            B.Hp = B.Hp - uron;System.Console.Write(B.Name+" получил:"+uron+" от "+A.Name +" / ");
        }
        
    }
}            