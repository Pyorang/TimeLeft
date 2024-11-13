using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    private bool playerDead = false;

    [SerializeField] private float spawnCycle;
    [SerializeField] private GameObject[] MonsterPrefab;
    
    void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster()
    {
        while(!playerDead)
        {
            Instantiate(MonsterPrefab[0], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnCycle);
        }
    }
}
