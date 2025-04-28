using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay: MonoBehaviour
{
    public int health;
    public int maxHealth;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;



    // Update is called once per frame
    void Update()
    {
        health = (int)PlayerStatsManager.Instance.currentHealth;
        maxHealth = (int)PlayerStatsManager.Instance.maxHealth;

       foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }
}
