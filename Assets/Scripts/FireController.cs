using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireController : MonoBehaviour
{
    [SerializeField] private Light2D _light2D;
    private float startLightIntensity;
    private float currentLightIntensity;
    private WoodCounter _woodCounter;
    [SerializeField] private float _intervalReduce;
    [SerializeField] private Score _score;

    private float Incrementer;

    private float decrementer;
    // Start is called before the first frame update
    void Start()
    {
        _woodCounter = FindObjectOfType<WoodCounter>();
        startLightIntensity = _light2D.intensity;
        currentLightIntensity = startLightIntensity;

        Incrementer = startLightIntensity / 15;
        decrementer = startLightIntensity / 10;
        InvokeRepeating("ReduceLight", 5, _intervalReduce);
    }

    // Update is called once per frame
    void Update()
    {
        currentLightIntensity = Mathf.Clamp(currentLightIntensity, 0, startLightIntensity);
        _light2D.intensity = currentLightIntensity;
    }

    private void EnhanceLight()
    {
        currentLightIntensity += Incrementer;
        Debug.Log("CalledToEnhance");
        _score.IncreaseScore(5);
    }

    private void ReduceLight()
    {
        currentLightIntensity -= decrementer;
        if (currentLightIntensity <= 0)
        {
            StopDecreasing();
        }
    }

    private void StopDecreasing()
    {
        CancelInvoke("ReduceLight");
        Debug.Log("Llamé a finlizar el juego");
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_woodCounter.ReduceWood())
            {
                EnhanceLight();
            }
            
        }
    }
}
