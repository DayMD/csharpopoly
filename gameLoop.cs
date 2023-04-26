using System;
using System.Collections.Generic;
using System.Text;

namespace monopoly
{
    class gameLoop
    {
        List<player> play = new List<player>();
        List<board> b = new List<board>();
        List<string> chance = new List<string>();
        //populate board
        //populate players
        //iterare through players
        //roll
        //move
        //action

        public gameLoop(int numOfPlayers)
        {
            populateBoard(b);

            foreach (board bd in b)
            {
                Console.WriteLine(bd);
            }
            for (int i = 0; i <= 8; i++)
            {
                play.Add(new player(i.ToString(), 1500));
            }

            foreach (player p in play)
            {
                Console.WriteLine(p);
                int moveAmount =  rollDice(p.position, p); //roll Behaviour. Notes help keep track of work
                move(moveAmount, p);
                //squareHandling(b[p.position], p);
            }
        }

        private int rollDice(int playerPos, player p)
        {
            int doubles = 0;
            (int, int) die = diceroll();
            int total = die.Item1 + die.Item2;
            Console.WriteLine("roll: " + die.Item1 + " " + die.Item2);
            doubles += 1;
            while (doubles > 0)
            {
                if (doubles == 0)
                {
                    Console.WriteLine("Doubles!");
                }
                if (doubles == 1)
                {
                    Console.WriteLine("Doubles! Be careful, only one last chance");
                }
                if (doubles == 2)
                {
                    Console.WriteLine("Doubles! Three doubles, prison.");
                    p.inPrison = true;
                }

            }
            return total;
        }

        private void move(int movAmount, player p)
        {
            p.position += movAmount;

            if (p.position > b.Count)
            {
                p.position -= b.Count;
            }
            Console.WriteLine(p.position);
            Console.WriteLine(b[p.position]);
            squareHandling(b[p.position], p);
        }

        private (int, int) diceroll()
        {
            var rand = new Random();
            int die1 = 0;
            int die2 = 0;
            die1 = rand.Next(1, 7);
            die2 = rand.Next(1, 7);

            return(die1, die2);
        }

        static void populateBoard(List<board> boardList)
        {
            //name, type, price, negative prices indicate player receives money. Zero means it cant be bought.
            boardList.Add(new board("go", "go", -200));
            boardList.Add(new board("Old Kent Road", "buy", 60));
            boardList.Add(new board("Community chest", "chest", 0));
            boardList.Add(new board("Whitechapel Road", "buy", 60));
            boardList.Add(new board("Income Tax", "pay", 200));
            boardList.Add(new board("Kings Cross Station", "station", 200));
            boardList.Add(new board("The Angel Islington", "buy", 100));
            boardList.Add(new board("Chance", "chance", 0));
            boardList.Add(new board("Euston Road", "buy", 100));
            boardList.Add(new board("Pentonville Road", "buy", 120));
            boardList.Add(new board("Jail", "visiting", 0));
            boardList.Add(new board("Pall Mall", "buy", 140));
            boardList.Add(new board("Electric Company", "utility", 150));
            boardList.Add(new board("Whitehall", "buy", 140));
            boardList.Add(new board("Northumberland Avenue", "buy", 160));
            boardList.Add(new board("Marylebone Station", "station", 200));
            boardList.Add(new board("Bow Street", "buy", 180));
            boardList.Add(new board("Community Chest", "chest", 0));
            boardList.Add(new board("Malborough Street", "buy", 180));
            boardList.Add(new board("Vine Street", "buy", 200));
            boardList.Add(new board("Free Parking", "free", 0));
            boardList.Add(new board("Strand", "buy", 220));
            boardList.Add(new board("Chance", "chance", 0));
            boardList.Add(new board("Fleet Street", "buy", 220));
            boardList.Add(new board("Trafalgar Square", "buy", 240));
            boardList.Add(new board("Fenchurch Street Station", "station", 200));
            boardList.Add(new board("Leicester Square", "buy", 260));
            boardList.Add(new board("Coventry Street", "buy", 260));
            boardList.Add(new board("Water Works", "utility", 150));
            boardList.Add(new board("Piccadilly", "buy", 280));
            boardList.Add(new board("Go To Jail", "jail", 0));
            boardList.Add(new board("Regent Street", "buy", 300));
            boardList.Add(new board("Oxford Street", "buy", 300));
            boardList.Add(new board("Community Chest", "chest", 0));
            boardList.Add(new board("Bond Street", "buy", 320));
            boardList.Add(new board("Liverpool Street Station", "station", 200));
            boardList.Add(new board("Chance", "chance", 0));
            boardList.Add(new board("Park Lane", "buy", 350));
            boardList.Add(new board("Super Tax", "pay", 100));
            boardList.Add(new board("Mayfair", "buy", 400));
        }

        private void squareHandling(board locIn, player p)
        {
            string type = locIn.sqType;
            Console.WriteLine(locIn.sqType);

            switch (type)
            {
                case "buy":
                    if (locIn.owned == false)
                    {
                        while(true)
                        {
                            Console.WriteLine("Unowned Property, purchase? Y/N");
                            string selection = Console.ReadLine();
                            if (selection == "y")
                            {
                                Console.WriteLine("Property Bought");
                                locIn.owned = true;
                                locIn.owner = p.name;
                                p.money -= locIn.price;
                                break;
                            }
                            if (selection == "n")
                            {
                                Console.WriteLine("property Skipped");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Error: Unrecognised value, please enter 'y' or 'n'");
                            }
                        }
                    }
                    else if (locIn.owned == true)
                    {
                        Console.WriteLine("Landed on property owned by " + locIn.owner + " paying them " + locIn.price);
                        p.money -= locIn.price;
                        //need to get the current squares owner and give them money.
                        //TODO: Keep list of landed on owned squares, get owners name and compare to each user per turn, if they match then they paid
                        //TODO: Anything BUT above.
                    }
                    else
                    {
                        Console.WriteLine("Error with 'buy square handling.'");
                    }
                        break;
                case "Go":
                    p.money -= locIn.price; //Because go subtracts money
                    break;
                case "chest":
                    break;
                case "station":
                    break;
                case "visiting":
                    break;
                case "Jail":
                    break;
                case "pay":
                    break;
                case "chance":
                    break;
                case "utility": //Allows for other options, like multi layered boards or fast travel or similar.
                    break;
                case "free":
                    Console.WriteLine("Free square");
                    break;
                default:
                    Console.WriteLine("Error: Unknown square " + locIn + ". Treating as free square");
                    break;

            }
        }
    }
}
