using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashController : MonoBehaviour
{
    
    [SerializeField] private float cooldown;
    [SerializeField] private float lightsOnDuration; 
    private bool flash;
    private bool lightsOn;
    private float tiempoActual;
    private UnityEngine.Rendering.Universal.Light2D globalLight;

    private void Start() {
        tiempoActual = lightsOnDuration;
        globalLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        flash = true;
        lightsOn = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && flash && !lightsOn)
        {
                globalLight.intensity = .8f;
                lightsOn = true;
            
        }

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

}
