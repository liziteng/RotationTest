using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointer : MonoBehaviour
{
    public PanelRotation pr;
    void OnTriggerEnter(Collider other)
    {
        if(pr.laps > 0)
        pr.laps --;
        else if(pr.laps < 0)
        pr.laps ++;
    }
}
