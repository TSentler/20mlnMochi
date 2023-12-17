using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Player : MonoBehaviour
{
    public Action onTouched;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Зашёл");
    }

}
