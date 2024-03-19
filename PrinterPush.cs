using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterPush : MonoBehaviour
{
    private Vector3 printForce;
    private void Start()
    {
        printForce.Set(0, 0, -3.5f);
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.attachedRigidbody == true)
        {
            other.GetComponent<Rigidbody>().velocity = printForce;
        }
    }
}
