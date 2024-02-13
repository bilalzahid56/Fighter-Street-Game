using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool player, enemy;
    public LayerMask layer;
    private float radius = 1;
    public float damage; 
 
    public GameObject fxParticles;
    private CharacterAttackPOints hitSound;
   
    void Start()
    {
        hitSound = GetComponent<CharacterAttackPOints>();
    
    }

    
    void Update()
    {
        DetectCollision();
    }
    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, layer);
         if(hit.Length>0)
        {
            if(player)
            {
                Vector3 hitpos = hit[0].transform.position;
                hitpos.y += 1.3f;
                if(hit[0].transform.forward.x >0)
                {
                    hitpos.x += 0.3f;
                }
                if (hit[0].transform.forward.x < 0)
                {
                    hitpos.x -= 0.3f;
                }
                Instantiate(fxParticles, hitpos, Quaternion.identity);
                if(gameObject.CompareTag("Left Leg") || gameObject.CompareTag("Left Hand"))
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage,true);
                    
                }
                else
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                  
                }

            }
            if(enemy)
            {
                hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
            }
         }
        gameObject.SetActive(false);
    }
}
