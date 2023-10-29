using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private Player _player;
    

    private void OnEnable()
    {
        _player.onTouched += ConsoleMessage;
    }

    private void OnDisable()
    {
        _player.onTouched -= ConsoleMessage;
    }

    private void ConsoleMessage()
    {
        Debug.Log("Объект зашёл");
    }
}
