using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UIPractice;
using UnityEngine;
using UnityEngine.UI;

public class ShowMoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _description;
    private GameObject childPanel;
    public Image _image;

    private void Start()
    {
        childPanel = GameObject.Find("PanelShowItem");
        GameEvents.OnActivateDisplayObject += ActivateDisplay;
        childPanel.SetActive(false);
    }

    void ActivateDisplay()
    {
        childPanel.SetActive(true);
    }
    
    void OnEnable()
    {
        GameEvents.OnButtonClicked += HandleButtonClicked;
    }

    void OnDisable()
    {
        GameEvents.OnButtonClicked -= HandleButtonClicked;
    }

    void HandleButtonClicked(ObjectTemplate item)
    {
        //Debug.Log("Botón clicado: " + item.name);
        // Aquí puedes agregar cualquier lógica que dependa del clic
        _title.text = item._objectType.ToString();
        _description.text = item._description;
        _image.sprite = item.itemImage;
    }
}
