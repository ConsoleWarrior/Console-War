using System;
using System.Collections.Generic;

//TODO 1.капа ХП 2. 2й герой   3. Переделать статусы. 4.Добавить моба Лучник/дебафер
//  
namespace Console_War
{
    class Program{
        public static void Main(){
            List<Player> Team1 = new List<Player>(); 
            List<Player> Team2 = new List<Player>(); 
            System.Console.WriteLine("                                                            НАЖИМАТЬ то что предлагают!!!");
            Player bot = new Player ("Бот"); bot.PrintValues();
            Player war = new Warior ("Варвар");war.PrintValues();
            Player hill = new Healer ("Хилер");hill.PrintValues();
            Player mage = new Mage ("Маг");mage.PrintValues();
            Player Uter = new Uter ("Утер"); Uter.PrintValues();
            Player Silvana = new Silvana ("Сильвана"); Silvana.PrintValues();

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
                        case 0: Team.Add(new Player( "T"+ teamnumber+ "Бот"+i)); break;
                        case 1: Team.Add(new Warior("T" + teamnumber + "Варвар"+i)); break;
                        case 2: Team.Add(new Healer("T" + teamnumber + "Хилер"+i)); break;
                        case 3: Team.Add(new Mage("T" + teamnumber + "Маг"+i)); break;
                        
                        case 4: Team.Add(new Uter ("T" + teamnumber + "*Утер*" )); break;
                        case 5: Team.Add(new Silvana ("T" + teamnumber + "*Сильвана*" )); break;
                    }
                }
            }
            void CreateTeamRandom(List<Player> Team, int teamnumber)
            {
                Random r = new Random();int botC=0, warC=0, hilC=0, magC=0;
                for (int i = 0; i < size; i++)
                {
                    switch (r.Next(0, 4))
                    {
                        case 0: Team.Add(new Player("T" + teamnumber + "Бот" + i));botC++; break;
                        case 1: Team.Add(new Warior("T" + teamnumber + "Варвар" + i));warC++; break;
                        case 2: Team.Add(new Healer("T" + teamnumber + "Хилер" + i));hilC++; break;
                        case 3: Team.Add(new Mage("T" + teamnumber + "Маг" + i));magC++; break; 
                    }
                }
                Green($"Ботов:{botC} Варваров:{warC} Хилеров:{hilC} Магов:{magC}");
            }
            int turn = 0; War(Team1, Team2);

            void War (List<Player> Team1, List<Player> Team2)
            {
                Console.WriteLine("                     FIGHT!"); 
                while (Team1.Count > 0 && Team2.Count > 0)  // Основной цикл ходов
                {
                    turn++; Random r = new Random();
                    Console.WriteLine(turn+"й ХОД              "+Team1.Count + "  /  " + Team2.Count);
                    for (int i = 0; i < 10; i++)    // Цикл очередности хода
                    {
                        try {
                            if (r.Next(0, 2) == 1)
                            {
                                foreach (Player F in Team1)
                                {
                                    if (F.Speed == i)
                                        F.Step(Team1, Team2, F);
                                }
                                foreach (Player F in Team2)
                                {
                                    if (F.Speed == i)
                                        F.Step(Team2, Team1, F);
                                }
                            }
                            else
                            {
                                foreach (Player F in Team2)
                                {
                                    if (F.Speed == i)
                                        F.Step(Team2, Team1, F);
                                }
                                foreach (Player F in Team1)
                                {
                                    if (F.Speed == i)
                                        F.Step(Team1, Team2, F);
                                }
                            }
                        }
                        catch (System.ArgumentOutOfRangeException){}
                    }
                    System.Console.WriteLine();
                    if(Team1.Count > 0 && Team2.Count > 0)Program.Green($"Авангард: {Team1[0].Name}: {Team1[0].Hp}хп    {Team2[0].Name}: {Team2[0].Hp}хп");
                    System.Console.WriteLine();
                }
                System.Console.WriteLine();
                Console.WriteLine("                     "+Team1.Count + "  /  " + Team2.Count);
                if (Team1.Count <= 0 && Team2.Count > 0) System.Console.WriteLine("                    Team2 WIN !!!");
                if (Team2.Count <= 0 && Team1.Count > 0) System.Console.WriteLine("                    Team1 WIN !!!");
                if (Team1.Count <= 0 && Team2.Count  <= 0) System.Console.WriteLine("                     Ничья");
            }
            Console.ReadKey();
        }
        public static void Red(string warning)
        {
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.Write(warning);
            Console.ResetColor(); 
        } 
        public static void Green(string warning)
        {
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.Write(warning);
            Console.ResetColor(); 
        } 
        public static void Blue(string warning)
        {
            Console.ForegroundColor = ConsoleColor.Blue; 
            Console.Write(warning);
            Console.ResetColor(); 
        } 
    }
}            