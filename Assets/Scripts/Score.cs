using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI _scoreTextMeshProUGUI;

    private int _score=0;
    
    public void IncreaseScore()
    {
        _score++;
        UpdateScore();
    }

    public void DecreaseScore()
    {
        _score--;
        UpdateScore();
    }

    private void UpdateScore()
    {
        _scoreTextMeshProUGUI.text = $"SCORE: {_score}";
    }
}
