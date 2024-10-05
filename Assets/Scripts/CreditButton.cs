using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditButton : MonoBehaviour
{
    private Button backToMenu;

    private void Start()
    {
        backToMenu = GetComponent<Button>();
        backToMenu.onClick.AddListener(Menu);
    }

    void Menu()
    {
        //SceneManager.LoadScene(MainMenu);
    }
}
