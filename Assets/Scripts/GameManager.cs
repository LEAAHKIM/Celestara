using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float playerLightPower = 0f;
    public bool firstTime = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
