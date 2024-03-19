using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    int currLevel = 0;
    public GameObject[] levels;
    private Vector3 spawnLocation;
    private void Start()
    {
        spawnLocation = transform.position;
    }
    public void NextLevel()
    {
        Print.Page(levels[currLevel], spawnLocation);
        currLevel++;
        Debug.Log(currLevel);
    }
}
