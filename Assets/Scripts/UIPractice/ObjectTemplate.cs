using System;
using System.Collections;
using System.Collections.Generic;
using UIPractice;
using UnityEngine;
using UnityEngine.UI;

public class ObjectTemplate : MonoBehaviour
{
    public enum ObjectType
    {
        Weapon,
        Shield,
        Gauntlet
    }

    [SerializeField] public ObjectType _objectType;

    [SerializeField, TextArea(3, 10)] public string _description;

    [SerializeField] public Sprite itemImage;

    private void Start()
    {
        itemImage = gameObject.GetComponent<Image>().sprite;
    }

    public void ClickedBtn()
    {
        if (GameEvents.OnButtonClicked != null)
        {
            GameEvents.OnActivateDisplayObject?.Invoke();
            GameEvents.OnButtonClicked?.Invoke(this);
        }
    }
}
