using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public GameObject warning;
    private bool firstTime;

    void Start()
    {
        firstTime = true;
        warning.SetActive(false);
    }

    void OnCollisionEnter2D()
    {
        StartCoroutine(DisplayWarning());
    }

    private IEnumerator DisplayWarning()
    {
        if(firstTime)
        {
            warning.SetActive(true);
            yield return new WaitForSeconds(2f);
            warning.SetActive(false);
            firstTime = false;
        }
    }
}
