using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform highSpawnPoint;
    public Transform lowSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        while(!GameManager.instance.isGameOver)
        {
            Vector3 spawnPos = new Vector3(-5, -0.377f, Random.Range(-2, 2));
            spawnPos = GetSpawnPos();
            yield return new WaitForSeconds(3.0f);
            GameObject clone = Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
        }
       
    }

    public Vector3 GetSpawnPos()
    {
        float z1 = lowSpawnPoint.position.z;
        float z2 = highSpawnPoint.position.z;
        float x1 = lowSpawnPoint.position.x;
        float x2 = highSpawnPoint.position.x;

        Vector3 spawnPos;
        if (Random.value > .5f)
        {
            spawnPos = new Vector3(Random.Range(x2, x1), -.377f, (Random.value > .5f) ? z1 : z2);
        }
        else
        {
            spawnPos = new Vector3(x2, -.377f, Random.Range(z1,z2));
        }

        return spawnPos;
    }
}
