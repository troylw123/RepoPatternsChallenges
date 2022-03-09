using StreamingContentRepo;
public class ProgramUI{
private readonly StreamingContentRepository _streamingRepo = new StreamingContentRepository();

public void Run(){
    SeedContentList();
    RunMenu();
}

public void RunMenu(){
    bool continueToRun = true;
    while(continueToRun){
        Console.Clear();


        Console.WriteLine("Enter the number of the option you'd like to select:\n"+
        "1. Show all streaming content\n"+
        "2. Find streaming content by Title\n"+
        "3. Find streaming content by Star Rating\n"+
        "4. Find streaming content by Family Friendly\n"+
        "5. Add new streaming content\n"+
        "6. Remove streaming content\n"+
        "7. Exit");

        string userInput = Console.ReadLine();


        switch(userInput){
            case "1":
            ShowAllContent();
            break;
            case "2":
            ShowContentByTitle();
            break;
            case "3":
            ShowContentByStarRating();
            break;
            case "4":
            ShowContentByFamilyFriendly();
            break;
            case "5":
            CreateNewContent();
            break;
            case "6":
            RemoveContentFromList();
            break;
            case "7":
            continueToRun = false;
            break;
            default:
            Console.WriteLine("Please Enter a Valid Number between 1 and 5.\n"+
            "Press any key to continue.................");
            Console.ReadKey();
            break;
        }
    }
}

private void CreateNewContent(){
    Console.Clear();

    StreamingContent content = new StreamingContent();

    Console.WriteLine("Please enter a Title:");
    content.Title = Console.ReadLine();

    Console.WriteLine("Please enter a brief description of your movie:");
    content.Description = Console.ReadLine();

    Console.WriteLine("Please give us a start rating of your movie:");
    content.StarRating = double.Parse(Console.ReadLine());

    Console.WriteLine("Select a Maturity Rating:\n"+
    "1. G\n"+
    "2. PG\n"+
    "3. PG 13\n"+
    "4. R\n"+
    "5. NC 17\n");
    
    string maturityRating = Console.ReadLine();

    switch(maturityRating){
        case "1":
        content.MaturityRating = "G";
        content.IsFamilyFriendly = true;
        break;
        case "2":
        content.MaturityRating = "PG";
        content.IsFamilyFriendly = true;
        break;
        case "3":
        content.MaturityRating = "PG 13";
        content.IsFamilyFriendly = false;
        break;
        case "4":
        content.MaturityRating = "R";
        content.IsFamilyFriendly = false;
        break;
        case "5":
        content.MaturityRating = "NC 17";
        content.IsFamilyFriendly = false;
        break;
        default:
        content.MaturityRating = "Unknown";
        content.IsFamilyFriendly = false;
        break;
    }
    
    Console.WriteLine("Select a Genre:\n"+
    "1. Horror\n"+
    "2. Comedy\n"+
    "3. Drama\n"+
    "4. Gore\n"+
    "5. Mystery\n"+
    "6. Action\n"+
    "7. Kids");

    string genreInput = Console.ReadLine();

    int genreID = int.Parse(genreInput);

    content.TypeOfGenre = (GenreType)genreID;


    _streamingRepo.AddContentToDirectory(content);
}

private void ShowAllContent(){
    Console.Clear();

    List<StreamingContent> listOfContent = _streamingRepo.GetContents();

    foreach(StreamingContent content in listOfContent){
        DisplayContent(content);

    }
    Console.WriteLine("Press any key to continue................");
    Console.ReadKey();
}

private void DisplayContent(StreamingContent content){
    Console.WriteLine($"Title: {content.Title}\n"+
    $"Description: {content.Description}\n"+
    $"Genre: {content.TypeOfGenre}\n"+
    $"Stars: {content.StarRating}\n"+
    $"Family Friendly: {content.IsFamilyFriendly}\n"+
    $"Maturity Rating: {content.MaturityRating}\n");
}

private void ShowContentByTitle(){
    Console.Clear();

    Console.WriteLine("Enter a Title:");

    string title = Console.ReadLine();

    StreamingContent content = _streamingRepo.GetContentByTitle(title);

    if(content != null){
        DisplayContent(content);
    }
    else {
        Console.WriteLine("Invalid title. Could not find any results.");
    }

    Console.WriteLine("Press any key to Continue.....................");
    Console.ReadKey();
}
private void ShowContentByStarRating(){
    Console.Clear();
    Console.WriteLine("Enter a Star Rating (0-5):");

    int starRating = int.Parse(Console.ReadLine());

    StreamingContent content = _streamingRepo.GetContentByStarRating(starRating);
    
    if(content != null){
        DisplayContent(content);
    }
    else {
        Console.WriteLine($"Sorry, no titles have a {starRating} star rating.");
    }
    
    Console.WriteLine("Press any key to Continue.....................");
    Console.ReadKey();
}
private void ShowContentByFamilyFriendly(){
    Console.Clear();

   List<StreamingContent> listOfContent = _streamingRepo.GetContents();

    foreach(StreamingContent content in listOfContent){
        if(content.IsFamilyFriendly){

        DisplayContent(content);
        }
        // else Console.WriteLine("No family friendly content was found.");
    }

    Console.WriteLine("Press any key to Continue.....................");
    Console.ReadKey();
}
private void RemoveContentFromList(){
    Console.Clear();

    Console.WriteLine("Which item would you like to remove?");

    List<StreamingContent> contentList =  _streamingRepo.GetContents();

    int count = 0;

    foreach(StreamingContent content in contentList){
        count++;
        Console.WriteLine($"{count}. {content.Title}");
    }

    int targetContentID = int.Parse(Console.ReadLine());
    int targetIndex = targetContentID - 1;

    if(targetIndex >= 0 && targetIndex < contentList.Count){
        StreamingContent desiredContent = contentList[targetIndex];

        if(_streamingRepo.DeleteExistingContent(desiredContent)){
            Console.WriteLine($"{desiredContent.Title} was successfully removed.");
        }
        else{
            Console.WriteLine("I'm sorry, Dave. I'm afraid I can't do that.");
        }
    }
    else{
        Console.WriteLine("No content has that ID.");
    }
    Console.WriteLine("Press any key to continue................");
    Console.ReadKey();
}


private void SeedContentList(){
    StreamingContent rubber = new StreamingContent("rubber","Tire comes to life and kills people", "R", 5, false, (GenreType)0);
    StreamingContent toystory = new StreamingContent("Toy Story","Best Childhood Movie", "PG", 5, true, GenreType.Kids);
    StreamingContent starwars = new StreamingContent("Star Wars","Lightsabers is all you need to know","PG 13", 5, false, (GenreType)5);


    _streamingRepo.AddContentToDirectory(rubber);
    _streamingRepo.AddContentToDirectory(toystory);
    _streamingRepo.AddContentToDirectory(starwars);
}
}