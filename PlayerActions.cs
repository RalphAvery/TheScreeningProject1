using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    public new Camera camera;
    public LevelHandler lh;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray clickOn = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(clickOn, out RaycastHit hit))
            {
                Debug.Log( hit.transform);

                /*switch (hit.transform.parent.tag)
                {
                    case "printer":
                        lh.NextLevel();
                        break;
                    case "Reciever":
                        Debug.Log("CLICKED reciever");
                        break;
                    case "Button":
                        Debug.Log("CLICKED button");
                        break;
                    default:
                        Debug.Log("mannnn");
                        break;
                }*/
            }
        }
    }
}
