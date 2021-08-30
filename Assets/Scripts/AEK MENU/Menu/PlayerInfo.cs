using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    
    public void OnClick_Menu()
    {
        MenuManager.OpenMenu(Menu.MAIN_MENU, gameObject);
    }
}
