using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PlayerAssignment
{

    class Program
    {
        public interface IPlayer
        {
            Guid Id { get; }
            string Name { get; set;}
            string Email { get; set; }

        }

        public class Player : IPlayer
        {
            private readonly Guid _id = Guid.NewGuid();
            private string _name = "";
            private int _age;
            private string _email = "";
            public Guid Id { get { return _id; } }

            public string Name { get { return _name; } set { _name = value; } }
            public int Age { get { return _age; } set { _age = value; } }
            public string Email { get { return _email; } set { _email = value; } }

            public delegate void PrintPlayerInfo(Player p);
            public Player() { }
            public Player(string name, int age, string mail)
            {
                Name = name;
                Age = age;
                Email = mail;
            }

            public void Print(PrintPlayerInfo printPlayer, Player player)
            {
                printPlayer(player);
            }

        }

       
        static void Main(string[] args)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$"; //E-mail pattern to check for invalids
          
            Console.WriteLine("Enter the number of players");
            int plNum = Int32.Parse(Console.ReadLine());
            Player[] players = new Player[plNum];

            for(int i = 0; i<plNum; i++) //Player inputs their information.
            {
                players[i] = new Player();

                Console.WriteLine("Enter the data for Player " + (i + 1) + ", as prompted. \n Name: ");
                players[i].Name = Console.ReadLine();
                Console.WriteLine("Age:");
                players[i].Age = Int32.Parse(Console.ReadLine());
                do {                                  //Checks to see if the e-mail entered is valid.
                    Console.WriteLine("E-mail:");
                    players[i].Email = Console.ReadLine();

                    if (!Regex.IsMatch(players[i].Email, pattern))
                        Console.Write("VALID E-mail, you blockhead.");
                }
                while (!Regex.IsMatch(players[i].Email,pattern));

            }

            Console.WriteLine("would you like to print the data? Press y for yes. If not, \n press another key+ Enter");
            if (Console.ReadKey().Equals('y'))
            {
                for (int i = 0; i < plNum; i++) //Prints out all of the information for each player.
                {
                    players[i].Print(PrintPlayerNameIdMail, players[i]);
                    Console.WriteLine("\n");
                }
            }

        }

        private static void PrintPlayerNameIdMail(Player pl)
        {
            Console.WriteLine($"player name is: {pl.Name}");
            Console.WriteLine($"player id is: {pl.Id}");
            Console.WriteLine($"player e-Mail is: {pl.Email}");
        }
    }
  
}
