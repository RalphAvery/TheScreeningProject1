
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public int stageNum = 0;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (stageNum == 0 || stageNum == 2)
            {
                try
                {
                    // Play Animation Event for picking up the paper
                    PlayPickUpAnimation();
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    stageNum = 1;
                }
                catch
                {

                }
            }
            if (stageNum == 1)
            {
                // Play Animation Event for placing down the paper
                PlayPlaceDownAnimation();
                stageNum = 0;
            }
        }
    }

    // Method to handle Animation Event for picking up the paper
    public void PlayPickUpAnimation()
    {
        // Trigger animation for picking up the paper
        GetComponent<Animator>().SetTrigger("Click");
    }

    // Method to handle Animation Event for placing down the paper
    public void PlayPlaceDownAnimation()
    {
        // Trigger animation for placing down the paper
        // You can add your animation logic here
    }
}
