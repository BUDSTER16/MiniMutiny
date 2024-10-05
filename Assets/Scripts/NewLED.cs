using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLED : MonoBehaviour
{
    [SerializeField] private Canvas tooltip;

    private TaskManager taskManager;

    private void Start()
    {
        taskManager = FindObjectOfType<TaskManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tooltip.enabled = true;
            if (Input.GetButton("Interact"))
            {
                TakeLED();
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

    private void TakeLED()
    {
        taskManager.gotLED();
        this.gameObject.SetActive(false);
    }
}
