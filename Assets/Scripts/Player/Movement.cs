using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private float walk = -4f;
    private float zspeed = -2f;
    private CharacterAttackPOints hitSound;
   


    private CharacterAnimation playeranim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        playeranim = GetComponentInChildren<CharacterAnimation>();
        hitSound = GetComponent<CharacterAttackPOints>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerDontMoveThatWay();
        AnimatePlayerWalk();
        if (transform.position.x < -1f)
        {
            transform.position = new Vector3(-1f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 9f)
        {
            transform.position = new Vector3(9f, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -3.96f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,-3.96f);
        }
        if (transform.position.z > -0.61f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -0.61f);
        }
      
        
    }
    private void FixedUpdate()
    {
        MovementPlayer();
    }
   
    void MovementPlayer()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * walk, rb.velocity.y, Input.GetAxis("Vertical") * zspeed);

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }

    }
    void AnimatePlayerWalk()
    {
        if(Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical")!=0)
        {
            playeranim.Walk(true);
        }
        else
        {
            playeranim.Walk(false);
        }
    }
    void PlayerDontMoveThatWay()
    {
        if (transform.position.x < -1f)
        {
            transform.position = new Vector3(-1f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 9f)
        {
            transform.position = new Vector3(9f, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -3.96f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -3.96f);
        }
        if (transform.position.z > -0.61f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -0.61f);
        }
    }
}
