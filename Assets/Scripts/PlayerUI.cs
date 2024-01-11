using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI instance;

    public Health playerHealth;
    public Image[] heartImages;
    int health = 0;

    void Awake()
    {
        playerHealth = FindObjectOfType<Health>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerHealth) return;

        //if (health != playerHealth.healthAmount) UpdateHealth();
    }

    public static void UpdateHealth(int amount)
    {
        for (int i = 0; i < instance.heartImages.Length; i++)
        {
            if (i < amount) instance.heartImages[i].enabled = true;
            else instance.heartImages[i].enabled = false;
        }
    }
}
