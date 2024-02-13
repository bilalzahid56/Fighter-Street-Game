using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Transform player;
   
    private bool follow;
    private bool attack;

    private CharacterAnimation enemyanim;

    private float attackPlayer= 1f;
    private float chasePlayer = 1f;
    private float speed = 4;
    private float defaultTimer;
    private float timer = 2f;
   
  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyanim = GetComponentInChildren<CharacterAnimation>();
        
       
        player = GameObject.FindWithTag("Player").transform;
        follow = true;

        defaultTimer = timer;
        
    }

    // Update is called once per frame
    void Update()
    {
      
        AttackToPlayer();
    }
    private void FixedUpdate()
    {
        PlayerFOllow();
    }
    void PlayerFOllow()
    {
        if (!follow)
            return;


        if(Vector3.Distance(transform.position,player.transform.position) > chasePlayer)
        {
            transform.LookAt(player);
            rb.velocity = transform.forward * speed;
            enemyanim.EnemyMovement(true);
            attack = false;
        }


        if(Vector3.Distance(transform.position,player.transform.position )< attackPlayer)
        {
            rb.velocity = Vector3.zero;
            enemyanim.EnemyMovement(false);
            attack =  true;
        }

       
    }
    void AttackToPlayer()
    {
        if (!attack)
            return;

        defaultTimer +=Time.deltaTime;
        if(defaultTimer > timer)
        {
            enemyanim.EnemyAttack(Random.Range(0, 2));
            defaultTimer = 0;
            follow = false;
        }

        if(Vector3.Distance(transform.position,player.transform.position ) > chasePlayer+attackPlayer)
        {
            follow = true;
            attack = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.CompareTag("FireBall"))
        {
            Destroy(this.gameObject);
        }
    }
}
