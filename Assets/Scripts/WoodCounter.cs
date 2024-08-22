using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class WoodCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woodCounter;
    private int _wood = 0;

    public void AddWood()
    {
        _wood++;
        UpdateWoodCounter();
    }

    public bool ReduceWood()
    {
        _wood--;
        if (_wood < 0)
        {
            _wood = 0;
            return false;
        }
        UpdateWoodCounter();
        return true;
    }

    private void UpdateWoodCounter()
    {
        woodCounter.text = $"Wood: {_wood}";
    }
}
