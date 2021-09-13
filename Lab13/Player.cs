using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab13
{
    public enum RPS
    {
        rock,
        paper,
        scissors
    }

    abstract class Player
    {
        public abstract string Name { get; set; }
        public abstract RPS GenerateRPS();
    }

    class RockPlayer : Player
    {
        public override string Name { get; set; }

        public RockPlayer()
        {
            string rockName = "Liverpool";
            this.Name = rockName;
        }
        public override RPS GenerateRPS()
        {
            return RPS.rock;
        }
    }

    class RandomPlayer : Player
    {
        public override string Name { get; set; }

        public RandomPlayer()
        {
            string randomName = "Arsenal";
            this.Name = randomName;

        }
        public override RPS GenerateRPS()
        {

            var rand = new Random();
            var randomChoiceEnum = (RPS)rand.Next(0, 3);
            return randomChoiceEnum;
        }
    }


    class HumanPlayer : Player
    {
        public string UserInput { get; set; }
        public RPS playerRPSChoice { get; set; }
        public override string Name { get; set; }

        public HumanPlayer()
        {
            Console.Write("Enter your name: ");
            var userName = Console.ReadLine();
            this.Name = userName;
        }

        public override RPS GenerateRPS()
        {



            //while (!validateSelection())
            //{
            //    Console.WriteLine("Invalid Input");
            //    break;

            //}

            while (UserInput != "R" || UserInput != "P" || UserInput != "S")
            {
                Console.Write("Rock, paper, or scissors? (R/P/S): ");
                UserInput = Console.ReadLine().ToUpper();


                if (UserInput != "R" && UserInput != "P" && UserInput != "S")
                {
                    Console.WriteLine("Invalid Input");
                }
                else
                {
                    break;
                }

            }

            switch (UserInput)
            {
                case "R":
                    playerRPSChoice = RPS.rock;
                    break;
                case "P":
                    playerRPSChoice = RPS.paper;
                    break;
                case "S":
                    playerRPSChoice = RPS.scissors;
                    break;

            }


            return playerRPSChoice;
        }

    }
        //    private bool validateSelection()
        //    {
        //        if (UserInput != "R" && UserInput != "P" && UserInput != "S")
        //            return false;

        //        return true;
        //    }
        //}

        public static class RPSApp
        {
            public static string Name { get; set; }

            public static void UserChooseOpponent()
            {
                var user = new HumanPlayer();
                RPS randChoice = 0;
                RPS rockChoice = 0;
                string answer = string.Empty;
                string opponentChoice = string.Empty;



                while (opponentChoice != "A" || opponentChoice != "L")
                {
                    Console.Write($"Would you like to play against Arsenal or Liverpool (A/L)?: ");
                    opponentChoice = Console.ReadLine().ToUpper();

                    if (opponentChoice != "A" && opponentChoice != "L")
                    {
                        Console.WriteLine("Invalid Input");
                    }
                    else
                    {
                        break;
                    }
                }


                do
                {

                    user.GenerateRPS();
                    Console.WriteLine($"{user.Name}: {user.playerRPSChoice}");

                    if (opponentChoice == "A")
                    {
                        RandomPlayer rand = new RandomPlayer();
                        randChoice = rand.GenerateRPS();
                        Console.WriteLine($"{rand.Name}: {randChoice}");


                    }
                    else if (opponentChoice == "L")
                    {
                        RockPlayer rock = new RockPlayer();
                        rockChoice = rock.GenerateRPS();
                        Console.WriteLine($"{rock.Name}: {rock.GenerateRPS()}");

                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }

                    if (user.playerRPSChoice == RPS.rock && randChoice == RPS.paper)
                    {
                        Console.WriteLine($"Liverpool wins!");
                    }
                    else if (user.playerRPSChoice == RPS.paper && randChoice == RPS.rock)
                    {
                        Console.WriteLine($"{user.Name} wins!");
                    }
                    else if (user.playerRPSChoice == RPS.rock && randChoice == RPS.scissors)
                    {
                        Console.WriteLine($"{user.Name} wins!");
                    }
                    else if (user.playerRPSChoice == RPS.scissors && randChoice == RPS.rock)
                    {
                        Console.WriteLine($"Arsenal wins!");
                    }
                    else if (user.playerRPSChoice == RPS.paper && randChoice == RPS.scissors)
                    {
                        Console.WriteLine($"{user.Name} wins!");
                    }
                    else if (user.playerRPSChoice == RPS.scissors && randChoice == RPS.paper)
                    {
                        Console.WriteLine($"{user.Name} wins!");
                    }
                    else if (user.playerRPSChoice == RPS.scissors && rockChoice == RPS.rock)
                    {
                        Console.WriteLine($"{user.Name} wins!");
                    }
                    else if (user.playerRPSChoice == RPS.paper && rockChoice == RPS.rock)
                    {
                        Console.WriteLine($"{user.Name} wins!");
                    }
                    else
                    {
                        Console.WriteLine("Draw!");
                    }

                    Console.WriteLine("Play again? (y/n)");
                    answer = Console.ReadLine().ToUpper();
                    if (answer == "N")
                    {
                        break;
                    }

                } while (answer == "Y");


            }

        }

    }




