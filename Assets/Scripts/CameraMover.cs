using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    private Vector3 camOffset = new Vector3(0f, 0f,-6f);
    private Vector3 velocity = Vector3.zero;
    private float catchTime = 0.2f;

    [SerializeField]private Transform player;


    private void Update()
    {
        Vector3 playerPos = player.position + camOffset;
        transform.position = Vector3.SmoothDamp(transform.position, playerPos, ref velocity, catchTime);
    }


}
