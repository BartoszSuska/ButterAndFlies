using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Boarshroom.Butterfly
{
    public class EnemySpawner : MonoBehaviour
    {
        Transform panPosition;

        [SerializeField] GameObject flyPrefab;

        [SerializeField] Vector2 spawnPositions;

        [SerializeField] Vector2 timeBtwSpawnStartMaxMin;
        float timeBtwSpawn;

        [SerializeField] float timeBtwSpawnDirStart;
        float timeBtwSpawnDir;

        Manager manager;
        Transform player;

        private void Start()
        {
            timeBtwSpawn = Random.Range(timeBtwSpawnStartMaxMin.x, timeBtwSpawnStartMaxMin.y);
            timeBtwSpawnDir = timeBtwSpawnDirStart;
            panPosition = GameObject.FindGameObjectWithTag("Pan").transform;
            manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            if(!manager.end)
            {
                if (timeBtwSpawn <= 0)
                {
                    float spawnX = Random.Range(spawnPositions.x, spawnPositions.y);
                    Vector2 spawnPos = new Vector2(spawnX, transform.position.y);
                    GameObject fly = Instantiate(flyPrefab, spawnPos, Quaternion.identity);
                    float endX = Random.Range(spawnPositions.x, spawnPositions.y);
                    fly.GetComponent<Fly>().endPosition = new Vector2(endX, panPosition.position.y - 1.5f);
                    timeBtwSpawn = Random.Range(timeBtwSpawnStartMaxMin.x, timeBtwSpawnStartMaxMin.y);
                }
                else
                {
                    timeBtwSpawn -= Time.deltaTime;
                }

                if(timeBtwSpawnDir <= 0)
                {
                    float spawnX = Random.Range(spawnPositions.x, spawnPositions.y);
                    Vector2 spawnPos = new Vector2(spawnX, transform.position.y);
                    GameObject fly = Instantiate(flyPrefab, spawnPos, Quaternion.identity);
                    fly.GetComponent<Fly>().endPosition = new Vector2(player.position.x, panPosition.position.y - 1.5f);
                    timeBtwSpawnDir = timeBtwSpawnDirStart;
                }
                else
                {
                    timeBtwSpawnDir -= Time.deltaTime;
                }
            }
        }
    }
}
