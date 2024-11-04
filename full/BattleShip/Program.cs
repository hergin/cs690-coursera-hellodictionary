namespace BattleShip;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to simple BattleShip Game!");

        Board game = new Board();

        string userInput;
        do
        {
            Console.WriteLine("Enter a slot number from 0 to 9 (game continues until you sink all the ships): ");
            userInput = Console.ReadLine();
            int slot = int.Parse(userInput);
            bool resultOfTheMove = game.Shoot(slot);
            if (resultOfTheMove == true)
            {
                Console.WriteLine("You shot a ship part!");
            }
            else
            {
                Console.WriteLine("You missed!");
            }
        } while (!game.IsGameFInished());

        Console.WriteLine("Game is finished! You shot the ship!");
    }
}

public class Board
{
    public Dictionary<string, string> allSlots { get; set; }
    public int NumberOfSlots = 10;

    public Board()
    {
        allSlots = new Dictionary<string, string>();

        // initialize all slots with no ships
        for (int i = 0; i < NumberOfSlots; i++)
        {
            allSlots.Add("slot" + i, "no ship");
        }

        // add ships from 3 to 5
        allSlots["slot3"] = "ship";
        allSlots["slot4"] = "ship";
        allSlots["slot5"] = "ship";
    }

    /// <summary>
    /// This is to initialize the board with a ship from a parameter
    /// </summary>
    /// <param name="shipSlots">the numbers that will have a ship</param>
    public Board(List<int> shipSlots)
    {
        allSlots = new Dictionary<string, string>();

        // initialize all slots with no ships
        for (int i = 0; i < NumberOfSlots; i++)
        {
            allSlots.Add("slot" + i, "no ship");
        }

        // add ship parts to the numbers in the list parameter
        foreach (var number in shipSlots)
        {
            allSlots["slot" + number] = "ship";
        }
    }

    /// <summary>
    /// Check whether there is a ship at the given slot.
    /// </summary>
    /// <param name="slot"></param>
    /// <returns>true if there is a ship; false otherwise</returns>
    public bool IsThereAShip(int slot)
    {
        if (allSlots.ContainsKey("slot" + slot) && allSlots["slot" + slot] == "ship")
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Send a bomb to the board. If there is a ship at the slot, change the slot to something else like "ship shot".
    /// </summary>
    /// <param name="slot"></param>
    /// <returns>true if a ship is shot; false otherwise</returns>
    public bool Shoot(int slot)
    {
        if (IsThereAShip(slot))
        {
            allSlots["slot" + slot] = "ship shot";
            return true;
        }
        return false;
    }

    /// <summary>
    /// Return the count of slots that has "ship"
    /// </summary>
    /// <returns></returns>
    public int NumberOfShipsLeft()
    {
        int count = 0;
        for (int i = 0; i < NumberOfSlots; i++)
        {
            if (allSlots["slot" + i] == "ship")
            {
                count = count + 1;
            }
        }
        return count;
    }

    /// <summary>
    /// Check if all the ship slots are shot!
    /// </summary>
    /// <returns>true if there are no "ship" slots; false otherwise</returns>
    public bool IsGameFInished()
    {
        for (int i = 0; i < NumberOfSlots; i++)
        {
            if (allSlots["slot" + i] == "ship")
            {
                return false;
            }
        }
        return true;
    }
}