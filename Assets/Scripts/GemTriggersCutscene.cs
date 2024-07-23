using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//attach it to the GEM
public class GemTriggersCutscene : MonoBehaviour
{
    private bool collected = false;
    public GameObject panelToActivate;

    public GameObject asteroid;
    public string sceneName;
    public CutsceneManager cutscene;

    //public GameObject twin1ToDeactivate;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collected)
        {
            collected = true;
            CollectGem();
        }
    }

    void CollectGem()
    {
        if(cutscene != null)
        {
            asteroid.SetActive(true);
            cutscene.PlayCutscene();
            //twin1ToDeactivate.SetActive(false);
        }
        Destroy(gameObject);
    }
}
