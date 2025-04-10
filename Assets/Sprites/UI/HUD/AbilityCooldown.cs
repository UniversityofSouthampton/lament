using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldown : MonoBehaviour
{
    public Image CooldownImage;
    public float cooldownTime = 0.5f;
    private float cooldownTimer = 0f;
    private bool isCoolingDown = false;

    // Start is called before the first frame update
    void Start()
    {
        CooldownImage.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCoolingDown)
        {
            cooldownTimer -= Time.deltaTime;
            CooldownImage.fillAmount = cooldownTimer / cooldownTime;

            if (cooldownTimer <= 0f)
            {
                isCoolingDown = false;
                CooldownImage.fillAmount = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isCoolingDown)
        {
            TriggerCooldown();
        }
    }
    public void TriggerCooldown()
    {
        cooldownTimer = cooldownTime;
        CooldownImage.fillAmount = 1f;
        isCoolingDown = true;
    }
}
