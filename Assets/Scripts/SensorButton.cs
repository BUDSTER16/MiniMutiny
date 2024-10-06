using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorButton : MonoBehaviour
{
    [SerializeField] private Canvas tooltip;

    private TaskManager taskManager;

    [SerializeField] private float buttonStrenth;
    [SerializeField] private Transform gaugeIndicator;

    private float pushCooldownMax = 0.3f;
    private float pushCooldown = 0;

    private void Start()
    {
        taskManager = FindObjectOfType<TaskManager>();
    }

    private void Update()
    {
        if(pushCooldown > 0) { pushCooldown -= Time.deltaTime; }
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
        if(pushCooldown <= 0)
        {
            gaugeIndicator.localPosition += new Vector3(buttonStrenth, 0, 0);
            if(gaugeIndicator.localPosition.x < -0.6)
            {
                gaugeIndicator.localPosition = new Vector3(-0.6f, -0.2f, 0);
            }
            else if (gaugeIndicator.localPosition.x > 0.6)
            {
                gaugeIndicator.localPosition = new Vector3(0.6f, -0.2f, 0);
            }

            pushCooldown = pushCooldownMax;
        }

        if(gaugeIndicator.localPosition.x == 0.25)
        {
            taskManager.SensorProgress();
        }
    }
}
