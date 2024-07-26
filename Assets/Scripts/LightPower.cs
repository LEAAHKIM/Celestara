using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LightPower : MonoBehaviour
{
    public Image lightBar;
    public GameObject lightManager;
    public float maxLight = 100f;
    private float currentLight;  
    private Animator anim;
    private float fillDuration = 1f;
    public GameObject firstText;
    public Camera mainCamera;
    public float newZoomLevel = 3f;

    void Start()
    {
        currentLight = GameManager.Instance.playerLightPower; // Initialize with the value from GameManager
        anim = GetComponent<Animator>();
        lightManager.SetActive(false); 
        UpdateLightBar(); // Update the light bar UI at the start
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("bubbleLight"))
        {
            Debug.Log("Collected a light power: " + other.gameObject.name); // Debug log for collision
            Destroy(other.gameObject);
            IncreaseLight(10); //when object is collected, increase fill by 10 
        }
    }

    public void IncreaseLight(float fillAmount)
    {
        GameManager.Instance.playerLightPower += fillAmount;
        if(GameManager.Instance.playerLightPower > maxLight)
        {
            GameManager.Instance.playerLightPower = maxLight;
        }
        currentLight = GameManager.Instance.playerLightPower;
        lightManager.SetActive(true);
        transitionLightBar();
    }

    private IEnumerator UpdateLightBarCoroutine(float targetAmount)
    {
        yield return new WaitForSeconds(0.5f); 
        float startFillAmount = lightBar.fillAmount; //current amount 
        float elapsedTime = 0f;
        while(elapsedTime < fillDuration)
        {
            elapsedTime += Time.deltaTime;
            lightBar.fillAmount = Mathf.Lerp(startFillAmount, targetAmount, elapsedTime / fillDuration);
            yield return null;
        }
        lightBar.fillAmount = targetAmount;

        if(GameManager.Instance.firstTime)
        {
            firstText.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            firstText.SetActive(false);
            //AdjustCameraZoom();
            GameManager.Instance.firstTime = false;
        }
        yield return new WaitForSeconds(1f);
        lightManager.SetActive(false);
    }

    private void transitionLightBar()
    {
        anim.Play("lightManagerAnim");
        StartCoroutine(UpdateLightBarCoroutine(currentLight / maxLight));
    }

    private void UpdateLightBar()
    {
        lightBar.fillAmount = currentLight / maxLight;
    }

    private void AdjustCameraZoom()
    {
        if(mainCamera.orthographic)
        {
            mainCamera.orthographicSize = newZoomLevel; 
        }
        else 
        {
            mainCamera.fieldOfView = newZoomLevel;
        }
    }
}
