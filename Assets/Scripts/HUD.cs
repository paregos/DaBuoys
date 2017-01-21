using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Text timer;
    public Text caught;

    private float time;
    private int fishCaught;


	// Use this for initialization
	void Start () {
        time = 60f;
        fishCaught = 0;
    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        timer.text = "" + (int)Mathf.Round(time);
        if (time < 0f)
        {
            PoseidonWins();
        }
        caught.text = "Fisherman: " + fishCaught;
	}

    public void caughtFish()
    {
        fishCaught++;
        if (fishCaught >= 3)
        {
            FishermanWins();
        }
    }


    public void FishermanWins()
    {
        Application.LoadLevel("MainMenu");
    }

    public void PoseidonWins()
    {
        Application.LoadLevel("MainMenu");
    }
}
