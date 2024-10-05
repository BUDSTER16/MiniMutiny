using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private Canvas tooltip;

    [Header("Textbox components")]
    [SerializeField] private GameObject textbox;
    [SerializeField] private TextMeshProUGUI namebox;
    [SerializeField] private TextMeshProUGUI dialoguebox;


    [Header("Dialogue Details")]
    [SerializeField] private string characterName;
    [SerializeField] private string[] dialogues;
    [SerializeField] private bool beginner;


    private int activeDialogue = 0;

    private GameManager gameManager;


    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            tooltip.enabled = true;
        }
        if(Input.GetButton("Interact"))
        {
            StartDialogue();
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
            if(beginner)
            {
                gameManager.StartTimer();
            }
        }
    }
}
