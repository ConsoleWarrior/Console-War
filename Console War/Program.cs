using System;
using System.Collections.Generic;
namespace Console_War
{
    class Program{
        public static void Main(){
            List<Player> Team1 = new List<Player>(); 
            List<Player> Team2 = new List<Player>(); 

            Player bot = new Player ("Бот",200,8); bot.PrintValues();
            Player war = new Warior ("Варвар",125,8,50);war.PrintValues();
            Player hill = new Healer ("Хилер",125,8,15);hill.PrintValues();
            Player mage = new Mage ("Маг",110,10,30);mage.PrintValues();
            Player Anduin = new Anduin ("Андуин", 300, 20, 50); Anduin.PrintValues();

            Console.WriteLine(" Выберите размер 1й команды: ");
            int size = Convert.ToInt32 (Console.ReadLine());
            Console.WriteLine(" Как заполнить? 0 - вручную, 1 - рандомно мобами");
            int fill = Convert.ToInt32(Console.ReadLine());
            if(fill == 0) CreateTeam(Team1,1);
            if(fill == 1) CreateTeamRandom(Team1,1);

            Console.WriteLine(" Выберите размер 2й команды: ");
            size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" Как заполнить? 0 - вручную, 1 - рандомно мобами");
            fill = Convert.ToInt32(Console.ReadLine());
            if (fill == 0) CreateTeam(Team2, 2);
            if (fill == 1) CreateTeamRandom(Team2, 2);
            

            void CreateTeam(List<Player> Team, int teamnumber)
            {
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine("Выберите бойца на позицию:"+i);
                    int N = Convert.ToInt32(Console.ReadLine());
                    switch (N)
                    {
                        case 0: Team.Add(new Player( "T"+ teamnumber+ "Бот"+i, 200, 8)); break;
                        case 1: Team.Add(new Warior("T" + teamnumber + "Варвар"+i, 125, 8, 50)); break;
                        case 2: Team.Add(new Healer("T" + teamnumber + "Хилер"+i, 125, 8, 15)); break;
                        case 3: Team.Add(new Mage("T" + teamnumber + "Маг"+i, 110, 10, 30)); break;
                        
                        case 4: Team.Add(new Anduin ("T" + teamnumber + " Андуин" , 300, 20, 50)); break;
                    }
                }
            }
            void CreateTeamRandom(List<Player> Team, int teamnumber)
            {
                Random r = new Random();
                for (int i = 0; i < size; i++)
                {
                    //int index = r.Next(0, 4);
                    switch (r.Next(0, 4))
                    {
                        case 0: Team.Add(new Player("T" + teamnumber + "Бот" + i, 200, 8)); break;
                        case 1: Team.Add(new Warior("T" + teamnumber + "Варвар" + i, 125, 8, 50)); break;
                        case 2: Team.Add(new Healer("T" + teamnumber + "Хилер" + i, 125, 8, 15)); break;
                        case 3: Team.Add(new Mage("T" + teamnumber + "Маг" + i, 110, 10, 30)); break; 
                    }
                }
            }
            /*Player[] group = new Player[5];
            Random r = new Random();
            int index = r.Next(0, 3);
            switch (index)
            {
                case 0:
                    group[i] = new Mage("Маг " + i, 110, 10, 30); break;
                case 1:
                    group[i] = new Healer("Хилер " + i, 125, 8, 15); break;
                case 2:
                    group[i] = new Warior("Варвар " + i, 125, 8, 50); break;
            }*/

            /*for (int i = 0; i < 5; i++) {
                if (group[i].GetType().Name == "Mage")
                Console.WriteLine(group[i].Name + " is: " + group[i].GetType().Name);
            }

            Console.WriteLine("Выберите первого бойца: 1 - Бот, 2 - Варвар, 3 - Хилер, 4 -Маг");
            int fighter = Convert.ToInt32(Console.ReadLine());
            Player fighter1 = bot, fighter2 = bot;
            if (fighter == 1) fighter1 = bot;
            if (fighter == 2) fighter1 = war;
            if (fighter == 3) fighter1 = hill;
            if (fighter == 4) fighter1 = mage;
            Console.WriteLine("Выберите второго бойца: 1 - Бот, 2 - Варвар, 3 - Хилер, 4 -Маг");
            fighter = Convert.ToInt32(Console.ReadLine());
            if (fighter == 1) fighter2 = bot;
            if (fighter == 2) fighter2 = war;
            if (fighter == 3) fighter2 = hill;
            if (fighter == 4) fighter2 = mage;
            Team1.Add(bot);
            Team2.Add(mage);*/

            War(Team1, Team2);

            void War (List<Player> Team1, List<Player> Team2)
            {
                Console.WriteLine("                     FIGHT!");
                while (Team1.Count > 0 && Team2.Count > 0)
                {
                    Console.WriteLine(Team1.Count+"  /  "+ Team2.Count);
                    foreach (Player F in Team1)
                    {
                        F.Step(Team1,Team2,F);
                        
                    }
                    System.Console.WriteLine();
                    foreach (Player F in Team2)
                    {
                        F.Step(Team2,Team1,F);
                        
                    }
                    System.Console.WriteLine();
                    System.Console.Write(" Текущее хп " + Team1[0].Name + ":" + Team1[0].Hp);
                    System.Console.WriteLine(" / Текущее хп " + Team2[0].Name + ":" + Team2[0].Hp);

                    if (Team2[0].Hp <= 0) {
                        System.Console.WriteLine(Team2[0].Name+" погиб");Team2.Remove(Team2[0]);
                    }
                    if (Team1[0].Hp <= 0) {
                        System.Console.WriteLine(Team1[0].Name+" погиб");Team1.Remove(Team1[0]);
                    }
                }
                Console.WriteLine(Team1.Count + "  /  " + Team2.Count);
                if (Team1.Count <= 0 && Team2.Count > 0) System.Console.WriteLine(" Team2 WIN!!!");
                if (Team2.Count <= 0 && Team1.Count > 0) System.Console.WriteLine(" Team1 WIN!!!");
                if (Team1.Count <= 0 && Team2.Count  <= 0) System.Console.WriteLine("Ничья");
            }

            /*void Fight(Player F1, Player F2){
                    
                while(F1.Hp>0 && F2.Hp>0){
                    
                    F1.Hp = F1.Hp -F2.Step(F2);
                    F2.Hp = F2.Hp -F1.Step(F1);

                    System.Console.Write(" Текущее хп "+ F1.Name + ":" + F1.Hp);
                    System.Console.WriteLine(" / Текущее хп "+ F2.Name + ":" + F2.Hp);
                }
                if (F1.Hp<=-0 && F2.Hp>0)System.Console.WriteLine(" Победил "+ F2.Name + "!!!");
                if (F2.Hp<=0 && F1.Hp>0)System.Console.WriteLine(" Победил "+ F1.Name+"!!!");
                if (F1.Hp<=0 && F2.Hp<=0)System.Console.WriteLine("Ничья");
            }*/
            Console.ReadKey();
        }
    }
}            