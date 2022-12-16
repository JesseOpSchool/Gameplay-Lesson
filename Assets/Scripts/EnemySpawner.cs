using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public ScoreScript scoreScript;
    public float minWait;
    public float maxWait;

    private bool isSpawning;
    

    void Awake()
    {
        isSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning)
        {
            float timer = Random.Range(minWait, maxWait);
            Invoke("SpawnObject", timer);
            isSpawning = true;
        }
    }
    void SpawnObject()
    {
        // Code to spawn your Prefab here
        isSpawning = false;
        GameObject newObject = Instantiate(enemy);
        newObject.GetComponent<Enemy>().scoreScript = scoreScript;
    }
}
