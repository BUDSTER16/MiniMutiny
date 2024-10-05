using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorButton : MonoBehaviour
{
    [SerializeField] private Canvas tooltip;

    private TaskManager taskManager;

    [SerializeField] private float buttonStrenth;
    [SerializeField] private Transform gaugeIndicator; 

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
                Push();
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

    private void Push()
    {
        gaugeIndicator.localPosition += new Vector3(buttonStrenth, 0, 0);
    }
}
