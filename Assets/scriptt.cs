
using UnityEngine;

public class scriptt : MonoBehaviour
{
    // Start is called before the first frame update

    string Input;
    int level;
    string password = "test";
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;


    string[] level1Passwords = { "Criminal", "Police", "Uniform", "Schedule", "Cell" };
    string[] level2Passwords = { "Workplace", "Physics", "Photometer", "Incubators", "Stations" };
    string[] level3Passwords = { "Psychiatric", "Deinstitutionalisation", "Psychotic", "Hallucinogen", "Barbaric" };



    void Start()
    {
        MainMenu();
        // Prison: Criminal, Police, Uniform, Schedule, Cell
        // Labratory: Workplace, Physics, Photometer, Incubators, Stations
        // Asylum: Psychiatric, Deinstitutionalisation, Psychotic, Hallucinogen, Barbaric
    }

    void OnUserInput(string Input)
    {
        if (Input == "menu")
        {
            Screen currentScreen = Screen.MainMenu;
            MainMenu();
            runMainMenu(Input);
        }

        else if (currentScreen == Screen.MainMenu)
        { runMainMenu(Input); }

        else if (currentScreen == Screen.Password)
        {
            checkPassword(Input);
        }


    }

    void runMainMenu(string Input)
    {
        Screen currentScreen = Screen.MainMenu;
        if (Input == "1")
        { level = 1;
            StartGame(); }


        else if (Input == "2")
        { level = 2;
            StartGame(); }

        else if (Input == "3")
        { level = 3;
            StartGame(); }

        // else if (Input != "1" || Input != "2" || Input != "3")

        // {
        // gameNotPicked();
        //  }

        currentScreen = Screen.Password;

    }

    void gameNotPicked()
    {
        Terminal.WriteLine("is you blind?! You can only hack into  three places. You know better, Agent R.");
    }


    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("You have chosen level " + level);
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;

            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;

            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
        }

        Terminal.WriteLine("Write the password to hack into the    place. Your hint is: " + password.Anagram());

    }

    void checkPassword(string Input)
    {

        if (Input == password)

        {
            Terminal.ClearScreen();
            Terminal.WriteLine("You Win!");
            Terminal.WriteLine("Go back to the menu by typing 'menu'   and try another level.");
            runMainMenu(Input);

        }


        else
        {
            Terminal.WriteLine("Try again or select another level.");
        }
    }
    void MainMenu()
    {
        // terminal.writeline just writes everything on screen.
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome Agent R");
        Terminal.WriteLine("Choose a level you'd like to hack into:");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Type '1' for Prison");
        Terminal.WriteLine("Type '2' for Labratory");
        Terminal.WriteLine("Type '3' for Asylum");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("So, what do you say?");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
