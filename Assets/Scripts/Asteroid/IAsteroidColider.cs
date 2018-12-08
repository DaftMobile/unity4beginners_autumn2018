using System;
using UnityEngine;

public interface IAsteroidColider
{
    int Damage();
    void SetCollisionCallback(Action<GameObject> callback);
    void OnCollision();
}