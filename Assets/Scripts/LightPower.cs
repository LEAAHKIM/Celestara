using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightPower : MonoBehaviour
{
    //attach to twin2
    private GameObject light;
    public Image lightBar;
    public GameObject lightManager;
    public float maxLight = 100f;
    private float currentLight;  
    private Animator anim;
    private float fillDuration = 1f;
    public GameObject firstText;
    private bool firstTime = true;
    public Camera mainCamera;
    public float newZoomLevel = 3f;

    void Start()
    {
        currentLight = 0;
        anim = GetComponent<Animator>();
        lightManager.SetActive(false); 
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("bubbleLight"))
        {
            Destroy(other.gameObject);
            IncreaseLight(10); //when object is collected, increase fill by 10 

        }
    }

    public void IncreaseLight(float fillAmount)
    {
        currentLight += fillAmount;
        if(currentLight > maxLight)
        {
            currentLight = maxLight;
        }
        lightManager.SetActive(true);
        transitionLightBar();
    }

    private IEnumerator UpdateLightBar(float targetAmount)
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

        if(firstTime)
        {
            firstText.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            firstText.SetActive(false);
            AdjustCameraZoom();
            firstTime = false;
        }
        yield  return new WaitForSeconds(1f);
        lightManager.SetActive(false);
    }

    private void transitionLightBar()
    {
        anim.Play("lightManagerAnim");
        StartCoroutine(UpdateLightBar(currentLight / maxLight));
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
