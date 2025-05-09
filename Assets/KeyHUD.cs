using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;



public class KeyHUD : MonoBehaviour
{

    public Image Key_HUD;
    void Update()
    {
        if(PlayerStatsManager.Instance.hasBossKey)
        {
            Key_HUD.color = Color.white;
        }
        else if(!PlayerStatsManager.Instance.hasBossKey)
        {
            Key_HUD.color = Color.black;
        }
    }

}
