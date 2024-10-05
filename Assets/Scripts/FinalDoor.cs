using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalDoor : MonoBehaviour
{
    [SerializeField] private Canvas tooltip;
    [SerializeField] private TextMeshProUGUI tooltipText;


    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
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
            tooltipText.text = "'E' to INVADE";
            tooltipText.color = Color.red;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tooltip.enabled = true;
        }
        if (Input.GetButton("Interact"))
        {
            CheckRequirements();
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
            gameManager.Win();
        }
        
    }
}
