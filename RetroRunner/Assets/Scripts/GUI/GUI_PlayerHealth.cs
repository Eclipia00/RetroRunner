using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_PlayerHealth : MonoBehaviour
{
    public Health health;
    public Image healthBarImage;
    public Stamina stamina;
    public Image staminaImage;
    
    void Update()
    {
        healthBarImage.fillAmount = health.health.Value / health.maxHealth;
        staminaImage.fillAmount = stamina.stamina.Value / stamina.maxStamina;
    }
}
