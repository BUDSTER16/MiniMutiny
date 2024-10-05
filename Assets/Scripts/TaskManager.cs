using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    private string[] tasks = new string[] {"Levers", "Sensors", "Relay", "LED"};
    Queue<string> taskList = new Queue<string>();

    private string activeTask;

    [Header("Task UI")]
    [SerializeField] private TextMeshProUGUI taskTitle;
    [SerializeField] private TextMeshProUGUI taskDetails;

    //Lever Task Variables
    int leverCount = 3;
    int leversPulled = 0;
    [Header("Required Lever Objects")]
    [SerializeField] private GameObject[] levers;
    

    public void QueueTasks()
    {
        string swapTask;

        for(int i = 0; i < tasks.Length; i++)
        {
            int swapnum = Random.Range(0, tasks.Length);
            swapTask = tasks[i];
            tasks[i] = tasks[swapnum];
            tasks[swapnum] = swapTask;
        }

        foreach (string task in tasks)
        {
            taskList.Enqueue(task);
        }
    }

    public void ActivateTask()
    {
        if(taskList.Count > 0)
        {
            activeTask = taskList.Dequeue();
            StartTask();
        }
        else
        {
            QueueTasks();
            ActivateTask();
        }
    }

    public void StartTask()
    {
        switch(activeTask)
        {
            case "Levers":
                LeverTask();
                break;
            case "Sensors":
                SensorTask();
                break;
            case "Relay":
                RelayTask();
                break;
            case "LED":
                LEDTask();
                break;
        }
    }

    private void LeverTask()
    {
        taskTitle.text = "Pull The Levers";
        taskDetails.text = "Find " + leverCount + " Levers and pull them!";

        foreach(GameObject lever in levers)
        {
            lever.SetActive(true);
        }
    }

    public void LeverProgress()
    {
        leversPulled++;

        if(leversPulled >= leverCount)
        {
            CompleteTask();
            foreach (GameObject lever in levers)
            {
                lever.SetActive(false);
            }
        }
    }


    private void SensorTask()
    {
        taskTitle.text = "Calibrate The Sensor";
        taskDetails.text = "Find the sensor and press the buttons to calibrate it! (get the needle into the green)";
    }

    private void RelayTask()
    {
        taskTitle.text = "Warn The Captain";
        taskDetails.text = "Find the screen and use it to get info about an upcoming corner then relay the information to the captain";
    }

    private void LEDTask()
    {
        taskTitle.text = "Replace The LED";
        taskDetails.text = "Find the new LED and use it to replace the old LED";
    }

    private void CompleteTask()
    {
        taskTitle.text = "Task Complete";
        taskDetails.text = "Sit back and relax or explore and plan your night";
    }
}
