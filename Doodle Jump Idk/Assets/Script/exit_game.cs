using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit_game : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
        //Just to make sure its working
    }
}
