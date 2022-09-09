using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Celebs : MonoBehaviour
{
    [System.Serializable]
    public class Star
    {
        public Sprite Face;
        public string Name;
        public int Add;
        public float Mult;
        public int Cost;
        public AudioClip clip;
        public int Stars;
    }
    [System.Serializable]
    public class StarTiers
    {
        public Star[] Stars;
    }
        public StarTiers[] starTiers;
        public List<Star> invent;
        public Clicker net;
        public GameObject[] places;
        public TextMeshProUGUI mess;
        public GameObject mes;
        public GameObject nam;
        public TextMeshProUGUI sell1;
        public TextMeshProUGUI sell2;
        public TextMeshProUGUI sell3;
        public TextMeshProUGUI sell4;
        private Star select;
        public Clicker clicker;
        public GameObject face;
        private int tier;
        private int rand2;
        private bool box;



    private void Start()
    {
        mes.SetActive(false);
        nam.SetActive(false);
        face.SetActive(false);
        invent.Add(starTiers[0].Stars[1]);
        invent.Add(starTiers[0].Stars[0]);
        places[0].GetComponent<Image>().sprite = invent[0].Face;
        places[0].GetComponent<Image>().color = Color.white;
        places[1].GetComponent<Image>().sprite = invent[1].Face;
        places[1].GetComponent<Image>().color = Color.white;
    }

    public void T1B()
    {
        if(invent.Count < 8)
        {
            if (net.Net >= 100)
            {
                net.Net -= 100;
                LootBox(60, 85, 93, 95, 99);
            }
            else
            {
                mess.text = "Insufficient funds";
                mes.SetActive(true);
            }
        }
        else
        {
            mess.text = "Slots Full";
            mes.SetActive(true);
        }
    }
    public void T2B()
    {
        if (invent.Count < 8)
        {
            if (net.Net >= 500)
            {
                net.Net -= 500;
                LootBox(20, 50, 60, 85, 95);
            }
            else
            {
                mess.text = "Insufficient funds";
                mes.SetActive(true);
            }
        }
        else
        {
            mess.text = "Slots Full";
            mes.SetActive(true);
        }
    }
    public void T3B()
    {
        if (invent.Count < 8)
        {
            if (net.Net >= 2000)
            {
                net.Net -= 2000;
                LootBox(5, 30, 45, 65, 85);
            }
            else
            {
                mess.text = "Insufficient funds";
                mes.SetActive(true);
            }
        }
        else
        {
            mess.text = "Slots Full";
            mes.SetActive(true);
        }
    }
    public void exit()
    {
        mes.SetActive(false);
        nam.SetActive(false);
        face.SetActive(false);
    }

    public void sell(int slot)
    {
        if (invent.Count > slot-1)
        {
            sell1.text = "Sell " + invent[slot-1].Name+"?";
            sell2.text = "Adds: " + invent[slot - 1].Add;
            sell3.text = "Multiplier: " + invent[slot - 1].Mult;
            sell4.text = "Sell " + invent[slot - 1].Cost;
            mess.text = "";
            select = invent[slot - 1];

            mes.SetActive(true);
            nam.SetActive(true);
        }
    }
    public void selling()
    {
        if (clicker.Net + select.Cost >= 0)
        {
            clicker.Net += select.Cost;
            invent.Remove(select);
            places[invent.Count].GetComponent<Image>().color = Color.black;
            places[invent.Count].GetComponent<Image>().sprite = null;

            exit();
        }
        else
        {
            exit();
            mess.text = "Insufficient funds";
            mes.SetActive(true);
        }
    }
    public void LootBox(int S2,int S3, int S4, int S5, int S6)
    {
        int rand = Random.Range(0, 100);
        if (rand < S2)
        {
            rand2 = Random.Range(0, starTiers[1].Stars.Length);
            tier = 1;
        }
        else if (rand < S3)
        {
            rand2 = Random.Range(0, starTiers[2].Stars.Length);
            tier = 2;
        }
        else if (rand < S4)
        {
            rand2 = Random.Range(0, starTiers[3].Stars.Length);
            tier = 3;
        }
        else if (rand < S5)
        {
            rand2 = Random.Range(0, starTiers[4].Stars.Length);
            tier = 4;
        }
        else if (rand < S6)
        {
            rand2 = Random.Range(0, starTiers[5].Stars.Length);
            tier = 5;
        }
        else
        {
            rand2 = Random.Range(0, starTiers[6].Stars.Length);
            tier = 6;
        }
        for (int i = 0; i < invent.Count; i++)
        {
            if (invent[i] == starTiers[tier].Stars[rand2])
            {
                box = false;
            }
        }
        if (box)
        {
            invent.Add(starTiers[tier].Stars[rand2]);
            places[invent.Count - 1].GetComponent<Image>().color = Color.white;
            mess.text = "You got " + invent[invent.Count - 1].Name;
            face.GetComponent<Image>().sprite = invent[invent.Count - 1].Face;
            mes.SetActive(true);
            face.SetActive(true);
            box = true;
        }
        else
        {
            box = true;
            if(S2 == 60)
            {
                LootBox(60, 85, 93, 95, 99);
            }
            else if(S2 == 20)
            {
                LootBox(20, 50, 60, 85, 95);
            }
            else
            {
                LootBox(5, 30, 45, 65, 85);
            }
        }
    }
    private void Update()
    {
        for(int i = 0; i < invent.Count; i++)
        {
            places[i].GetComponent<Image>().sprite = invent[i].Face;
        }
    }
}