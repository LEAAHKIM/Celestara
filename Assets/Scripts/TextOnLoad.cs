using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnLoad : MonoBehaviour
{
    public GameObject textToShow;
    public float displayDuration = 2.5f;
    void Start()
    {
        StartCoroutine(DisplayText());
    }

    IEnumerator DisplayText()
    {
        textToShow.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayDuration);
        textToShow.gameObject.SetActive(false);
    }
}
