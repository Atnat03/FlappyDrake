using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DragonStats : MonoBehaviour
{
    public Action<bool> OnDead;
    
    [Header("Score")]
    [SerializeField] public int currentScore = 0;
    [SerializeField] Text txtScore;


    [Header("Health")]
    [SerializeField] int currentHealth = 0;
    [SerializeField] int maxHealth = 3;

    [SerializeField] HP_UI ui;
    
    bool isInvincible = false;
    private bool isX2 = false;
    [SerializeField] private GameObject uiScorex2;
    
    SpriteRenderer sprite;

    void Start()
    {
        AddScore(0);
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
        uiScorex2.SetActive(false);
    }

    public void AddScore(int value)
    {
        if (isX2)
            value *= 2;
        
        currentScore += value;
        txtScore.text = currentScore.ToString();
    }

    private void Update()
    {
        if (isInvincible)
        {
            Color randomVividColor = Color.HSVToRGB(
                Random.Range(0f, 1f), 
                1f,                     
                1f                      
            );

            sprite.color = randomVividColor;
        }
        else
        {
            sprite.color = Color.white;
        }
    }

    [ContextMenu("Take Dmg")]
    public void TakeDamage()
    {
        if (isInvincible) return;
        
        if (currentHealth == 1)
        {
            OnDead?.Invoke(false);
        }
        
        currentHealth--;
        ui.UpdateUI(currentHealth);
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
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

    public void TakeInvinsibility()
    {
        StartCoroutine(Invinsible());
    }

    private IEnumerator Invinsible()
    {
        isInvincible = true;
        
        yield return new WaitForSeconds(5f);
        
        isInvincible = false;
    }
    
    public void Getx2()
    {
        StartCoroutine(x2());
    }

    IEnumerator x2()
    {
        isX2 = true;
        uiScorex2.SetActive(true);
        
        yield return new WaitForSeconds(10f);
        
        uiScorex2.SetActive(false);
        isX2 = false;
    }
}
