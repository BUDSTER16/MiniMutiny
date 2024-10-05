using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [Header("Details")]
    [SerializeField] private string item_name;


    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collect();
    }

    private void Collect()
    {
        gameManager.Collect(item_name);
        Destroy(gameObject);
    }
}
