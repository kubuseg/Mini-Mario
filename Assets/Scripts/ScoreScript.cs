using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int _collectedCoins;
    private GameObject _player;
    private PlayerScript _playerScript;
    
    public void IncrementCollectedCoins()
    {
        _collectedCoins++;
        scoreText.text = _collectedCoins.ToString();
    }
    
}
