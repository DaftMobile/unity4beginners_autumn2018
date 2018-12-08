using System;
using UnityEngine;

public class AsteroidColider : MonoBehaviour, IAsteroidColider
{
    private Action<GameObject> callback;
    
    public int Damage()
    {
        return 1;
    }

    public void SetCollisionCallback(Action<GameObject> callback)
    {
        this.callback = callback;
    }

    public void OnCollision()
    {
        callback.Invoke(gameObject);
    }
}