using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBarImage;

    void Update()
    {
        healthBarImage.fillAmount = health / maxHealth;
        health = Mathf.Clamp(health, 0f, maxHealth);
    }

    public void Damage(int damageAmout)
    {
        health -= damageAmout;
    }

    public void Heal(int healAmout)
    {
        health += healAmout;
    }
}
