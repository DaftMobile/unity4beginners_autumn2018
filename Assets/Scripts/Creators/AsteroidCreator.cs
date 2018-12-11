using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreator : MonoBehaviour
{
    private float minSpeed;
    private float maxSpeed;
    private float spawnPointX;
    private float spawnPointY;
    private float asteroidSpawnDelay;
    private float time = 0f;
    private IPrefabPool pool;
    
    
    public void Initialize(float minSpeed, float maxSpeed, float spawnPointX, float spawnPointY,
        float asteroidSpawnDelay , IPrefabPool pool)
    {
        this.minSpeed = minSpeed;
        this.maxSpeed = maxSpeed;
        this.spawnPointX = spawnPointX;
        this.spawnPointY = spawnPointY;
        this.asteroidSpawnDelay = asteroidSpawnDelay;
        this.pool = pool;
    }

    private void Update()
    {
        if (time >= asteroidSpawnDelay)
        {   
            InitializeAsteroid();
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    public void InitializeAsteroid()
    {
        GameObject asteroid = pool.Get();
        asteroid.transform.position = new Vector3(spawnPointX, RandomYPosition(), 0);
        asteroid.transform.parent = transform;
        
        MovingComponent moving = asteroid.GetComponent<MovingComponent>();
        moving.Initialize(RandomSpeed(), new LeftInputAdapter());
        moving.StartCoroutine(WaitForDestruction(asteroid));

        IAsteroidColider asteroidColider = asteroid.GetComponent<IAsteroidColider>();
        asteroidColider.SetCollisionCallback(ReturnToPool);
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
        ReturnToPool(asteroid);
    }

    private void ReturnToPool(GameObject asteroid)
    {
        pool.Return(asteroid);
    }
}    

