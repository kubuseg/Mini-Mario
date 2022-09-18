using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerJumpsScript : MonoBehaviour
{
    [SerializeField] private Text powerJumpsText;

    public void SetPowerJumpsText(int powerJumps)
    {
        powerJumpsText.text = $"Power jumps: {powerJumps}";
    }
}
