using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Collider _collider;
    private Transform _coinTransform;
    private CapsuleCollider _capsuleCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        _coinTransform = GetComponent<Transform>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
