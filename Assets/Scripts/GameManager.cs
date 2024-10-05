using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool key = false, dGear = false;

    bool daytime = true;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Collect(string collect_name)
    {
        switch (collect_name)
        {
            case "Key":
                key = true;
                Debug.Log("Key Collected!");
                break;
            case "Diamond Gear":
                dGear = true;
                Debug.Log("Diamond Gear Collected!");
                break;
        }
    }

    public bool HasCollectable(string collect_name)
    {
        bool collected = false;

        switch (collect_name)
        {
            case "Key":
                collected = key;
                break;
            case "Diamond Gear":
                collected = dGear;
                break;
        }

        return collected;
    }

    public bool isDaytime()
    {
        return daytime;
    }

    
}
