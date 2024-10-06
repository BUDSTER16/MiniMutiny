using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPedestal : MonoBehaviour
{
    [SerializeField] private Canvas tooltip;
    [SerializeField] private GameObject wall;
    private GameManager gameManager;

    [Header("Access Item")]
    [SerializeField] private string unlockItem;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tooltip.enabled = true;
            if (Input.GetButton("Interact") && gameManager.HasCollectable(unlockItem))
            {
                DisableWall();
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

    private void DisableWall()
    {
        wall.SetActive(false);
    }
}
