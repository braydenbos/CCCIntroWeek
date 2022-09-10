using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScreenSwitch : MonoBehaviour
{
    public bool OnMain;
    public RectTransform Shop;
    public RectTransform Main;
    public Image ShopBut;
    public Image MainBut;
    private float timer = 0;
    public bool Move;
    public void ToShop()
    {
        if (OnMain && !Move)
        {
            Move = true;
            MainBut.color = new Color32(255, 0,   217, 255);
            ShopBut.color = new Color32(255, 140, 217, 255);
        }
    }
    public void ToMain()
    {

        if (!OnMain && !Move)
        {
            Move = true;
            MainBut.color = new Color32(255, 140,217, 255);
            ShopBut.color = new Color32(255, 0,  217, 255);
        }
    }

    private void Update()
    {
        if (Move && OnMain)
        {
            timer += Time.deltaTime * 8000;
            Main.position = new Vector2(timer + 718, Main.position.y);
            Shop.position = new Vector2(timer - 1282, Main.position.y);

            if (timer >= 2000)
            {
                OnMain = false;
                Move = false;
                timer = 0;
            }
        }
        if (Move && !OnMain)
        {
            timer -= Time.deltaTime * 8000;
            Main.position = new Vector2(timer + 2724, Main.position.y);
            Shop.position = new Vector2(timer + 718, Main.position.y);

            if (timer <= -2000)
            {
                OnMain = true;
                Move = false;
                timer = 0;
            }
        }

    }
}
