using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clicker : MonoBehaviour
{
    public float Net;
    public string Net1;
    public TextMeshProUGUI TMPro;
    public Celebs celebs;
    private void Update()
    {
        Net1 = string.Format("{0:0.##}", Net);
        TMPro.text = "NetWorth: " + Net1 + "M";
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
