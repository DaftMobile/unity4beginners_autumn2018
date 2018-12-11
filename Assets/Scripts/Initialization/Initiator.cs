using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Initiator : MonoBehaviour
{

    [Header("ShipVariables")]
    [SerializeField] private int shipMaxLife;
    [SerializeField] private float shipSpeed;
    
    [Header("Asteroid Variables")]
    [SerializeField] private float asteroidsSpeedMax;
    [SerializeField] private float asteroidsSpeedMin;
    [SerializeField] private float asteroidSpawnPointX;
    [SerializeField] private float asteroidSpawnPointY;
    [SerializeField] private float asteroidSpawnDeley;
    [SerializeField] private int asteroidPoolsize;
    [SerializeField] private GameObject asteroidPrefab;
    
    [SerializeField] private AsteroidCreator asteroidCreator;

    [Header("UI")] 
    [SerializeField] private Image lifeBar;
    [SerializeField] private GameObject gameEndingObject;
    [SerializeField] private float gameEndingDelay;

    [Header("Scene References")]
    [SerializeField] private List<GameObject> ship;

    private void Awake()
    {
        IPrefabPool asteroidPool = new PrefabPool(asteroidPoolsize, asteroidPrefab);
        
        asteroidCreator.Initialize(asteroidsSpeedMin, asteroidsSpeedMax,
            asteroidSpawnPointX, asteroidSpawnPointY, asteroidSpawnDeley, asteroidPool);
   
        
        for (int i = 0; i < ship.Count; i++)
        {
            IGameEnding gameEnding = new GameEnding(ship[i], this,
                gameEndingObject, gameEndingDelay);
            
            LifeManager lifeManager = gameObject.AddComponent<LifeManager>();
            lifeManager.Initialize(lifeBar, shipMaxLife, ship[i], gameEnding);

            MovingComponent movingComponent = ship[i].GetComponent<MovingComponent>();            
            movingComponent.Initialize(shipSpeed, new InputAdapter());
            movingComponent.GetComponent<ShipCollisionDetector>().Initialize(lifeManager.DealDamage);
        }
  
    }
}