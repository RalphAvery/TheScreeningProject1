using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int roomNumber = 0;
    public string[] roomLetter = { "A", "B", "C", "E", "F" };
    private int roomIndex = 0;
    volumeChange vc;
    private float sysVolume;
    
    private void Start()
    {
        if (CompareTag("number"))
        {
            transform.GetChild(0).GetComponent<TMPro.TextMeshPro>().text = roomNumber.ToString();
        }
        if (CompareTag("letter"))
        {
            transform.GetChild(0).GetComponent<TMPro.TextMeshPro>().text = roomLetter[roomIndex];
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Animation>().Play("ButtonAnimation");
            if (CompareTag("number"))
            {
                roomNumber++;
                Debug.Log(roomNumber);
                transform.GetChild(0).GetComponent<TMPro.TextMeshPro>().text = roomNumber.ToString();
            }
            if (roomNumber == 9)
            {
                roomNumber = -1;
            }
            if (CompareTag("letter"))
            {
                roomIndex++;
                Debug.Log(roomLetter[roomIndex]);
                transform.GetChild(0).GetComponent<TMPro.TextMeshPro>().text = roomLetter[roomIndex];
            }
            if (roomIndex == 4)
            {
                roomIndex = -1;
            }
        }
    }
}
