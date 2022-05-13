using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypontIndex = 0;

    void Awake() 
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypontIndex].position;
    }

    
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(waypontIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypontIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                waypontIndex++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
