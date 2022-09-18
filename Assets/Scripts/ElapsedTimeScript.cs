using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ElapsedTimeScript : MonoBehaviour
{
    [SerializeField] private Text elapsedTimeText;

    private readonly Stopwatch _stopwatch = new();
    // Start is called before the first frame update
    void Start()
    {
        _stopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        var ts = _stopwatch.Elapsed;
        elapsedTimeText.text  = $"{ts.Minutes:00}:{ts.Seconds:00}";
    }
}
