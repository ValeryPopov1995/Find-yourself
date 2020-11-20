using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugLogUI : MonoBehaviour
{
    Text txt;
    float[] deltaFPS = new float[10]; int it;

    private void Start()
    {
        txt = GetComponent<Text>();
    }

    private void Update()
    {
        deltaFPS[it] = Time.deltaTime; if (it < 9) it++; else it = 0;
        float deltaTime = 0;
        foreach (var item in deltaFPS) deltaTime += item;
        deltaTime /= 10;
        txt.text = "fps " + 1/deltaTime;
    }
}
