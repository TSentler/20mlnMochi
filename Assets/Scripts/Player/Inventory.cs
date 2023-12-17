using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public int DiamondCount = 0;
    //public UnityEvent<Transform> OnDiamondTaken = new();

    public void collect()
    {
        DiamondCount++;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }


}
