using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Slider easeHealthBar;
    public float maxHealth = 100f;
    private float health;
    private float lerpSpeed = 0.05f;

    void Start()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
        easeHealthBar.maxValue = maxHealth;
        easeHealthBar.value = health;
    }

    void Update()
    {
        if (healthBar.value != health)
        {
            healthBar.value = health;
        }

        easeHealthBar.value = Mathf.Lerp(easeHealthBar.value, health, lerpSpeed);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
    }
}
