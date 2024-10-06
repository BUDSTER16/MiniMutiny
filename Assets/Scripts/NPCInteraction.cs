using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private Canvas tooltip;

    [Header("Textbox components")]
    [SerializeField] public GameObject textbox;
    [SerializeField] public TextMeshProUGUI namebox;
    [SerializeField] public TextMeshProUGUI dialoguebox;


    [Header("Dialogue Details")]
    [SerializeField] public string characterName;
    [SerializeField] public string[] dialogues;
    [SerializeField] private bool beginner;


    private bool begunDaily = false;
    public int activeDialogue;

    public GameManager gameManager;


    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        activeDialogue = 0;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            tooltip.enabled = true;
            if (Input.GetButton("Interact"))
            {
                StartDialogue();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tooltip.enabled = false;
        }
    }

    private void StartDialogue()
    {
        textbox.SetActive(true);
        activeDialogue = 0;

        namebox.text = characterName;
        dialoguebox.text = dialogues[activeDialogue];

        gameManager.SetActiveText(this);
    }

    public void NextDialogue()
    {
        activeDialogue++;
        if(activeDialogue < dialogues.Length)
        {
            dialoguebox.text = dialogues[activeDialogue];
        }
        else
        {
            textbox.SetActive(false);
            Time.timeScale = 1;
            if(beginner && !begunDaily)
            {
                beginnerMethod();
            }
        }
    }

    private void beginnerMethod()
    {
        gameManager.StartTimer();
        gameManager.BeginTasks();
        begunDaily = true;
        gameManager.DisableInvisWall();
        swapBeginnerLines();
    }

    public void resetDay()
    {
        begunDaily = false;
        gameManager.EnableInvisWall();
    }

    private void swapBeginnerLines()
    {
        string[] newDialogues = 
            {
            "Good mornin' and good luck with your task today!",
            "Have a good one!"
            };
    }
}
