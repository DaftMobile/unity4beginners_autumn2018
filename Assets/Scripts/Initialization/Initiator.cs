using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class Initiator : MonoBehaviour
{
    [SerializeField] private float shipSpeed;
    [SerializeField] private float asteroidsSpeed;
    
    [SerializeField] private List<MovingComponent> ship;
    [SerializeField] private List<MovingComponent> rocks;

    private void Awake()
    {
        for (int i = 0; i < ship.Count; i++)
        {
            ship[i].Initialize(shipSpeed, new InputAdapter());
        }

        for (int i = 0; i < rocks.Count; i++)
        {
            rocks[i].Initialize(asteroidsSpeed, new LeftInputAdapter());
        }
    }
}