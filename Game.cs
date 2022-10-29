using System.Net.Security;

namespace BanishedMain;

public class Game
{
    private Player player { get; set; }

    // divison into seperate variables for readability
    private DefaultPlayerClass pl_class;
    private DefaultPlayerRace pl_Race;
    private DefaultPlayerAccolade pl_accolade;

    private string playerName;
    private int playerHealth;
    private int playerFaith;
    private int playerAgility;

    public Game(Player _player)
    {
        player = _player;
        pl_class = player.playerclass;
        pl_Race = player.playerrace;
        pl_accolade = player.playeraccolade;
        playerName = player.playername;

        // get health, faith, agility
        playerHealth = player.playerHealth;
        playerFaith = player.playerFaith;
        playerAgility = player.playerAgility;
    }

    public void Info()
    {
        Sys.WSMNL("INFORMATION: ");
        Sys.WSMNL("1. Story Narration is given in BLUE (Debug.WSMNL())");
        Sys.WSMNL("2. Prompts are given in YELLOW (Warn.WWMNL())");
        Sys.WSMNL("3. Combat is given in RED (Error.WEMNL())");
        Sys.WSMNL("4. After each prompt, input ENTER to gain the relevent responses");
        Sys.WSMNL(
            "5. In responding to the prompt, use only a spelling of a number of the given input you wish to choose");
        Sys.WSMNL("6. Respond to prompt with 'SAVE' to quit the game and save he scene");
        Sys.WSMNL("\n ENTER TO BEGIN...");

        Console.ReadLine(); // wait for user input
        Console.Clear();

        Sys.WSM("\n");
    }

    public void Start()
    {
        // start based on selections made
        switch (pl_class)
        {
            case DefaultPlayerClass.KNIGHT:
                KNIGHT_SCENE.Beginning();
                break;
            case DefaultPlayerClass.SORCERER:
                SORCERER_SCENE.Beginning();
                break;
            case DefaultPlayerClass.WARLOCK:
                WARLOCK_SCENE.Beginning();
                break;
        }
    }

    public void GAME() // works
    {
        SCENE_RUN();
    }

    private void SCENE_RUN()
    {
        switch (pl_class)
        {
            case DefaultPlayerClass.KNIGHT:
                KNIGHT_SCENE.K_SCENE();
                break;
            case DefaultPlayerClass.SORCERER: // TODO: IMPLEMENT
                SORCERER_SCENE.S_SCENE();
                break;
            case DefaultPlayerClass.WARLOCK:
                WARLOCK_SCENE.W_SCENE();
                break;
        }
    }
}

public static class KNIGHT_SCENE
{
    public static void Beginning()
    {
        string beginning = GameManager.readBeginning(DefaultPlayerClass.KNIGHT);
        Debug.WDMNL(beginning);
        Debug.WDMNL("");
        Sys.WSMNL("PRESS ENTER TO CONTINUE");

        // wait for input
        Console.ReadLine();
    }

    public static void K_SCENE()
    {
        int promptCount = 1;
        int sceneCount = 0;
        int sceneNumber = 1;
            
        for (int j = 0; j < 3; j++)
        {
            
            string prompt = GameManager.readPrompt(DefaultPlayerClass.KNIGHT, sceneNumber.ToString(), promptCount.ToString());
            string[] options = GameManager.readOptions(DefaultPlayerClass.KNIGHT, promptCount.ToString());
            string[] consequences =
                GameManager.readConsequences(DefaultPlayerClass.KNIGHT, promptCount.ToString());
            string[] response = GameManager.promptPlayerDefault(prompt, options, consequences);

            Debug.WDMNL(response[1]);  
                
            Debug.WDM(">>> ");
            Console.ReadLine();

            promptCount++;
            sceneNumber++;
        }
    }
}

public static class SORCERER_SCENE //TODO: FINISH THESE BAD BOYS
{
    public static void Beginning()
    {
        string beginning = GameManager.readBeginning(DefaultPlayerClass.SORCERER);
        Debug.WDMNL(beginning);
        Debug.WDMNL("");
        Sys.WSMNL("PRESS ENTER TO CONTINUE");

        // wait for input
        Console.ReadLine();
    }

    public static void S_SCENE()
    {
        int promptCount = 1;
        int sceneCount = 0;
        int sceneNumber = 1;
            
        for (int j = 0; j < 3; j++)
        {
            
            string prompt = GameManager.readPrompt(DefaultPlayerClass.SORCERER, sceneNumber.ToString(), promptCount.ToString());
            string[] options = GameManager.readOptions(DefaultPlayerClass.SORCERER, promptCount.ToString());
            string[] consequences =
                GameManager.readConsequences(DefaultPlayerClass.SORCERER, promptCount.ToString());
            string[] response = GameManager.promptPlayerDefault(prompt, options, consequences);

            Debug.WDMNL(response[1]);  
                
            Debug.WDM(">>> ");
            Console.ReadLine();

            promptCount++;
            sceneNumber++;
        }
    }
}

public static class WARLOCK_SCENE
{
    public static void Beginning()
    {
        string beginning = GameManager.readBeginning(DefaultPlayerClass.WARLOCK);
        Debug.WDMNL(beginning);
        Debug.WDMNL("");
        Sys.WSMNL("PRESS ENTER TO CONTINUE");

        // wait for input
        Console.ReadLine();
    }

    public static void W_SCENE()
    {
        int promptCount = 1;
        int sceneCount = 0;
        int sceneNumber = 1;
            
        for (int j = 0; j < 3; j++)
        {
            
            string prompt = GameManager.readPrompt(DefaultPlayerClass.WARLOCK, sceneNumber.ToString(), promptCount.ToString());
            string[] options = GameManager.readOptions(DefaultPlayerClass.WARLOCK, promptCount.ToString());
            string[] consequences =
                GameManager.readConsequences(DefaultPlayerClass.WARLOCK, promptCount.ToString());
            string[] response = GameManager.promptPlayerDefault(prompt, options, consequences);

            Debug.WDMNL(response[1]);  
                
            Debug.WDM(">>> ");
            Console.ReadLine();

            promptCount++;
            sceneNumber++;
        }
    }
}