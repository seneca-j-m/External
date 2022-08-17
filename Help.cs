namespace BanishedMain;

public static class Help
{ }

public static class ClassHelp
{
    public static void classOptions()
    {
        // print every item in the enum list
        var classOptions = Enum.GetValues(typeof(PlayerClassList)).Cast<PlayerClassList>();

        CosmeticMenu.writeTitleCosmetics("CLASS HELP:");
        Debug.WDMNL("CLASS OPTIONS: ");
        uint optionIncrament = 0;
        foreach (var classOption in classOptions)
        {
            Debug.WDMNL($"{optionIncrament} :'{classOption.ToString()}'");
        }

        bool quit = false;

        while (!quit)
        {
            Debug.WDMNL("[q to quit] , [? for class info]");
            string userClassHelpSelection = Console.ReadLine();

            if (string.Equals(userClassHelpSelection, "q"))
            {
                quit = true;
            }
            else if (string.Equals(userClassHelpSelection, "?"))
            {
                // print info for each class
                Console.Clear();
                
                Knight.info();
                Console.WriteLine("\n\n");

            ;
                // // pause for input
                // Debug.WDMNL("[n for next] , [p for previous] , [q to quit] : ");
                // bool classQuit = false;
                //
                // while (!classQuit)
                // {
                //     string userClassMenuSelection = Console.ReadLine();
                //     if (string.Equals(userClassMenuSelection, "n"))
                //     {
                //         // print next class
                //         
                //         Debug.WDMNL("[n for next] , [p for previous] , [q to quit] : ");
                //         userClassMenuSelection = Console.ReadLine();
                //     }
                //     else if (string.Equals(userClassMenuSelection, "p"))
                //     {
                //         // print previous class
                //     }
                //     else if (string.Equals(userClassMenuSelection, "q"))
                //     {
                //         classQuit = true;
                //     }
                // }
            }
            
        }

    }
    
    public static void classMenuHelp()
    {}
}

public static class RaceHelp
{
    public static void raceMenuHelp()
    {}
    
}