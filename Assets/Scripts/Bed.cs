using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    [SerializeField] private Canvas tooltip;

    private GameManager gameManager;
    private TaskManager taskManager;

    private float cooldownMax = 0.3f;
    private float cooldown = 0;

    private void Update()
    {
        if (cooldown > 0) { cooldown -= Time.deltaTime; }
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        taskManager = FindObjectOfType<TaskManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tooltip.enabled = true;
            if (Input.GetButton("Interact"))
            {
                Evaluate();
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

    private void Evaluate()
    {
        if(cooldown <= 0)
        {
            if(gameManager.IsDaytime() && taskManager.GetCurrentTask() == "Completed")
            {
                gameManager.Sleep();
            }
            else if(gameManager.IsDaytime())
            {
                gameManager.CantSleepTask();
            }
            else
            {
                gameManager.CantSleepNight();
            }
            cooldown = cooldownMax;
        }
        
    }
}
