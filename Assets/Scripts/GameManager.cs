using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool key = false, dGear = false;

    bool daytime = true;

    private NPCInteraction activeSpeaker;

    private float cycleTimer = 180;
    private float timer;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Image clock;

    [Header("Clock Sprites")]
    [SerializeField] private Sprite dayClock;
    [SerializeField] private Sprite nightClock;

    private bool timerEnabled = false;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        timer = cycleTimer;
    }

    private void Update()
    {
        EvaluateTimer();
    }

    public bool Collect(string collect_name)
    {
        bool collectable;
        if(IsDaytime())
        {
            collectable = false;
        }
        else
        {
            switch (collect_name)
            {
                case "Key":
                    key = true;
                    Debug.Log("Key Collected!");
                    Debug.Log(FormattedTime(60.25345f));
                    break;
                case "Diamond Gear":
                    dGear = true;
                    Debug.Log("Diamond Gear Collected!");
                    Debug.Log(FormattedTime(86.1432f));
                    break;
            }
            collectable = true;
        }
        return collectable;
    }

    public bool HasCollectable(string collect_name)
    {
        bool collected = false;

        switch (collect_name)
        {
            case "Key":
                collected = key;
                break;
            case "Diamond Gear":
                collected = dGear;
                break;
        }

        return collected;
    }

    public bool IsDaytime()
    {
        return daytime;
    }

    private void EvaluateTimer()
    {
        if (timerEnabled && timer > 0) { timer -= Time.deltaTime; }
        else
        {

        }
        timerText.text = FormattedTime(timer);
    }

    private void CyclePhases()
    {
        if(IsDaytime())
        {
            daytime = false;
            clock.sprite = nightClock;
        }
        else
        {
            daytime = true;
            clock.sprite = dayClock;
        }
    }

    public void SetActiveText(NPCInteraction NPC)
    {
        activeSpeaker = NPC;
    }

    public void ContinueButton()
    {
        activeSpeaker.NextDialogue();
    }

    private string FormattedTime(float rawTime)
    {
        string time = System.Math.Truncate(rawTime / 60).ToString();
        time += ":";

        int seconds = (int)System.Math.Truncate(rawTime % 60);

        if(seconds >= 10)
        {
            time += System.Math.Truncate(rawTime % 60).ToString();
        }
        else
        {
            time += 0;
            time += System.Math.Truncate(rawTime % 60).ToString();
        }

        return time;
    }
    
    public void StartTimer()
    {
        timer = cycleTimer;
        timerEnabled = true;
    }

    public void StopTimer()
    {
        timerEnabled = false;
    }

}
