using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AsteroidCreator : MonoBehaviour
{
    private float minSpeed;
    private float maxSpeed;
    private float spawnPointX;
    private float spawnPointY;
    private float asteroidSpawnDelay;
    private GameObject asteroidPrefab;
    private float time = 0f;
    
    
    public void Initialize(float minSpeed, float maxSpeed, float spawnPointX, float spawnPointY,
        float asteroidSpawnDelay ,GameObject asteroidPrefab)
    {
        this.minSpeed = minSpeed;
        this.maxSpeed = maxSpeed;
        this.spawnPointX = spawnPointX;
        this.spawnPointY = spawnPointY;
        this.asteroidPrefab = asteroidPrefab;
        this.asteroidSpawnDelay = asteroidSpawnDelay;
    }

    private void Update()
    {
        if (time >= asteroidSpawnDelay)
        {
            CreateAsteroid();
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    public void CreateAsteroid()
    {
        GameObject asteroid = Instantiate(asteroidPrefab, new Vector3(spawnPointX, RandomYPosition(), 0),
            asteroidPrefab.transform.rotation, transform);
        MovingComponent moving = asteroid.GetComponent<MovingComponent>();
        moving.Initialize(RandomSpeed(), new LeftInputAdapter());
        moving.StartCoroutine(WaitForDestruction(asteroid));
    }

    private float RandomSpeed()
    {
        return Random.Range(minSpeed, maxSpeed);
    }
    
    private float RandomYPosition()
    {
        return Random.Range(-spawnPointY, spawnPointY);
    }

    private IEnumerator WaitForDestruction(GameObject asteroid)
    {
        while (asteroid.transform.position.x >= -spawnPointX)
        {
            yield return null;
        }
        GameObject.Destroy(asteroid);
    }
    
    
}
