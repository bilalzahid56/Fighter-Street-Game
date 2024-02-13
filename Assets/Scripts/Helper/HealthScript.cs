using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    private Image healthBar;
    public float health;
    public bool player;
    public bool characterDeath;
    private CharacterAnimation anim;
    public GameObject gameOver;
    private EnemyMovement enemyMove;
 
    private EnemySpawner count;
    private void Awake()
    {
        healthBar = GameObject.FindWithTag("HealthUI").GetComponent<Image>();
  
        count = GetComponent<EnemySpawner>();
        anim = GetComponentInChildren<CharacterAnimation>();
        if(gameObject.CompareTag("Enemy"))
        {
            enemyMove = GetComponent<EnemyMovement>();
            

        }
    }
    private void Update()
    {
        if(player)
        {
            if(health <=0)
            {
                // gameOver.SetActive(true);
                Invoke("LoadScene", 4f);

            }
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    public void ApplyDamage(float damage , bool death)
    {
        if (characterDeath)
            return;

        health -= damage;
      
        if(player)
        {
            HealthBarDecreases(health);
        }

        if(player)
        {
            if (health <= 0)
            {
                anim.Death();
                characterDeath = true;

            }
        }
       

        if(!player)
        {
            if(health ==0)
            {
                EnemySpawner.numberScore += 5;
                anim.EnemyDeath();
            }
            else if(health <10)
            {
                enemyMove.enabled = false;
            }
            else
            {
                anim.EnemyHit();
            }
        }

    }
 
    public void HealthBarDecreases(float value)
    {
        value /= 100;

        if (value < 0f)
            value = 0f;
        healthBar.fillAmount = value;

    }
}
