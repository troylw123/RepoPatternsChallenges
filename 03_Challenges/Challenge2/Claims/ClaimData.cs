namespace Claims;
public class ClaimData
{
    public int ClaimID {get; set;}
    public ClaimType TypeOfClaim {get; set;}
    public string? Description {get; set;}
    public double ClaimAmount {get; set;}
    public DateTime DateOfIncident { get; set; }
    // public DateTime DateOfClaim { get; set;}
    public bool IsValid {
        get {
        TimeSpan timePassed = DateTime.Now - DateOfIncident;
        double timeInDays = timePassed.TotalDays;
        return (timeInDays < 30);
        }
    }
    public enum ClaimType { Car, Home, Theft }

    public ClaimData(){}

    public ClaimData(int claimID, ClaimType typeOfClaim, string description, double claimAmount, DateTime dateOfIncident)
    {
        ClaimID = claimID;
        TypeOfClaim = typeOfClaim;
        Description = description;
        ClaimAmount = claimAmount; 
        DateOfIncident = dateOfIncident;
        // DateOfClaim = dateOfClaim;
        // IsValid = isValid;
    }
}
