using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//for scene "text1"
public class ShowText : MonoBehaviour
{
    public GameObject[] texts;
    public int currentIndex = 0;
    public KeyCode key = KeyCode.RightArrow;

    // Start is called before the first frame update
    void Start()
    {
        if(texts != null && texts.Length > 0)
        {
            texts[0].SetActive(true);
        }
    }

    void Update()
    {
        if(texts != null && Input.GetKeyDown(key))
        {
            ShowTextInOrder();
        }
    }

    private void ShowTextInOrder()
    {
        if(currentIndex < texts.Length-1)
        {
            texts[currentIndex].SetActive(false);
            currentIndex++;
            texts[currentIndex].SetActive(true);
        }
        else if(currentIndex == texts.Length -1)
        {
            texts[currentIndex].SetActive(false);
            SceneManager.LoadSceneAsync(2);
        }
    }
}
