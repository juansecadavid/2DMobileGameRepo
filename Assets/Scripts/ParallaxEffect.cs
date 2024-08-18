using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float _length, _startPos;
    public GameObject cam;
    public float parallaxEffectMultiplier;

    void Start()
    {
        _startPos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffectMultiplier));
        float dist = (cam.transform.position.x * parallaxEffectMultiplier);

        Vector3 position = transform.position;
        position = new Vector3(_startPos + dist, position.y, position.z);
        transform.position = position;
        
        if (temp > _startPos + _length) _startPos += _length;
        else if (temp < _startPos - _length) _startPos -= _length;
    }
}
