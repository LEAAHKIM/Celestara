using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public PlayableDirector playable;
    void Start()
    {
        if(playable == null)
        {
            playable = GetComponent<PlayableDirector>();
        }
    }
    public void PlayCutscene()
    {
        if(playable != null)
        {
            playable.Play();
        }
    }

    public void CutsceneEnded()
    {
        Time.timeScale = 1f;
    }
}
