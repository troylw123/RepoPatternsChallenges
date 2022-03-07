using BadgeClass;

class ProgramUI
{
    BadgeRepository _badgeRepository = new BadgeRepository();

    public void RunMenu()
    {
        bool whileRunning = true;
        while (whileRunning)
        {
            Console.Clear();
            Console.Write("Komodo Insurance Company \n" +
            "1. Create a new badge \n" +
            "2. Edit an existing badge \n" +
            "3. View all badges \n" +
            "4. Exit the program \n" +
            "Please select an option from above: ");

            int selection = Convert.ToInt32(Console.ReadLine()!);

            switch (selection)
            {
                case 1:
                    CreateNewBadge();
                    break;
                case 2:
                    EditBadge();
                    break;
                case 3:
                    DisplayAllBadges();
                    PressAnyKey();
                    break;
                case 4:
                    whileRunning = false;
                    break;
                default:
                    Console.WriteLine("Please enter a number 1 through 4.");
                    PressAnyKey();
                    break;
            }

        }
    }

    public void CreateNewBadge()
    {
        Console.Clear();
        bool keepRunning = true;
        while(keepRunning)
        {
        Console.Write("Enter the new badge number: ");
        Badge badge = new Badge();
        int newBadgeID;
        bool isInteger = int.TryParse(Console.ReadLine()!, out newBadgeID);
        if (isInteger)
        {
        badge.BadgeID = newBadgeID;
        badge.AccessDoors = new List<string>();
        PromptAddDoors(badge.AccessDoors);
        _badgeRepository.AddToDictionary(badge);
        keepRunning = false;
        }
        else Console.WriteLine("Badge number must be an integer.");
        }
    }

    public void PromptAddDoors(List<string> doors)
    {
        Console.Write("Do you want to add a door? Y or N: ");
        string response = Console.ReadLine()!.ToLower();

        while (response == "y")
        {
            Console.Write("Enter the door name: ");
            string doorToAdd = Console.ReadLine()!.ToUpper();
            doors.Add(doorToAdd);
            Console.WriteLine($"Access to door {doorToAdd} was added.");
            Console.Write("Do you want to add another door? Y or N: ");
            response = Console.ReadLine()!.ToLower();
        }
    }

    public void EditBadge()
    {   
            bool keepRunning = true;
            while (keepRunning)
            {
            DisplayAllBadges();
            Console.Write("\n\nWhich badge number would you like to edit? ");
            int badgeToEdit;
            bool isInteger = int.TryParse(Console.ReadLine()!, out badgeToEdit);
            if (isInteger)
            {
            bool foundBadge = false;
            foreach (var badge in _badgeRepository.GetBadges())
                {
                if (badge.Key == badgeToEdit)
                {
                    foundBadge = true;
                    PromptEditOptions(badgeToEdit);
                    keepRunning = false;
                }
                }
                if (foundBadge == false)
                {
                    Console.WriteLine("Badge number not found.");
                    PressAnyKey();
                }
            }
            else 
            {
            Console.WriteLine("Please enter a number.");
            PressAnyKey();
            }
    }
    }

    public void DisplaySingleBadge(int badgeToDisplay){
        Console.Clear();
        var badge = _badgeRepository.GetBadgeByID(badgeToDisplay);
        Console.WriteLine($"Doors availabe to badge # {badgeToDisplay}\n");
        badge.ForEach(Console.WriteLine);
        Console.WriteLine("");

    }

    public void PromptEditOptions(int badgeToEdit)
    {
        bool keepRunning = true;
        while(keepRunning)
        {
        Console.Clear();
        DisplaySingleBadge(badgeToEdit);
        Console.WriteLine("What would you like to do?\n"+
        "1. Add a door\n"+
        "2. Remove a door\n"+
        "3. Remove all doors\n"+
        "4. Return to the main menu");
        string response = Console.ReadLine()!;
        switch(response){
            case "1":
            AddDoor(badgeToEdit);
            break;
            case "2":
            RemoveDoor(badgeToEdit);
            break;
            case "3":
            RemoveAllDoors(badgeToEdit);
            keepRunning = false;
            break;
            case "4":
            keepRunning = false;
            break;
            default:
            Console.WriteLine("Invalid Response");
            PressAnyKey();
            break;
        }
        }       
    }

public void AddDoor(int badgeToEdit){
    Console.Write("Name of door to add: ");
    string response = Console.ReadLine()!.ToUpper();
    var badge = _badgeRepository.GetBadgeByID(badgeToEdit);
    badge.Add(response);
    Console.WriteLine($"Door {response} successfully added.");
    PressAnyKey();
}

public void RemoveDoor(int badgeToEdit){
    Console.Write("Name of door to remove: ");
    string response = Console.ReadLine()!.ToUpper();
    var badge = _badgeRepository.GetBadgeByID(badgeToEdit);
    if (badge.Contains(response)){
    badge.Remove(response);
    Console.WriteLine($"Door {response} successfully removed.");
    }
    else Console.WriteLine("Door not found.");
    PressAnyKey();
}

public void RemoveAllDoors(int badgeToEdit){
    var badge = _badgeRepository.GetBadgeByID(badgeToEdit);
    badge.Clear();
    Console.WriteLine("All doors removed.");
    PressAnyKey();
}

    public async void DisplayAllBadges()
    {
        Console.Clear();
        Console.WriteLine("Badge #       Door Access \n" +
        "_______       ___________");


        foreach (var badge in _badgeRepository.GetBadges())
        {
            Console.Write($"\n{badge.Key}           ");
            foreach (string door in badge.Value)
            {
                Console.Write(door + " ");
            }
        }
    }

    public void PressAnyKey()
    {
        System.Console.WriteLine("\n\nPress any key to continue");
        Console.ReadKey();
    }

    public void SeedDictionary()
    {

        Badge seedOne = new Badge(1000, new List<string>() { "A1", "A2", "A3" });
        Badge seedTwo = new Badge(2000, new List<string>() { "B1", "B2", "B3" });
        Badge seedThree = new Badge(3000, new List<string>() { "C3", "C4", "C5" });
        Badge seedFour = new Badge(4000, new List<string>() { "D2", "D4" });
        Badge seedFive = new Badge(5000, new List<string>() { "E1", "E3", "E5", "E7" });

        _badgeRepository.AddToDictionary(seedOne);
        _badgeRepository.AddToDictionary(seedTwo);
        _badgeRepository.AddToDictionary(seedThree);
        _badgeRepository.AddToDictionary(seedFour);
        _badgeRepository.AddToDictionary(seedFive);
    }

}