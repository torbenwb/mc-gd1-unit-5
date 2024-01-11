using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    public float playerHealth;

    public void TakeDamage(float damage)
    {
        if (playerHealth <= 0) return;
        GameFeel.AddCameraShake(0.1f);
        playerHealth -= damage;
        PlayerUI.UpdateHealth((int)playerHealth);
        if(playerHealth <= 0)
        {
            GameManager.Restart();

        }
    }

    public void Heal(float amount){
        if (playerHealth <= 0) return;
        playerHealth+=amount;
        PlayerUI.UpdateHealth((int)playerHealth);
    }

    public static bool TryDamageTarget(GameObject target, float damage)
    {
        Health targetHealth = target.GetComponent<Health>();

        if (targetHealth)
        {
            if (damage < 0) targetHealth.Heal(-damage);
            else targetHealth.TakeDamage(damage);
            return true;
        }
        return false;
    }
}  