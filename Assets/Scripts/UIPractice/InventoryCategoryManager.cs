using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryCategoryManager : MonoBehaviour
{
    [SerializeField] private GameObject[] UiGrids;
    [SerializeField] private TMP_Dropdown _dropdown;
    
    public void ChangeUIGrid()
    {
        int index = _dropdown.value;
        for (int i = 0; i < UiGrids.Length; i++)
        {
            if (i == index)
            {
                UiGrids[i].SetActive(true);
            }
            else
            {
                UiGrids[i].SetActive(false);
            }
        }
    }
}
