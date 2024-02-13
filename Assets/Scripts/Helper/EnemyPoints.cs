using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoints : MonoBehaviour
{
    public GameObject leftHandPoint, leftLegPoint;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
