using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxAttack : MonoBehaviour
{
   
    void Start()
    {
        Invoke("DisableFX", 3f);
    }
    private void DisableFX()
    {
        Destroy(this.gameObject);
    }

}
