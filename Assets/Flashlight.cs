using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool isOn;
    public float batteryLife;
    public float batteryLow;
    public AudioClip lightToggle;
    public Light light;

    float lightRange;
    float lightIntensity;
    AudioSource source;

    void Start()
    {
        lightRange = light.range;
        lightIntensity = light.intensity;
        source = GetComponent<AudioSource>();
    }

    void Update()
    {        
        if(Input.GetKeyDown(KeyCode.E))
        {
            isOn = !isOn;
            source.PlayOneShot(lightToggle);
        }

        light.enabled = isOn;
        light.intensity = lightIntensity;

        if (isOn)
        {
            light.range -= Time.deltaTime * lightRange / batteryLife;
            if(light.range <= 0)
            {
                isOn = false;
            }
            else if(light.range / lightRange <= batteryLow)
            {
                light.intensity += Random.Range(-.5f, .5f);
            }
        }
        else
        {
            if (light.range < lightRange)
            { 
                light.range += Time.deltaTime * lightRange / (batteryLife * batteryLow);
            }
        }
    }
}
