namespace HobbyTracker;

using System.IO;
using Spectre.Console;

class Program   
{
    static void Main(string[] args)
    {
        string user = fancySelect("Please select a user: ", ["Oscar"]);
        consoleUI(user);
    }

    static string fancySelect(string message, List<string> selectList)
    {
        var response = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(message)
                .AddChoices(selectList)
                .AddChoices("Back"));
        return response;
    }
    
    static string fancySelectActivity(string message, List<string> selectList)
    {
        var response = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(message)
                .AddChoices(selectList));
        return response;
    }

    static string getUserInput(string message)
    {
        var response = AnsiConsole.Prompt(
            new TextPrompt<string>(message));
        return response;
    }

    static void runReport()
    {
        string hobbyListContents = File.ReadAllText("hobby-sheet.txt");
        Console.WriteLine("*********************************");
        foreach(string hobbyLine in hobbyListContents.Split('\n')){
            if(hobbyLine!="" & File.Exists(hobbyLine+".txt")){                                
                string activityListContents = File.ReadAllText(hobbyLine + ".txt");
                Console.WriteLine("Hobby: " + hobbyLine);
                Console.WriteLine("Activities:");
                foreach(string activityLine in activityListContents.Split('\n')){
                    if(activityLine != ""){
                        Console.WriteLine(activityLine);
                    }
                }
                Console.WriteLine("*********************************");
            }
        }
    }
    static void consoleUI(string user)
    {
        if(user == "Oscar"){
            string firstScreenOption;
            Console.WriteLine("Welcome " + user + "!");
            do{
                firstScreenOption = fancySelect("\nPlease select from the following:", ["View Hobbies", "Add New Hobby", "Run Hobby Report"]);
                if(firstScreenOption == "View Hobbies"){
                    string secondScreenOption;
                    string hobbyListContents = File.ReadAllText("hobby-sheet.txt");
                    List<string> hobbyList = new List<string>();
                    foreach(string hobbyLine in hobbyListContents.Split('\n')){
                            if(hobbyLine!=""){
                                hobbyList.Add(hobbyLine);
                            }
                        }
                    do{
                        secondScreenOption = fancySelect("\nPlease select a hobby to continue: ", hobbyList);
                        if(hobbyList.Contains(secondScreenOption)){
                            string thirdScreenOption;
                            do{
                                thirdScreenOption = fancySelect("\nYou've selected '" + secondScreenOption + "'\nWhat would you like to do?", ["Add Activity"]);
                                if(thirdScreenOption == "Add Activity"){
                                    Activity addActivity = new Activity();
                                    addActivity.name = getUserInput("Enter an Activity: ");
                                    addActivity.priority = fancySelectActivity("Select Priority", ["High", "Medium", "Low"]);
                                    File.AppendAllText(secondScreenOption+".txt", addActivity.name + " - " + addActivity.priority + Environment.NewLine);
                                }
                            }while(thirdScreenOption != "Back");
                        }
                    }while(secondScreenOption != "Back");
                }
                else if(firstScreenOption == "Add New Hobby"){
                    string hobby = getUserInput("Please type the name of your new hobby:");
                    File.AppendAllText("hobby-sheet.txt", hobby+Environment.NewLine);
                }
                else if(firstScreenOption == "Run Hobby Report")
                {
                    runReport();    
                }
                else{
                    Console.WriteLine("You have succesfully signed out.");
                }
            }while(firstScreenOption != "Back");
        }
    }
}

