using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int _collectedCoins;

    public void IncrementCollectedCoins()
    {
        scoreText.text = $"Score: {++_collectedCoins}";
    }
    
}
