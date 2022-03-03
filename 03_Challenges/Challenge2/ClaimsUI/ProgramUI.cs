using Claims;

class ProgramUI 
{
    private readonly ClaimRepository _claimRepo = new ClaimRepository();

    List<ClaimData> _claimDataList = new List<ClaimData>();
  
    public void RunMenu(){
        bool continueToRun = true;
        while (continueToRun)
        {
            Console.Clear();
            Console.WriteLine("Please select from the following options: \n"+
            "1. See all claims \n"+
            "2. Handle a claim \n"+
            "3. Enter a new claim \n"+
            "4. Exit");

            string selection = Console.ReadLine()!;
            switch (selection)
            {
                case "1":
                DisplayAllClaims();
                break;
                case "2":
                HandleAClaim();
                break;
                case "3":
                EnterNewClaim();
                break;
                case "4":
                continueToRun = false;
                break;
                default: 
                System.Console.WriteLine("Please enter a valid # 1 through 4. \n");
                PressAnyKey();
                break;
            }
        }
    }

    public void DisplayAllClaims(){
        Console.Clear();
        List<ClaimData> listOfClaimData = _claimRepo.DisplayClaims();
        Console.WriteLine("ClaimID    Type     Description \n"+
        "___________________________________________________________\n");
        foreach (ClaimData claim in listOfClaimData)
        {
            ShowClaimList(claim);
        }
        PressAnyKey();
    }

    public void ShowClaimList(ClaimData claim)
    {
        Console.WriteLine($"{claim.ClaimID}          {claim.TypeOfClaim}        {claim.Description}\n");
    }

    public void HandleAClaim(){
        Console.Clear();
        System.Console.Write("Enter the claim ID: ");
        int selection = int.Parse(Console.ReadLine()!);
        ClaimData claim = _claimRepo.GetClaimByID(selection);
        ShowSingleClaim(claim);
    }

    public void ShowSingleClaim(ClaimData claim){
        Console.Clear();
        Console.WriteLine($"ClaimID:  {claim.ClaimID}\n"+
        $"Claim Type:  {claim.TypeOfClaim}\n"+
        $"Description:  {claim.Description}\n"+
        $"Amount:  {claim.ClaimAmount}\n"+
        $"Incident Date:  {claim.DateOfIncident}\n"+
        $"Valid Claim:  {claim.IsValid} \n");
        HandleClaimMenu(claim);
    }

    public void HandleClaimMenu(ClaimData claim){
        Console.WriteLine("Press Y to move to the next claim \n"+
        "Press N to return to the main menu");
        string selection = Console.ReadLine()!.ToLower();
        int currentClaimID = claim.ClaimID;
        List<ClaimData> listOfClaimData = _claimRepo.DisplayClaims();
        int numberOfClaims = listOfClaimData.Count;
        if (selection == "y" && currentClaimID < numberOfClaims){

                ClaimData nextclaim = _claimRepo.GetClaimByID(currentClaimID+1);
                ShowSingleClaim(nextclaim);
                }
                else if (selection == "y"){
                    Console.WriteLine("This is the last claim in the queue.");
                    PressAnyKey();
                }
            }
        
    

    public void EnterNewClaim(){
        Console.Clear();
        ClaimData claim = new ClaimData();
        
        Console.Write("Select Claim Type: \n"+
        "1. Car \n"+
        "2. Home \n"+
        "3. Theft \n");
        int selection = int.Parse(Console.ReadLine()!);

        if (selection < 4){
        claim.TypeOfClaim = (ClaimData.ClaimType)selection-1;
        }
        else {
        Console.WriteLine("Please enter 1, 2 or 3.");
        PressAnyKey();
        }

        Console.Write("Enter a description: ");
        claim.Description = Console.ReadLine()!;

        Console.Write("What is the total cost?: ");
        claim.ClaimAmount = double.Parse(Console.ReadLine()!);

        Console.Write("Date of Incident: MM/DD/YYYY \n");
        string date = Console.ReadLine()!;
        claim.DateOfIncident = DateTime.Parse(date);

        List<ClaimData> listOfClaimData = _claimRepo.DisplayClaims();
        claim.ClaimID = listOfClaimData.Count + 1;

        _claimRepo.AddClaimToList(claim);
    }

    public void SeedClaimList(){
        ClaimData troy = new ClaimData(1, ClaimData.ClaimType.Car, "Car Accident", 550.12, new DateTime(2020, 12, 12));
        ClaimData beth = new ClaimData(2, ClaimData.ClaimType.Car, "Wreck in her neighborhood", 961.33, DateTime.Today);
        ClaimData bryce = new ClaimData(3, ClaimData.ClaimType.Home, "Tornado ripped his roof off", 5660.79, DateTime.Now);
        _claimRepo.AddClaimToList(troy);
        _claimRepo.AddClaimToList(beth);
        _claimRepo.AddClaimToList(bryce);
    }

    public void PressAnyKey() {
        Console.WriteLine("Press any key to continue................");
        Console.ReadKey();
    }

    public void PrintMyInfo(){
        List<ClaimData> listOfClaimData = _claimRepo.DisplayClaims();
        Console.WriteLine(listOfClaimData.Count);
    }
}