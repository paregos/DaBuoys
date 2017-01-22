using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Text timer;
    public Text victory;


    public Texture fish;
    public Texture fishEaten;

    public RawImage[] healthBar = new RawImage[3];

    public AudioClip fisheatsound;

    private float time;
    private int fishCaught;



    // Use this for initialization
    void Start()
    {
        time = 60f;
        fishCaught = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timer.text = "" + (int)Mathf.Round(time);
        if (time < 0f)
        {
            FishermanWins();
            time = 0f;
        }
        
    }

    public void caughtFish()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(fisheatsound, 1f);

        healthBar[fishCaught].texture = fishEaten;
        fishCaught++;
        if (fishCaught >= 3)
        {
            FishermanWins();
        }
    }


    public void FishermanWins()
    {
        StartCoroutine(FisherMan());
    }

    public void PoseidonWins()
    {
        StartCoroutine(Poseidon());
    }

    IEnumerator FisherMan()
    {
        Debug.Log("entering end");
        victory.enabled = true;
        victory.text = "Fisherman Wins!";
        yield return new WaitForSeconds(3);
        Application.LoadLevel("MainMenu");
    }

    IEnumerator Poseidon()
    {
        victory.enabled = true;
        victory.text = "Poseidon Wins!";
        yield return new WaitForSeconds(3);
        Application.LoadLevel("MainMenu");
    }
}

