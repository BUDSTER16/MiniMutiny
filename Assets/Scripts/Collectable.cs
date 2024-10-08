using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private Canvas tooltip;

    [Header("Details")]
    [SerializeField] private string item_name;


    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tooltip.enabled = true;
            if (Input.GetButton("Interact"))
            {
                Collect(collision.gameObject.GetComponent<PlayerAudio>()); ;
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

    private void Collect(PlayerAudio source)
    {
        if (gameManager.Collect(item_name))
        {
            source.PlaySound("pickup");
            Destroy(gameObject);
        }
        
    }
}
