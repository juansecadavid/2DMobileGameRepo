using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            WoodCounter woodCounter = other.GetComponent<WoodCounter>();
            if (woodCounter!=null)
            {
                woodCounter.AddWood();
                gameObject.SetActive(false);
            }
        }
    }
}
