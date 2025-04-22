namespace HobbyTracker;

using System.IO;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please select a user (Oscar or New User):");
        string user = Console.ReadLine();
        
        if(user == "Oscar"){
            string firstScreenOption;
            Console.WriteLine("Welcome " + user + "!");

            do{
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Please select from the following:");
                Console.WriteLine("View Hobbies (type view)");
                Console.WriteLine("Add New Hobby (type add)");
                Console.WriteLine("Run Hobby Report (type report)");
                Console.WriteLine("Sign out (type end)");
                Console.WriteLine("---------------------------------");

                firstScreenOption = Console.ReadLine();

                if(firstScreenOption == "view"){
                    string secondScreenOption;
                    string hobbyListContents = File.ReadAllText("hobby-sheet.txt");
                    List<string> hobbyList = new List<string>();
                    do{
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("You have the following Hobbies:");
                        //Console.WriteLine(hobbyListContents);
                        foreach(string hobbyLine in hobbyListContents.Split('\n')){
                            if(hobbyLine!=""){
                                Console.WriteLine(hobbyLine);
                                hobbyList.Add(hobbyLine);
                            }
                        }
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("Please select a hobby to continue:");
                        Console.WriteLine("Enter hobby name exactly how it appears above:");
                        Console.WriteLine("Or enter 'back' to return to main menu");
                        secondScreenOption = Console.ReadLine();
                        if(hobbyList.Contains(secondScreenOption)){
                            string thirdScreenOption;
                            do{
                                Console.WriteLine("---------------------------------");
                                Console.WriteLine("You've selected " + secondScreenOption);
                                Console.WriteLine("What would you like to do?");
                                Console.WriteLine("Add New Activity (type add)");
                                //Console.WriteLine("Delete Activity (type delete)");
                                Console.WriteLine("Go Back (type back)");
                                Console.WriteLine("---------------------------------");
                                thirdScreenOption = Console.ReadLine();
                                string newActivity;
                                string newPriority;
                                if(thirdScreenOption == "add"){
                                    Console.WriteLine("Enter Activity:");
                                    newActivity = Console.ReadLine();
                                    Console.WriteLine("Enter priority as 'High' 'Medium' or 'Low':");
                                    newPriority = Console.ReadLine();
                                    File.AppendAllText(secondScreenOption+".txt", newActivity + " - " + newPriority + Environment.NewLine);
                                }//else if(thirdScreenOption == "delete"){
                                    
                                //}


                            }while(thirdScreenOption != "back");

                            //File.AppendAllText(secondScreenOption+".txt", "testing");
                        }
                        //else{
                        //    Console.WriteLine("Enter a valid hobby to continue.");
                        //}
                    }while(secondScreenOption != "back");
                }
                else if(firstScreenOption == "add"){
                    Console.WriteLine("Please type the name of your new hobby:");
                    string hobby = Console.ReadLine();
                    File.AppendAllText("hobby-sheet.txt", hobby+Environment.NewLine);
                }
                else if(firstScreenOption == "report"){
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
                else{
                    Console.WriteLine("You have succesfully signed out.");
                }
            }while(firstScreenOption != "end");
            

        }
        
    }
}
