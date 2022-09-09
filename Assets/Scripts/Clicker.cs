using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clicker : MonoBehaviour
{
    public float Net;
    public TextMeshProUGUI TMPro;
    public Celebs celebs;
    private void Update()
    {
        TMPro.text = "NetWorth: " + Net + "M";
    }
    public void addNet()
    {
        float gain = 1;
        for (int i = 0; i < celebs.invent.Count; i++)
        {
            gain *= celebs.invent[i].Mult;
        }
        for (int i = 0; i < celebs.invent.Count; i++)
        {
            gain += celebs.invent[i].Add;
        }

        Net += gain;
    }
}
