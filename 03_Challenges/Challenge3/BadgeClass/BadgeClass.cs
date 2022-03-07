namespace BadgeClass;

public class Badge 
{
    public int BadgeID {get; set;}
    public List<string> AccessDoors {get; set;}
    // public string AccessDoorsAsString()
    // {
    //     string result = "";
    //     foreach (var door in this.AccessDoors)
    //     {
    //         result += door.Name + " ";
    //     }
    //     return result;
    // }

    public Badge (){}

    public Badge (int badgeID, List<string> accessDoors)
    {
        this.BadgeID = badgeID;
        this.AccessDoors = accessDoors;
    }
}



