using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using NUnit.Framework.Constraints;
using UnityEngine;

public class Initiator : MonoBehaviour
{
    [SerializeField] private float shipSpeed;
    [Header("Asteroid Variables")]
    [SerializeField] private float asteroidsSpeedMax;
    [SerializeField] private float asteroidsSpeedMin;
    [SerializeField] private float asteroidSpawnPointX;
    [SerializeField] private float asteroidSpawnPointY;
    [SerializeField] private float asteroidSpawnDeley;
    [SerializeField] private GameObject asteroidPrefab;
    
    [SerializeField] private AsteroidCreator asteroidCreator;

    [Header("Scene References")]
    [SerializeField] private List<MovingComponent> ship;

    private void Awake()
    {
        asteroidCreator.Initialize(asteroidsSpeedMin, asteroidsSpeedMax,
            asteroidSpawnPointX, asteroidSpawnPointY, asteroidSpawnDeley, asteroidPrefab);
        
        for (int i = 0; i < ship.Count; i++)
        {
            ship[i].Initialize(shipSpeed, new InputAdapter());
        }

    }
}