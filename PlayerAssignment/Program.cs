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

        }

       
        static void Main(string[] args)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$"; //E-mail pattern to check for invalids
          
            Console.WriteLine("Enter the number of players");
            int plNum = Int32.Parse(Console.ReadLine());
            Player[] players = new Player[plNum];

            for(int i = 0; i<plNum; i++) //Player inputs their information.
            {
                
                Console.WriteLine("Enter the data for Player " + (i + 1) + ", as prompted. \n Name:");
                players[i].Name = Console.ReadLine();
                Console.WriteLine("Age:");
                players[i].Age = Int32.Parse(Console.ReadLine());
                do {
                    Console.WriteLine("E-mail:");
                    players[i].Email = Console.ReadLine();
                }

                while (!Regex.IsMatch(players[i].Email,pattern));
                Console.WriteLine("valid");

            }

            Console.WriteLine("would you like to print the data? Press y+Enter for yes. If not, \n press another key+ Enter");
            if (Console.ReadKey().Equals('y'))
            {
                for (int i = 0; i < plNum; i++) //Placeholder until I figure out the delegates
                {
                    Console.WriteLine("Name: " + players[i].Name + "\nID:" + players[i].Id +
                        "\nAge:" + players[i].Age + "\nE-mail: " + players[i].Email);
                }
            }
        }
    }
  
}
