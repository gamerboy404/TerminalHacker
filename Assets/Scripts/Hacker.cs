using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        string greeting = "Welcome User";
        ShowMainMenu(greeting);
        
    }

    void OnUserInput(string input)
    {
        if (input == "menu" || input == "Menu" || input == "MENU") // we can always go back to menu
        {
            ShowMainMenu("Welcome Again");
        }
        else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        
    }

    private void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Invalid selection");
            Terminal.WriteLine("Try again");
        }
    }

    void ShowMainMenu(string stringToUse)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(stringToUse);
        Terminal.WriteLine("What would you like to access");
        Terminal.WriteLine("");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for Giaccomo's nudes");
        Terminal.WriteLine("Press 2 for finding Freddy");
        Terminal.WriteLine("Press 3 for Brad's age");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection :");
    }
    // Update is called once per frame
    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen folder " + level);
        Terminal.WriteLine("Please enter your password");
    }

}
