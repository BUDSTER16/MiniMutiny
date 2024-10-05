using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldLED : MonoBehaviour
{
    [SerializeField] private Canvas tooltip;

    private TaskManager taskManager;

    private void Start()
    {
        taskManager = FindObjectOfType<TaskManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && taskManager.HasLED())
        {
            tooltip.enabled = true;
            if (Input.GetButton("Interact"))
            {
                Fix();
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

    private void Fix()
    {
        taskManager.LEDProgress();
    }
}
