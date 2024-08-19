using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFixer : MonoBehaviour
{
    [SerializeField] private Light2D _light2D;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        _light2D.lightCookieSprite = _spriteRenderer.sprite;
    }
}
