using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroMonologue : NPCInteraction
{

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        StartDialogue();
    }
    
    private void StartDialogue()
    {
        textbox.SetActive(true);
        activeDialogue = 0;

        namebox.text = characterName;
        dialoguebox.text = dialogues[activeDialogue];

        gameManager.SetActiveText(this);
    }
}
