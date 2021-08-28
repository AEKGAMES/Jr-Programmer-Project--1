using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    // you can save and load the color from the application instantly
    public void SaveColorClicked()
    {
        MainManager.Instance.SaveColor();
    }

    public void LoadColorClicked()
    {
        MainManager.Instance.LoadColor();
        ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        MainManager.Instance.TeamColor = color;
    }

    // Load Level 1
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    // Quite the game
    public void Exit()
    {
        // This line will save the user�s last selected color when the application exits. 
        MainManager.Instance.SaveColor();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;

        // This line will pre-select the saved color in the MainManager (if there is one) when the menu screen is launched.
        ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }
}
