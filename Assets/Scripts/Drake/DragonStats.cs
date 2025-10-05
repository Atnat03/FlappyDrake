using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DragonStats : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] int currentScore = 0;
    [SerializeField] Text txtScore;


    [Header("Health")]
    [SerializeField] int currentHealth = 0;
    [SerializeField] int maxHealth = 3;

    [SerializeField] HP_UI ui;

    void Start()
    {
        AddScore(0);
        currentHealth = maxHealth;
    }

    public void AddScore(int value)
    {
        currentScore += value;
        txtScore.text = currentScore.ToString();
    }

    [ContextMenu("Take Dmg")]
    public void TakeDamage()
    {
        currentHealth--;
        ui.UpdateUI(currentHealth);
    }

    public void AddHealth()
    {
        if (currentHealth == maxHealth)
        {
            Debug.Log("Full HP");
            return;
        }
        
        currentHealth++;
        ui.UpdateUI(currentHealth);
    }
}
