using UnityEngine;

public class Pointer : MonoBehaviour
{
    public PanelRotation pr;
    public int number;
    void OnTriggerEnter(Collider other)
    {
        pr.laps += number;
    }
}
