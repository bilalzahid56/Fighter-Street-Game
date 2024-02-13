using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackPOints : MonoBehaviour
{
    public GameObject leftHandPoint, rightHandPoint, leftLegPoint, rightLegPoint;
    private AudioSource sound;
    [SerializeField]
    private AudioClip whoosh_Sound, death_Sound, fall_Sound;
    public GameObject enemy;
    private Rigidbody rb;
    private CharacterAnimation anim;
    public GameObject fireBallPoint;
    public GameObject fireBall;
  
    private void Awake()
    {
        sound = GetComponent<AudioSource>();
   //     rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        anim = GetComponent<CharacterAnimation>();

    }
   
    public void IdleEnemy()
    {
        anim.EnemyMovement(false);
    }
    public void MoveEnemy()
    {
        anim.EnemyMovement(true);
    }
    public void FallSOund()
    { 
        sound.volume = 0.4f;
        sound.clip = fall_Sound;
        sound.Play();
    }

    public void WhooshSound()
    {
        sound.volume = 0.4f;
        sound.clip = whoosh_Sound;
        sound.Play();
    }
    public void DeathSound()
    {
        sound.volume = 0.4f;
        sound.clip = death_Sound;
        sound.Play();
    }
 
    public void lefthandOn()
    {
        leftHandPoint.SetActive(true);

    }
    public void lefthandoff()
    {
        leftHandPoint.SetActive(false);
    }
    public void RighthandOn()
    {
        rightHandPoint.SetActive(true);

    }
    public void Righthandoff()
    {
        rightHandPoint.SetActive(false);

    }
    public void leftLegOn()
    {
        leftLegPoint.SetActive(true);
    }
    public void leftLegoff()
    {
        leftLegPoint.SetActive(false);
    }
    public void rightLegOn()
    {
        rightLegPoint.SetActive(true);
    }
    public void rightLegOff()
    {
        rightLegPoint.SetActive(false);
    }
    public void LeftHandTagOn()
    {
        leftHandPoint.tag = "Left Hand";
    }
    public void LeftHandTagOff()
    {
        leftHandPoint.tag = "Untagged";
    }
    public void LeftLegTagOn()
    {
        leftLegPoint.tag = "Left Leg";
    }
    public void LeftLegTagOff()
    {
        leftLegPoint.tag = "Untagged";
    }
    public void EnemyDisable()
    {
        enemy.SetActive(false);
    }
    public void MoveforwardRunOff()
    {
        rb.velocity = Vector3.zero;
    }
    public void Run()
    {
        rb.velocity = transform.forward * 4;
    }

    public void DisableAnimRun()
    {
        anim.Run(false);
    }
    public void FireBallInstant()
    {
        Instantiate(fireBall, fireBall.transform.position, Quaternion.identity);
    }

}
