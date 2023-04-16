using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;

public class EnemySpawner : MonoBehaviour
{
    public float radiusToSpawn = 80;
    public List<GameObject> enemies = new List<GameObject>();
    public float minTime = 10f;
    public float maxTime = 30;

    public GameObject particles;

    private GameObject playerShip;
    private Timer timer;

    private void Start()
    {
        playerShip = FindObjectOfType<NewShipController>().gameObject;
        timer = GetComponent<Timer>();
        timer.TimeOut.AddListener(RestartTimer);
        timer.TimeOut.AddListener(SpawnEnemy);
        timer.StartTimer(RandomTime(), false);
    }

    private void SpawnEnemy()
    {
        foreach(GameObject enemy in enemies)
        {
            Vector3 randomPos = (Random.insideUnitSphere * radiusToSpawn) + playerShip.transform.position;

            //Instantiate(particles, randomPos, Quaternion.identity);

            Instantiate(enemy, randomPos, Quaternion.identity);

            Debug.Log("Spawned");
        }
    }    

    private float RandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

    private void RestartTimer()
    {
        timer.StartTimer(RandomTime(), false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(FindObjectOfType<NewShipController>().transform.position, radiusToSpawn);
    }
}
