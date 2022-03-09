namespace OutingClass;
public class Outing
{
    public enum EventType {Golf, Bowling, Amusement, Concert}

    public EventType TypeOfOuting {get; set;} 
    public int NumberAttended {get; set;} 
    public DateTime Date {get; set;} 
    public double PerPersonCost {
        get {return TotalCost / NumberAttended;}
    } 
    public double TotalCost {get; set;} 

    


public Outing (){}
public Outing(EventType typeOfOuting, int numberAttended, DateTime date, double totalCost)
{
    TypeOfOuting = typeOfOuting;
    NumberAttended = numberAttended;
    Date = date;
    TotalCost = totalCost;
}

}