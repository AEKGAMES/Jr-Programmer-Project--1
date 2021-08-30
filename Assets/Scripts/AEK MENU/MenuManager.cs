using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MenuManager
{
    public static bool IsInitialised { get; private set; }

    public static GameObject mainMenu, playerName;

    public static void Init()
    {
        GameObject canvas = GameObject.Find("Canvas");
        mainMenu = canvas.transform.Find("Container").gameObject; // Main Menu 
        playerName = canvas.transform.Find("PlayerInfo").gameObject; // Player Name

        IsInitialised = true;
    }

    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {
        if (!IsInitialised)
            Init();

        switch (menu)
        {
            case Menu.MAIN_MENU:
                mainMenu.SetActive(true);
                break;
            case Menu.PLAYER_NAME:
                playerName.SetActive(true);
                break;
        }

        callingMenu.SetActive(false);
    }
}
