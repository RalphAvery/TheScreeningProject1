using UnityEngine;

public class Print : MonoBehaviour
{
    public GameObject test;
    public void TestPrint()
    {
        Instantiate(test);
    }

    public static void Page(GameObject page, Vector3 spawn)
    {
        Instantiate(page, spawn, Quaternion.identity);
    }
}
