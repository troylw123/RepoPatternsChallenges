using Classes;

public class ProgramUI
{
    public MenuItemList _listOfMenuItems = new MenuItemList();

    public void Run(){
        SeedMenuItems();
        RunProgram();
    }

    public void RunProgram()
    {
        bool continueToRun = true;
        while (continueToRun)
        {
        Console.Clear();
        Console.WriteLine("Komodo Cafe Menu Management System \n What would you like to do? \n" +
        "1. View the entire menu\n"+
        "2. Add an item to the menu\n"+
        "3. Delete an existing menu item\n"+
        "4. Exit the program");

        string userChoice = Console.ReadLine()!;

        switch(userChoice){
            case "1":
            ShowCompleteMenu();
            break;
            case "2":
            AppendItemToMenu();
            break;
            case "3":
            DeleteItemFromMenu();
            break;
            case "4":
            continueToRun = false;
            break;
            default:
            Console.WriteLine("Please Enter a Valid Number between 1 and 4.\n"+
            "Press any key to continue........");
            Console.ReadKey();
            break;
            }
        }
    }

    public void ShowCompleteMenu(){
        Console.Clear();
        List<MenuItem> listOfItems = _listOfMenuItems.ReadMenu(); 

        foreach (MenuItem item in listOfItems){
            DisplayItem(item);
        }

        Console.WriteLine("Press any key to continue................");
        Console.ReadKey();
    }
    
    public void AppendItemToMenu(){
        Console.Clear();

        MenuItem item = new MenuItem();
        Console.WriteLine("Name of the meal: ");
        item.Name = Console.ReadLine();

        Console.WriteLine("Descritpion of the meal: ");
        item.Description = Console.ReadLine();

        Console.WriteLine("Price of the meal: ");
        item.Price = double.Parse(Console.ReadLine());

        Console.WriteLine("Meal Number: ");
        item.MealNumber = int.Parse(Console.ReadLine());

        
        Console.WriteLine("Please list all the ingredients needed: ");
        item.Ingredients = Console.ReadLine();
    
    _listOfMenuItems.AddItemToMenu(item);
    }

    public void DeleteItemFromMenu(){
        Console.Clear();
     
        List<MenuItem> listOfMenuItems = _listOfMenuItems.ReadMenu();

        Console.WriteLine("What is the meal number you would like to delete?");
        int mealToDelete = int.Parse(Console.ReadLine());
        // int startingCount = _fullmenu.Count();
        MenuItem item = _listOfMenuItems.GetMealByNumber(mealToDelete);
        if (item != null)
            {
                _listOfMenuItems.DeleteMenuItem(item);
                Console.WriteLine($"Meal number {mealToDelete} was deleted.");
            }
        else Console.WriteLine($"Meal number {mealToDelete} not found.");      

        Console.WriteLine("Press any key to continue................");
        Console.ReadKey();
    }

    public void DisplayItem(MenuItem item){
     
    Console.WriteLine($"Meal Number: {item.MealNumber}\n"+
    $"Meal Name: {item.Name}\n"+
    $"Description: {item.Description}\n"+
    $"Price: {item.Price:C2}\n"+
    $"Ingredients: {item.Ingredients}\n");
}
    


    public void SeedMenuItems(){

        MenuItem chicagoStyleDog = new MenuItem ("Chicago Style Hot Dog", "hot dog with all the fixins", 1, 3.99, "Lettuce, Tomato, Onion, Pickle, Ketchup, and Mustard");
        _listOfMenuItems.AddItemToMenu(chicagoStyleDog);
        MenuItem chiliDog = new MenuItem ("Chili Cheese Dog", "Hot dog with Chili and Cheese", 2, 4.50, "chili, cheese, and onions");
        _listOfMenuItems.AddItemToMenu(chiliDog);
        
    }
}
