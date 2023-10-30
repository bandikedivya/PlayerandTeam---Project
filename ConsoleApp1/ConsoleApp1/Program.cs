using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OneDayTeam team = new OneDayTeam();
            string continueOp;
            do
            {
                try
                {
                    Console.WriteLine("Enter your option:\n1: To Add Player\n2: To Remove Player by Id\n3: Get Player By Id\n4: Get Player by Name\n5: Get All Players");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Player Id: ");
                            int playerId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Player Name: ");
                            string playerName = Console.ReadLine();
                            Console.Write("Enter Player Age: ");
                            int playerAge = int.Parse(Console.ReadLine());

                            Player newPlayer = new Player { PlayerId = playerId, PlayerName = playerName, PlayerAge = playerAge };
                            team.Add(newPlayer);
                            break;
                        case 2:
                            Console.Write("Enter Player Id to Remove: ");
                            int removePlayerId = int.Parse(Console.ReadLine());
                            team.Remove(removePlayerId);
                            break;
                        case 3:
                            Console.Write("Enter Player Id: ");
                            int searchPlayerId = int.Parse(Console.ReadLine());
                            Player foundPlayerById = team.GetPlayerById(searchPlayerId);
                            if (foundPlayerById != null)
                            {
                                Console.WriteLine($"{foundPlayerById.PlayerId}\t{foundPlayerById.PlayerName}\t{foundPlayerById.PlayerAge}");
                            }
                            else
                            {
                                Console.WriteLine("Player not found!");
                            }
                            break;
                        case 4:
                            Console.Write("Enter Player Name: ");
                            string searchPlayerName = Console.ReadLine();
                            Player foundPlayerByName = team.GetPlayerByName(searchPlayerName);
                            if (foundPlayerByName != null)
                            {
                                Console.WriteLine($"{foundPlayerByName.PlayerId}\t{foundPlayerByName.PlayerName}\t{foundPlayerByName.PlayerAge}");
                            }
                            else
                            {
                                Console.WriteLine("Player not found!!");
                            }
                            break;
                        case 5:
                            List<Player> allPlayers = team.GetAllPlayers();
                            foreach (var player in allPlayers)
                            {
                                Console.WriteLine($"{player.PlayerId}\t{player.PlayerName}\t{player.PlayerAge}");
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occured: " + ex.Message);
                }
                Console.Write("Do you want to continue? (Yes/No): ");
                continueOp = Console.ReadLine();
            } while (continueOp.ToLower() == "yes");
        }
    }
}
