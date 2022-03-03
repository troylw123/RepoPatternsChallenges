namespace Classes;
public class MenuItem
{
    public string Name {get; set;}
    public string Description {get; set;}
    public int MealNumber {get; set;}
    public double Price {get; set;}
    public string Ingredients {get; set;}

    public MenuItem(){}
    public MenuItem (string name, string description, int mealNumber, double price, string ingredients){
        name = Name;
        description = Description;
        mealNumber = MealNumber;
        price = Price;
        ingredients = Ingredients;
    }
}
