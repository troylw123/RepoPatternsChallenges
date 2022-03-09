using OutingClass;

public class ProgramUI
{
    private readonly OutingRepository _outingRepo = new OutingRepository();

    public void RunMenu()
    {
        bool keepRunning = true;
        while (keepRunning)
        {
            Console.Clear();
            Console.WriteLine("-- Welcome to the Komodo Outings Dashboard -- \n\n" +
            "1. Display a list of all outings. \n" +
            "2. Add a new outing. \n" +
            "3. Calculate the cost of all outings. \n" +
            "4. Calculate the cost of a specific type of outing. \n" +
            "5. Close the program. \n");
            Console.Write("Please choose an option from above:  ");

            string response = Console.ReadLine()!;
            switch (response)
            {
                case "1":
                ShowAllOutings();
                break;
                case "2":
                AddNewOuting();
                break;
                case "3":
                DisplayTotalCost();
                break;
                case "4":
                DisplayCostByType();
                break;
                case "5": 
                keepRunning = false;
                break;
                default:
                Console.WriteLine("Select a valid option from the menu.");
                PressAny();
                break;
            }

        }
    }

    public void ShowAllOutings() {
        Console.Clear();
        List<Outing> OutingList = _outingRepo.GetOutingList();
        
        Console.Write("Event Type:       ");
        foreach (Outing outing in OutingList)
        {Console.Write($"        {outing.TypeOfOuting}");}
        
        Console.Write("\nDate:             ");
        foreach (Outing outing in OutingList)
        {Console.Write($"     {outing.Date.ToString("MM/dd/yyyy")}");}

        Console.Write("\nNumber Attendees:");
        foreach (Outing outing in OutingList)
        {Console.Write($"           {outing.NumberAttended}");}

        Console.Write("\nCost Per Person: ");
        foreach (Outing outing in OutingList)
        {Console.Write($"         {outing.PerPersonCost:C2}");}

        Console.Write("\nTotal Cost        ");
        foreach (Outing outing in OutingList)
        {Console.Write($"      {outing.TotalCost:C2}");}
        Console.WriteLine("");
        
        PressAny();
    }

    public void AddNewOuting() {}
    public void DisplayTotalCost() {

    }
    public void DisplayCostByType(){}

    public void PressAny(){
        Console.WriteLine("\nPress any key to continue ~");
        Console.ReadKey();
    }

    public void SeedOutings()
    {
        Outing golf = new Outing((Outing.EventType)0, 200, new DateTime(2022, 07, 04), 5000);
        Outing bowling = new Outing((Outing.EventType)1, 100, DateTime.Now, 1500);
        Outing park = new Outing((Outing.EventType)2, 350, new DateTime(2020, 03, 15), 100);
        Outing concert = new Outing((Outing.EventType)3, 2500, new DateTime(2021, 09, 10), 7500);
        _outingRepo.AddOutingToList(golf);
        _outingRepo.AddOutingToList(bowling);
        _outingRepo.AddOutingToList(park);
        _outingRepo.AddOutingToList(concert);
    }
}
