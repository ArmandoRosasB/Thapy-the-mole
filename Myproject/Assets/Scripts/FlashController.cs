using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashController : MonoBehaviour
{
    
    [SerializeField] private float cooldown;
    [SerializeField] private float lightsOnDuration; 
    private bool flash;
    private bool lightsOn;
    private float tiempoActual;
    private UnityEngine.Rendering.Universal.Light2D globalLight;

    public Button lightButton;
    public Sprite on;
    public Sprite off;

    private void Start() {
        tiempoActual = lightsOnDuration;
        globalLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        flash = true;
        lightsOn = false;

        lightButton.GetComponent<Image>().sprite = on;
        lightButton.enabled = true;
    }

    private void Update()
    {
        if (lightsOn)
        {
            LightsOff();

        }
        if (!flash)
        {
            CheckCooldown();
        }


        
    }

    private void CheckCooldown()
    {
        tiempoActual -= Time.deltaTime;

        if (tiempoActual <= 0)
        {
            flash = true;
            tiempoActual = lightsOnDuration;

            lightButton.GetComponent<Image>().sprite = on;
            lightButton.enabled = true;
        }
    }


    private void LightsOff()
    {
        tiempoActual -= Time.deltaTime;

        if (tiempoActual <= 0)
        {
            globalLight.intensity = 0;
            tiempoActual = cooldown;
            lightsOn = false;
            flash = false;
        }
        
    }

    public void LightsOn()
    {
        if (flash && !lightsOn)
        {
                globalLight.intensity = .8f;
                lightsOn = true;
        }

        lightButton.GetComponent<Image>().sprite = off;
        lightButton.enabled = false;
    }

}
