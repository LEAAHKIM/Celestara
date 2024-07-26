using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite pressedSprite;
    public Sprite idleSprite;
    public Animator buttonAnimator;
    public GameObject platform; // Assign the platform GameObject in the Inspector
    public float moveSpeed = 2f;
    public float moveDistance = 2f;

    private bool isPressed = false;
    private Vector3 platformStartPos;
    private Vector3 platformEndPos;

    void Start()
    {
        platformStartPos = platform.transform.position;
        platformEndPos = new Vector3(platformStartPos.x, platformStartPos.y + moveDistance, platformStartPos.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPressed)
        {
            isPressed = true;
            spriteRenderer.sprite = pressedSprite;
            //buttonAnimator.SetTrigger("press"); 
            StartCoroutine(MovePlatformUpwards());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && isPressed)
        {
            isPressed = false;
            spriteRenderer.sprite = idleSprite;
            StartCoroutine(MovePlatformDownwards());
        }
    }

    private IEnumerator MovePlatformUpwards()
    {
        float elapsedTime = 0f;
        while (elapsedTime < moveDistance / moveSpeed)
        {
            platform.transform.position = Vector3.Lerp(platformStartPos, platformEndPos, elapsedTime / (moveDistance / moveSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        platform.transform.position = platformEndPos;
    }

    private IEnumerator MovePlatformDownwards()
    {
        float elapsedTime = 0f;
        while (elapsedTime < moveDistance / moveSpeed)
        {
            platform.transform.position = Vector3.Lerp(platformEndPos, platformStartPos, elapsedTime / (moveDistance / moveSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        platform.transform.position = platformStartPos;
    }
}
