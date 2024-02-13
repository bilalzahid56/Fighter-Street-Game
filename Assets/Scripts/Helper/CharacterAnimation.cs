using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;
  

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  Walk(bool ask)
    {
        anim.SetBool("Movement", ask);
    }
    public void  Punch1()
    {
        anim.SetTrigger("Punch1");
    }
    public void Punch2()
    {
        anim.SetTrigger("Punch2");
    }
    public void Punch3()
    {
        anim.SetTrigger("Punch3");
    }

    public void Kick1()
    {
        anim.SetTrigger("Kick1");
    }
    public void Kick2()
    {
        anim.SetTrigger("Kick2");
    }
    public void Death()
    {
        anim.SetTrigger("Death");
    }
    public void Run(bool run)
    {
        anim.SetBool("Run", run);
    }
    public void FireBall()
    {
        anim.SetTrigger("FireBall");
    }
    public void EnemyMovement( bool ask)
    {
        anim.SetBool("Movement", ask);
    }
    public void EnemyAttack(int attack)
    {
        if(attack ==0)
        anim.SetTrigger("Attack1");

        if(attack ==1)
        anim.SetTrigger("Attack2");
    }
    
    public void EnemyHit()
    {
        anim.SetTrigger("Hit");
    }
    public void EnemyDeath()
    {
        anim.SetTrigger("Death");
    }



}


















