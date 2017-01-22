using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour {


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) {
            Application.LoadLevel("Level1");
        }
    }
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
