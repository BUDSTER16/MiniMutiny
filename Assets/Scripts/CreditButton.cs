using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditButton : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Destroy(GameObject.FindGameObjectWithTag("Music"));
    }

    public void Retry()
    {
        SceneManager.LoadScene("Roomba");
    }
}
