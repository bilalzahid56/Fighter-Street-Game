using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawnPlayerPoint;
    public GameObject player1;
    public GameObject player2;
    public GameObject activePlayer;
    private CharacterAnimation enemyAnim;
    public static int numberScore;
    [SerializeField] private  Text score;
    void Start()
    {
        // player = GameObject.FindWithTag("Player");
        // if(player.activeInHierarchy)
        enemyAnim = GetComponent<CharacterAnimation>();

        score = GameObject.FindWithTag("Score").GetComponent<Text>();

    }
    private void Update()
    {
        score.text = "Score : " + numberScore;
    }

    public void InvokeEnemy()
    {
        InvokeRepeating("SpawnEnemy", 1f, 5f);

    }
   
   public void SpawnEnemy()
   {
        Instantiate(enemy, transform.position, Quaternion.identity);
        Debug.Log("KK");
   }
    public void Player1Spawn()
    {
        Instantiate(player1, spawnPlayerPoint.transform.position, spawnPlayerPoint.transform.rotation);
    }
    public void Player2Spawn()
    {
        Instantiate(player2, spawnPlayerPoint.transform.position, spawnPlayerPoint.transform.rotation);
    }
    public void PauseEveryThing()
    {
        Time.timeScale = 0f;
    }
    public void ResumeEveryThing()
    {
        Time.timeScale = 1f;

    }
    public void LoadSceneRestart()
    {
        SceneManager.LoadScene(0);
    }



}















