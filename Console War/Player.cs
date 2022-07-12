using System;
namespace Console_War
{
    class Player{
        private string name;
        private int hp;
        private int dmg;
        private int krit = 5;
        private int speed = 7;
        private int statichp;
        public byte timeRage = 0;
        public byte timeBubble = 0;
        public List<Condition.Status>  cond = new List<Condition.Status>();
        public int[] timeStatus = new int[10];
                
        public int Dmg {
            get{return this.dmg;}
            set{this.dmg = value;}
        }
        public int Hp {
            get{return this.hp;}
            set{this.hp = value ;}
        } 
        public string Name {
            get{return this.name;}
            set{this.name = value;}
        }
        public int Krit
        {
            get { return this.krit; }
            set { this.krit = value; }
        }
        public int Speed {
            get { return this.speed; }
            set { this.speed = value; }
        }
        public int Statichp {
            get{return this.hp;}
            set{this.hp = value ;}
        }
        public Player(){
            
            for(int i=0;i<timeStatus.Length;i++){
                timeStatus[i]=0;
            }
        }
        public Player(string name)
        {
            for(int i=0;i<timeStatus.Length;i++){
                timeStatus[i]=0;
            }
            Name = name; Hp = 220; Dmg = 10;
            System.Console.WriteLine($"{Name} has been created");
        }
        public void SetValues(string name, int hp, int dmg){
            System.Console.WriteLine("Введите  name, hp, dmg ");
            this.name = System.Console.ReadLine();
            this.hp = Convert.ToInt32(System.Console.ReadLine());
            this.dmg = Convert.ToInt32(System.Console.ReadLine());
        }
        public virtual void PrintValues()
        {
            Console.WriteLine($"0 = моб {Name} Hp:{Hp} Dmg:{Dmg} Krit chance:{Krit}% Speed:{Speed}");
        }
        public virtual void Step(List<Player> Team1, List<Player> Team2, Player F){ //  STEP
            for(int i=0;i<timeStatus.Length;i++){
                timeStatus[i]--;
            }
            F.Attack (F, Team2[0], Team2);
            //if(Team2[0].Hp <=0){Program.Red($"{Team2[0].Name} #DEAD#  /  ");Team2.Remove(Team2[0]);}
        }
        public virtual void Attack(Player A, Player B, List<Player> Team2){
            Random rand = new Random(); int uron = A.Dmg + rand.Next(-1,2);
            if (rand.Next(0, 100) < Krit)
            {
                uron = (A.Dmg + rand.Next(-1, 2)) * 2; System.Console.Write("KRIT! ");
            }
            B.Takedmg (A, B, Team2, uron);
        }
        public virtual void Takedmg(Player A, Player B, List<Player> Team2, int uron){
            B.Hp = B.Hp - uron;System.Console.Write($"{A.Name} нанес {uron} {B.Name}  /  "); 
            if(B.Hp <= 0){Program.Red($"{B.Name} #DEAD# / ");Team2.Remove(B);}
        }
    }
}            