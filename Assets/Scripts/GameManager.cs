﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 20;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
