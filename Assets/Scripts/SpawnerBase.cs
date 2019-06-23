using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBase : MonoBehaviour {

    private Transform player;
    [SerializeField] private float triggerDistance;
    private SpawnEnemy[] childSpawners;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        childSpawners = GetComponentsInChildren<SpawnEnemy>();
	}
	
	// Update is called once per frame
	void Update () {
        float distToPlayer = Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(player.position.x,0));

        if (distToPlayer <= triggerDistance) {
            foreach (SpawnEnemy enemySpawner in childSpawners)
            {
                enemySpawner.SpawnTheEnemy();
            }
            Destroy(gameObject);
        }
	}
}
