using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Text timer;

    public Texture fish;
    public Texture fishEaten;

    public RawImage[] healthBar = new RawImage[3];
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
	}

    public void caughtFish()
    {
        healthBar[fishCaught].texture = fishEaten;
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
