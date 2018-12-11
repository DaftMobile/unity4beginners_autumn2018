using System;
using UnityEngine;

public class ShipCollisionDetector : MonoBehaviour
{
    private Action<int> OnCollision;

    public void Initialize(Action<int> onCollision)
    {
        OnCollision = onCollision;
    }

    private void OnTriggerEnter(Collider other)
    {
        IAsteroidColider collider = other.GetComponent<IAsteroidColider>();
        if (collider != null)
        {
            collider.OnCollision();
            OnCollision.Invoke(collider.Damage());
        }
        
    }
}