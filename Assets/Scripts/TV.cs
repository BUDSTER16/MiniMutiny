using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    [SerializeField] private Canvas tooltip;

    private TaskManager taskManager;

    private bool watched = false;

    private void Start()
    {
        taskManager = FindObjectOfType<TaskManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !watched)
        {
            tooltip.enabled = true;
            if (Input.GetButton("Interact"))
            {
                CollectInfo();
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

    private void CollectInfo()
    {
        watched = true;
        taskManager.RelayProgress();
        tooltip.enabled = false;
    }

    public bool WasWatched()
    {
        return watched;
    }

    public void ResetTask()
    {
        watched = false;
    }
}
