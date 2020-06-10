using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configuration data
    const string menuHint = "You may type menu at any time";
    string[] level1Passwords = { "arts", "cats", "nude", "shit", "pull"};
    string[] level2Passwords = { "cloud", "exist", "alive", "doubt", "sleep"};
    string[] level3Passwords = { "birthday", "calendar", "database", "designer", "estimate"};

    //Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;
    
    // Start is called before the first frame update
    void Start()
    {
        string greeting = "Welcome User";
        ShowMainMenu(greeting);
        
    }
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
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
        else if(currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        
    }

    void RunMainMenu(string input)
    {     
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if(isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Invalid selection");
            Terminal.WriteLine("");
            Terminal.WriteLine(menuHint);
        }
    }
 
    void ShowMainMenu(string stringToUse)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(stringToUse);
        Terminal.WriteLine("What would you like to hack into");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for local library");
        Terminal.WriteLine("Press 2 for police station");
        Terminal.WriteLine("Press 3 for nasa");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection :");
    }
    // Update is called once per frame
    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine("");
        Terminal.WriteLine(menuHint);
    }

    private void SetRandomPassword()
    {
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
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();

        }
        else
        {
            Terminal.WriteLine("Incorrect password");
            Terminal.WriteLine("Try again");
            AskForPassword();
        }

    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine("");
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("found book of secrets");
                Terminal.WriteLine(@"
    _______
   /      /,
  /      //
 /______//
(______(/
");
                break;
            case 2:
                Terminal.WriteLine("you found prison key");
                Terminal.WriteLine(@"
 ____
, =, ( _________
| ='  (VvvVvV--'
|____(
");
                break;
            case 3:
                Terminal.WriteLine("connection successfull");
                Terminal.WriteLine(@"
 _ __   __ _ ___  __ _ 
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___/\__,_|   
");
                break;

        }
        //Terminal.WriteLine("Password Accepted");
    }
}
