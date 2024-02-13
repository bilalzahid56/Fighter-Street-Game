using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{
    None,
    Punch1,
    Punch2,
    Punch3,
    Kick1,
    Kick2,
    Death,
    
}
public class PlayerAttack : MonoBehaviour
{
    private ComboState state;
    private CharacterAnimation playeranim;

    private float comboTimerDefault;
    private float comboTimer = 0.4f;
    private bool combo = true;
    private Rigidbody rb;
    private float timerRun = 0.2f;
    private float defaultRunTimer;
    private bool run;
    public GameObject fireBallPoint;
    public GameObject fireBall;


    // Start is called before the first frame update
    void Start()
    {
        comboTimerDefault = comboTimer;
        playeranim = GetComponentInChildren<CharacterAnimation>();
        state = ComboState.None;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        PlayerAnimation();
    }
 
    void PlayerAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if ((state == ComboState.Punch3) || (state == ComboState.Kick1) || (state == ComboState.Kick2))
                return;

            
           // Debug.Log("Dd");
            state++;
            combo = true;          
            comboTimerDefault = comboTimer;
            if (state == ComboState.Punch1)
            {
                playeranim.Punch1();
            }
            if(state == ComboState.Punch2)
            {
                playeranim.Punch2();
            }
            if (state == ComboState.Punch3)
            {
                playeranim.Punch3();
            }

        }



        if(Input.GetKeyDown(KeyCode.X))
        {
             state = ComboState.Kick1;
            if (state == ComboState.Kick1)
            {
                playeranim.Kick1();

            }
            combo = true;
            comboTimerDefault = comboTimer;

            if (state == ComboState.Punch3 || state == ComboState.Kick2)
                return;

            if(state == ComboState.Punch1 || state == ComboState.Punch2)
            {
                state = ComboState.Kick1;
            }
           else if(state == ComboState.Kick1)
            {
                state++;
            }
           

            if (state == ComboState.Kick2)
            {
                playeranim.Kick2();
            }
            

        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            float timer = Time.time - defaultRunTimer;
            if(timer < timerRun)
            {
                transform.Translate(Vector3.forward *5 *Time.deltaTime);
                playeranim.Run(true);
            }
            else
            {
                rb.velocity = Vector3.zero;
                playeranim.Run(false);
            }

            defaultRunTimer = Time.time;
        }
      
      /*  if(Input.GetKeyDown(KeyCode.C))
        {
          //  if(transform.rotation.eulerAngles.y >29.5f)
           // {
            // //   transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 29.5f, transform.rotation.eulerAngles.z);
           // }////
            playeranim.FireBall();
            Invoke("FireBallInstant", 2f);

        }*/
    }
    public void FireBallInstant()
    {
        Instantiate(fireBall, fireBallPoint.transform.position, Quaternion.identity);
    }
    void Timer()
    {
        if (combo)
        {
           
            comboTimerDefault -= Time.deltaTime;

            if (comboTimerDefault <= 0)
            {
                state = ComboState.None;
                combo = false;
                comboTimerDefault = comboTimer;
            }
        }
       
    }
}




























