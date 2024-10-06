using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DreamDoor : MonoBehaviour
{
    [SerializeField] private Canvas tooltip;
    [SerializeField] private TextMeshProUGUI tooltipText;


    private GameManager gameManager;
    private TaskManager taskManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        taskManager = FindObjectOfType<TaskManager>();
    }

    private void Update()
    {
        if(gameManager.IsDaytime())
        {
            tooltipText.text = "'E' to relay info";
            tooltipText.color = Color.white;
        }
        else
        {
            tooltipText.text = "'E' to wake up";
            tooltipText.color = Color.red;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tooltip.enabled = true;
            if (Input.GetButton("Interact") && !gameManager.IsDaytime())
            {
                CheckRequirements();
            }
            else if(Input.GetButton("Interact") && gameManager.IsDaytime() && taskManager.GetCurrentTask() == "Relay")
            {
                if (DreamCheckInfo()) { collision.gameObject.GetComponent<PlayerAudio>().PlaySound("warn"); }
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

    private void CheckRequirements()
    {
        if (gameManager.HasCollectable("Key") && gameManager.HasCollectable("Diamond Gear"))
        {
            gameManager.WakeUp();
        }
        
    }

    private bool DreamCheckInfo()
    {
        bool hasInfo;
        if (taskManager.hasRelayInfo())
        {
            hasInfo = true;
            taskManager.RelayProgress();
        }
        else
        {
            hasInfo = false;
        }
        return hasInfo;
    }
}
