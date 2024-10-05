using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private Canvas tooltip;

    private TaskManager taskManager;

    private bool flipped = false;

    private void Start()
    {
        taskManager = FindObjectOfType<TaskManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !flipped)
        {
            tooltip.enabled = true;
            if (Input.GetButton("Interact"))
            {
                Flip();
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

    private void Flip()
    {
        flipped = true;
        GetComponent<SpriteRenderer>().flipX = true;
        taskManager.LeverProgress();
    }

    public void Unflip()
    {
        flipped = false;
        GetComponent<SpriteRenderer>().flipX = false;
    }
}
