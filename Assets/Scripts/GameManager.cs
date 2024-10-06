using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool key = false, dGear = false;
    bool scroll = false, chip = false;

    bool daytime = true;

    private NPCInteraction activeSpeaker;
    private TaskManager taskManager;

    [Header("Player Controller")]
    [SerializeField] private PlayerControl player;

    private float cycleTimer = 45;
    private float timer;
    [Header("Timer UI")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Image clock;

    [Header("Clock Sprites")]
    [SerializeField] private Sprite dayClock;
    [SerializeField] private Sprite nightClock;

    [Header("Invisible Wall")]
    [SerializeField] private GameObject invisWall;

    [Header("Beginner NPC")]
    [SerializeField] NPCInteraction beginner;

    [Header("Dialogue")]
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueName;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Background")]
    [SerializeField] private SpriteRenderer[] backgroundPanels;
    [SerializeField] private Sprite dayBG, nightBG;

    private bool timerEnabled = false;

    private void Start()
    {
        timer = cycleTimer;
        taskManager = FindObjectOfType<TaskManager>();
    }

    private void Update()
    {
        EvaluateTimer();
    }

    public bool Collect(string collect_name)
    {
        bool collectable;
        if (IsDaytime())
        {
            collectable = false;
            CantSteal();
        }
        else
        {
            switch (collect_name)
            {
                case "Key":
                    key = true;
                    break;
                case "Diamond Gear":
                    dGear = true;
                    break;
                case "Scroll":
                    scroll = true;
                    break;
                case "Data Chip":
                    chip = true;
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
            case "Scroll":
                collected = scroll;
                break;
            case "Data Chip":
                collected = chip;
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
        else if (timerEnabled && timer <= 0)
        {
            CyclePhases();
        }
        timerText.text = FormattedTime(timer);
    }

    private void CyclePhases()
    {
        if (IsDaytime())
        {
            daytime = false;
            clock.sprite = nightClock;
            taskManager.MutinyTask();
            SwapBackgrounds(nightBG);
            beginner.gameObject.SetActive(false);
            if(taskManager.GetCurrentTask() != "Completed") { Lose(); }
        }
        else
        {
            daytime = true;
            clock.sprite = dayClock;
            taskManager.MorningTask();
            invisWall.SetActive(true);
            beginner.resetDay();
            StopTimer();
            SwapBackgrounds(dayBG);
            beginner.gameObject.SetActive(true);
        }

        timer = cycleTimer;
        player.ReturnToRoom();
    }

    public void SetActiveText(NPCInteraction NPC)
    {
        activeSpeaker = NPC;
        Time.timeScale = 0;
    }

    public void ContinueButton()
    {
        if(activeSpeaker != null)
        {
            activeSpeaker.NextDialogue();
        }
        else
        {
            dialogueBox.SetActive(false);
            Time.timeScale = 1;
        }
        
    }

    private string FormattedTime(float rawTime)
    {
        string time = System.Math.Truncate(rawTime / 60).ToString();
        time += ":";

        int seconds = (int)System.Math.Truncate(rawTime % 60);

        if (seconds >= 10)
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

    public void BeginTasks()
    {
        taskManager.ActivateTask();
    }

    public void Win()
    {
        SceneManager.LoadScene("Ending");
    }

    public void Lose()
    {
        SceneManager.LoadScene("BadEnding");
    }

    public void WakeUp()
    {
        SceneManager.LoadScene("Roomba");
    }

    public void DisableInvisWall()
    {
        invisWall.SetActive(false);
    }

    public void EnableInvisWall()
    {
        invisWall.SetActive(true);
    }

    public void CantSteal()
    {
        activeSpeaker = null;
        dialogueBox.SetActive(true);
        dialogueName.text = "You";
        dialogueText.text = "I can't steal this in broad daylight! I need to wait for nighttime.";
        Time.timeScale = 0;
    }

    public void CantSleepTask()
    {
        activeSpeaker = null;
        dialogueBox.SetActive(true);
        dialogueName.text = "You";
        dialogueText.text = "I can't sleep before I finish my task!";
        Time.timeScale = 0;
    }

    public void CantSleepNight()
    {
        activeSpeaker = null;
        dialogueBox.SetActive(true);
        dialogueName.text = "You";
        dialogueText.text = "I can't sleep, the night is the only time I can move freely!";
        Time.timeScale = 0;
    }

    public void Sleep()
    {
        timer = 0;
    }

    public void SwapBackgrounds(Sprite bg)
    {
        foreach(SpriteRenderer background in backgroundPanels)
        {
            background.sprite = bg;
        }
    }
}
