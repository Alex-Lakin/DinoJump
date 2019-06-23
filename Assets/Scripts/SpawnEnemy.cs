using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    [SerializeField] private GameObject enemyToSpawn;

    public void SpawnTheEnemy()
    {
        Instantiate(enemyToSpawn,transform.position,transform.rotation,transform.root);
        Destroy(gameObject);
    }
}
