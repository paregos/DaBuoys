using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour {

    public void LoadGame()
    {
        Application.LoadLevel("Level1");
    }

    public void LoadMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    public void LoadWin()
    {
        Application.LoadLevel("MainMenu");
    }

    public void LoadLose()
    {
        Application.LoadLevel("MainMenu");
    }
}
