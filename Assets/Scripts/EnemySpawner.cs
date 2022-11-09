using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
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
        while(true)
        {
            Vector3 spawnPos = new Vector3(-5, 0, Random.Range(-2, 2));
            yield return new WaitForSeconds(3.0f);
            GameObject clone = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
       
    }
}
