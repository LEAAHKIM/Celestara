using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//attach it to the portal
public class PortalLevel : MonoBehaviour
{
    public int nextLevel;
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            StartCoroutine(loadAfterDelay());
        }
    }

    private IEnumerator loadAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextLevel);
    }
}
