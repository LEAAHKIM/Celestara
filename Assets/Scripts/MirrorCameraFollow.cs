using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorCameraFollow : MonoBehaviour
{
    public Transform original; // Reference to the player's transform
    public Transform upsideDown;
    public Vector3 offset = new Vector3(0, 5, -10); // Offset from the player
    public float smoothSpeed = 0.125f; // Smoothness of the camera movement

    void LateUpdate()
    {
        // Calculate the desired position with the offset
        Vector3 midpoint = (original.position + upsideDown.position) / 2;
        Vector3 desiredPosition = midpoint + offset;

        // Smoothly interpolate between the current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Update the camera's position
        transform.position = smoothedPosition;
    }
}
