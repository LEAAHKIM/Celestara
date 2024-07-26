using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float initialY;
    void Start()
    {
        initialY = transform.position.y;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, initialY, transform.position.z);
        }
    }
}
