using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

    public Image Life;
    public Image Carbu;
    public Image Vidange;
    public PlayerController Player;

    public float heldTime = 0.0f;

    public int MaxLife = 100;
    public float CurrentLife;
    public int UpLife = 5;
    public float DamagePerFrames = 0.5f;

    public int MaxCarbu = 100;
    public float CurrentCarbu;
    public float CarbuLostPerDep = 0.5f;

    public int MaxVidange = 100;
    public float CurrentVidange;
    public float VidangeGainPerCarbu = 0.5f;
    public float SpeedLost = 0.2f;

    // Use this for initialization
    void Start()
    {
        CurrentLife = 100;
        CurrentCarbu = 100;
        CurrentVidange = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLife();
    }

    void UpdateLife()
    {
        
        heldTime += Time.deltaTime;

        if(heldTime > 0)
        {
            CurrentLife -= DamagePerFrames;
            heldTime -= heldTime;
        }

        if(CurrentLife >= MaxLife)
        {
            CurrentLife = MaxLife;
        }

        if(CurrentLife <= 0)
        {
            CurrentLife = 0;
            Debug.Log("Mort iiiidiot!");
        }
        UpdateDisplay();
    }

    public void UpdateCarbu()
    {
        
        heldTime += Time.deltaTime;

        if (heldTime > 0)
        {
            CurrentCarbu -= CarbuLostPerDep;
            UpdateVidange();
            heldTime -= heldTime;
        }

        if(CurrentCarbu >= MaxCarbu)
        {
            CurrentCarbu = MaxCarbu;
        }
        if(CurrentCarbu <= 5)
        {
            CurrentCarbu = 0;
            Player.speed-= 0.5f;
            if (Player.speed >= 0)
            {
                Player.speed = 0;
            }
        }
    }

    void UpdateVidange()
    {
        heldTime += Time.deltaTime;

        if (heldTime > 0)
        {
            CurrentVidange += VidangeGainPerCarbu;
            Player.speed -= SpeedLost;
            heldTime -= heldTime;
        }
        if(CurrentVidange >= MaxVidange)
        {
            CurrentVidange = MaxVidange;
        }
    }

    void UpdateDisplay()
    {
        Life.fillAmount = (CurrentLife * 1.0f) / (MaxLife * 1.0f);
        Carbu.fillAmount = (CurrentCarbu * 1.0f) / (MaxCarbu * 1.0f);
        Vidange.fillAmount = (CurrentVidange * 1.0f) / (MaxVidange * 1.0f);
    }
}
